﻿using ScottPlot.Ticks;
using ScottPlot.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;

namespace ScottPlot.Renderable
{
    /// <summary>
    /// This class holds axis rendering details (label, ticks, tick labels) but no logic
    /// </summary>
    public class Axis : IRenderable
    {
        public readonly AxisDimensions Dims = new AxisDimensions();
        public int AxisIndex = 0;
        private Edge _Edge;
        public Edge Edge
        {
            get => _Edge;
            set
            {
                _Edge = value;
                Line.Edge = value;
                Title.Edge = value;
                Ticks.Edge = value;
                bool isVertical = (value == Edge.Left || value == Edge.Right);
                Ticks.TickCollection.verticalAxis = isVertical;
                Dims.IsInverted = isVertical;
            }
        }
        public bool IsHorizontal => Edge == Edge.Top || Edge == Edge.Bottom;
        public bool IsVertical => Edge == Edge.Left || Edge == Edge.Right;
        public bool IsVisible { get; set; } = true;

        public float PixelOffset; // TightenLayout() populates this value based on other PixelSize values
        public float PixelSize; // RecalculateAxisSize() populates this value
        public float PixelSizeMinimum = 5;
        public float PixelSizeMaximum = float.PositiveInfinity;
        public float PixelSizePadding = 3;

        public readonly AxisTitle Title = new AxisTitle();
        public readonly AxisTicks Ticks = new AxisTicks();
        public readonly AxisLine Line = new AxisLine();

        public override string ToString() => $"{Edge} axis from {Dims.Min} to {Dims.Max}";

        public void RecalculateTickPositions(PlotDimensions dims)
        {
            Ticks.TickCollection.Recalculate(dims, Ticks.MajorLabelFont);
        }

        public void Render(PlotDimensions dims, Bitmap bmp, bool lowQuality = false)
        {
            if (IsVisible == false)
                return;

            Title.PixelSizePadding = PixelSizePadding;
            Ticks.PixelOffset = PixelOffset;
            Title.PixelOffset = PixelOffset;
            Title.PixelSize = PixelSize;
            Line.PixelOffset = PixelOffset;

            using (var gfx = GDI.Graphics(bmp, lowQuality))
            {
                Ticks.Render(dims, bmp, lowQuality);
                Title.Render(dims, bmp, lowQuality);
                Line.Render(dims, bmp, lowQuality);
            }
        }

        /// <summary>
        /// DateTime format assumes axis represents DateTime.ToOATime() units and displays tick labels accordingly.
        /// </summary>
        public void DateTimeFormat(bool enable)
        {
            Ticks.TickCollection.dateFormat = enable;
        }

        /// <summary>
        /// Configure the label of this axis
        /// </summary>
        public void SetLabel(string label = null, Color? color = null, float? size = null, bool? bold = null, string fontName = null)
        {
            Title.IsVisible = true;
            Title.Label = label ?? Title.Label;
            Title.Font.Color = color ?? Title.Font.Color;
            Title.Font.Size = size ?? Title.Font.Size;
            Title.Font.Bold = bold ?? Title.Font.Bold;
            Title.Font.Name = fontName ?? Title.Font.Name;
        }

        /// <summary>
        /// Set color of every component of this axis (label, line, tick marks, and tick labels)
        /// </summary>
        public void SetColor(Color color)
        {
            SetLabel(color: color);
            TickLabelStyle(color: color);
            Ticks.Color = color;
            Line.Color = color;
        }

        /// <summary>
        /// Manually define the string format to use for translating tick positions to tick labels
        /// </summary>
        public void SetTickLabelFormat(string format, bool dateTimeFormat)
        {
            if (dateTimeFormat)
            {
                Ticks.TickCollection.dateTimeFormatString = format;
                DateTimeFormat(true);
            }
            else
            {
                Ticks.TickCollection.numericFormatString = format;
                DateTimeFormat(false);
            }
        }

        /// <summary>
        /// Customize string settings for the tick labels
        /// </summary>
        public void TickLabelNotation(
            bool? multiplier = null,
            bool? offset = null,
            bool? exponential = null,
            bool? invertSign = null,
            int? radix = null,
            string prefix = null)
        {
            Ticks.TickCollection.useMultiplierNotation = multiplier ?? Ticks.TickCollection.useMultiplierNotation;
            Ticks.TickCollection.useOffsetNotation = offset ?? Ticks.TickCollection.useOffsetNotation;
            Ticks.TickCollection.useExponentialNotation = exponential ?? Ticks.TickCollection.useExponentialNotation;
            Ticks.TickCollection.invertSign = invertSign ?? Ticks.TickCollection.invertSign;
            Ticks.TickCollection.radix = radix ?? Ticks.TickCollection.radix;
            Ticks.TickCollection.prefix = prefix ?? Ticks.TickCollection.prefix;
        }

        /// <summary>
        /// Define a manual spacing between major ticks (and major grid lines)
        /// </summary>
        public void SetTickSpacing(double manualSpacing)
        {
            // TODO: cutt X and Y out of this
            Ticks.TickCollection.manualSpacingX = manualSpacing;
            Ticks.TickCollection.manualSpacingY = manualSpacing;
        }

        /// <summary>
        /// Define a manual spacing between major ticks (and major grid lines) for axes configured to display using DateTime format
        /// </summary>
        public void SetTickSpacing(double manualSpacing, DateTimeUnit manualSpacingDateTimeUnit)
        {
            SetTickSpacing(manualSpacing);
            Ticks.TickCollection.manualDateTimeSpacingUnitX = manualSpacingDateTimeUnit;
        }

        /// <summary>
        /// Ruler mode draws long tick marks and offsets tick labels for a ruler appearance
        /// </summary>
        public void RulerMode(bool enable) => Ticks.RulerMode = enable;

        /// <summary>
        /// Enable this to snap major ticks (and grid lines) to the nearest pixel to avoid anti-aliasing artifacts
        /// </summary>
        /// <param name="enable"></param>
        public void PixelSnap(bool enable) => Ticks.SnapPx = enable;

        /// <summary>
        /// Customize styling of the tick labels
        /// </summary>
        public void TickLabelStyle(
            Color? color = null,
            string fontName = null,
            float? fontSize = null,
            bool? fontBold = null,
            float? rotation = null)
        {
            Ticks.Color = color ?? Ticks.Color;
            Ticks.MajorLabelFont.Name = fontName ?? Ticks.MajorLabelFont.Name;
            Ticks.MajorLabelFont.Size = fontSize ?? Ticks.MajorLabelFont.Size;
            Ticks.MajorLabelFont.Bold = fontBold ?? Ticks.MajorLabelFont.Bold;
            Ticks.Rotation = rotation ?? Ticks.Rotation;
        }

        /// <summary>
        /// Manually define major tick (and grid) positions and labels
        /// </summary>
        public void SetTickPositions(double[] positions, string[] labels)
        {
            Ticks.TickCollection.manualTickPositions = positions;
            Ticks.TickCollection.manualTickLabels = labels;
        }

        // TODO: rename this to just ticks!

        /// <summary>
        /// Set visibility of major ticks and labels
        /// </summary>
        public void MajorTicks(bool enable, bool labels = true, bool minorToo = true)
        {
            Ticks.MajorTickEnable = enable;
            Ticks.MajorLabelEnable = enable && labels;
            if (minorToo)
                Ticks.MinorTickEnable = enable;
        }

        /// <summary>
        /// Set visibility of major ticks and labels
        /// </summary>
        public void MinorTicks(bool enable, bool logScale = false)
        {
            Ticks.MinorTickEnable = enable;
            Ticks.TickCollection.logScale = logScale;
        }

        /// <summary>
        /// Configure tick visibility and positioning
        /// </summary>
        public void ConfigureTicks(
            bool? majorTickMarks = null,
            bool? majorTickLabels = null,
            bool? minorTickMarks = null)
        {
            Ticks.MinorTickEnable = minorTickMarks ?? Ticks.MinorTickEnable;
        }

        /// <summary>
        /// Configure the line drawn along the edge of the axis
        /// </summary>
        public void ConfigureLine(bool? visible = null, Color? color = null, float? width = null)
        {
            Line.IsVisible = visible ?? Line.IsVisible;
            Line.Color = color ?? Line.Color;
            Line.Width = width ?? Line.Width;
        }

        /// <summary>
        /// Set the minimum size and padding of the axis
        /// </summary>
        public void ConfigureLayout(float? padding = null, float? minimumSize = null, float? maximumSize = null)
        {
            PixelSizePadding = padding ?? PixelSizePadding;
            PixelSizeMinimum = minimumSize ?? PixelSizeMinimum;
            PixelSizeMaximum = maximumSize ?? PixelSizeMaximum;
        }

        /// <summary>
        /// Configure visibility and styling of the major grid
        /// </summary>
        public void MajorGrid(
            bool? enable = null,
            Color? color = null,
            float? lineWidth = null,
            LineStyle? lineStyle = null)
        {
            Ticks.MajorGridEnable = enable ?? Ticks.MajorGridEnable;
            Ticks.MajorGridColor = color ?? Ticks.MajorGridColor;
            Ticks.MajorGridWidth = lineWidth ?? Ticks.MajorGridWidth;
            Ticks.MajorGridStyle = lineStyle ?? Ticks.MajorGridStyle;
        }

        public void ConfigureMinorGrid(
            bool? enable = null,
            Color? color = null,
            float? lineWidth = null,
            LineStyle? lineStyle = null)
        {
            Ticks.MinorGridEnable = enable ?? Ticks.MinorGridEnable;
            Ticks.MinorGridColor = color ?? Ticks.MinorGridColor;
            Ticks.MinorGridWidth = lineWidth ?? Ticks.MinorGridWidth;
            Ticks.MinorGridStyle = lineStyle ?? Ticks.MinorGridStyle;
        }

        /// <summary>
        /// Disable all visibility and set size to 0px
        /// </summary>
        public void Hide()
        {
            IsVisible = false;
            PixelSizeMinimum = 0;
            PixelSizeMaximum = 0;
            PixelSizePadding = 0;
        }

        /// <summary>
        /// Set visibility for major tick grid lines
        /// </summary>
        /// <param name="enable"></param>
        public void Grid(bool enable)
        {
            Ticks.MajorGridEnable = enable;
            Ticks.MinorTickEnable = enable;
        }

        /// <summary>
        /// Control visibility of major tick marks, major tick labels, and minor tick marks
        /// </summary>
        public void TickMarks(bool enable)
        {
            Ticks.MajorTickEnable = enable;
            Ticks.MajorLabelEnable = enable;
            Ticks.MinorTickEnable = enable;
        }

        // TODO: delete this in favor of individual setters?
        /// <summary>
        /// High-level configuration for axis label, tick labels, and all tick lines
        /// </summary>
        public void Configure(Color? color = null, bool? ticks = null, bool? grid = null)
        {
            if (color.HasValue)
                SetColor(color.Value);

            if (ticks.HasValue)
                TickMarks(ticks.Value);

            if (grid.HasValue)
                Grid(grid.Value);
        }

        public void RecalculateAxisSize()
        {
            using (var tickFont = GDI.Font(Ticks.MajorLabelFont))
            using (var titleFont = GDI.Font(Title.Font))
            {
                PixelSize = 0;

                if (Title.IsVisible)
                    PixelSize += GDI.MeasureString(Title.Label, Title.Font).Height;

                if (Ticks.MajorLabelEnable)
                    PixelSize += IsHorizontal ? Ticks.TickCollection.maxLabelHeight : Ticks.TickCollection.maxLabelWidth * 1.2f;

                if (Ticks.MajorTickEnable)
                    PixelSize += Ticks.MajorTickLength;

                PixelSize = Math.Max(PixelSize, PixelSizeMinimum);
                PixelSize = Math.Min(PixelSize, PixelSizeMaximum);
                PixelSize += PixelSizePadding;
            }
        }
    }
}

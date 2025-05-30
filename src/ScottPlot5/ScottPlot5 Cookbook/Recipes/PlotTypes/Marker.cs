namespace ScottPlotCookbook.Recipes.PlotTypes;

public class Marker : ICategory
{
    public Chapter Chapter => Chapter.PlotTypes;
    public string CategoryName => "Marker";
    public string CategoryDescription => "Markers can be placed on the plot in coordinate space.";

    public class MarkerQuickstart : RecipeBase
    {
        public override string Name => "Marker Quickstart";
        public override string Description => "Markers are symbols placed at a " +
            "location in coordinate space. Their shape, size, and color can be customized.";

        [Test]
        public override void Execute()
        {
            myPlot.Add.Signal(Generate.Sin());
            myPlot.Add.Signal(Generate.Cos());

            myPlot.Add.Marker(25, .5);
            myPlot.Add.Marker(35, .6);
            myPlot.Add.Marker(45, .7);
        }
    }

    public class MarkerShapes : RecipeBase
    {
        public override string Name => "Marker Shapes";
        public override string Description => "Standard marker shapes are provided, " +
            "but advanced users are able to create their own as well.";

        [Test]
        public override void Execute()
        {
            MarkerShape[] markerShapes = Enum.GetValues<MarkerShape>().ToArray();
            ScottPlot.Palettes.Category20 palette = new();

            for (int i = 0; i < markerShapes.Length; i++)
            {
                var mp = myPlot.Add.Marker(x: i, y: 0);
                mp.MarkerStyle.Shape = markerShapes[i];
                mp.MarkerStyle.Size = 10;

                // markers made from filled shapes have can be customized
                mp.MarkerStyle.FillColor = palette.GetColor(i).WithAlpha(.5);

                // markers made from filled shapes have optional outlines
                mp.MarkerStyle.OutlineColor = palette.GetColor(i);
                mp.MarkerStyle.OutlineWidth = 2;

                // markers created from lines can be customized
                mp.MarkerStyle.LineWidth = 2f;
                mp.MarkerStyle.LineColor = palette.GetColor(i);

                var txt = myPlot.Add.Text(markerShapes[i].ToString(), i, 0.15);
                txt.LabelRotation = -90;
                txt.LabelAlignment = Alignment.MiddleLeft;
                txt.LabelFontColor = Colors.Black;
            }

            myPlot.Title("Marker Names");
            myPlot.Axes.SetLimits(-1, markerShapes.Length, -1, 4);
            myPlot.HideGrid();
        }
    }

    public class MarkerLegend : RecipeBase
    {
        public override string Name => "Marker Legend";
        public override string Description => "Markers with labels appear in the legend.";

        [Test]
        public override void Execute()
        {
            var sin = myPlot.Add.Signal(Generate.Sin());
            sin.LegendText = "Sine";

            var cos = myPlot.Add.Signal(Generate.Cos());
            cos.LegendText = "Cosine";

            var marker = myPlot.Add.Marker(25, .5);
            marker.LegendText = "Marker";
            myPlot.ShowLegend();
        }
    }

    public class MarkersPlot : RecipeBase
    {
        public override string Name => "Many Markers";
        public override string Description => "Collections of markers " +
            "that are all styled the same may be added to the plot";

        [Test]
        public override void Execute()
        {
            double[] xs = Generate.Consecutive(51);
            double[] sin = Generate.Sin(51);
            double[] cos = Generate.Cos(51);

            myPlot.Add.Markers(xs, sin, MarkerShape.OpenCircle, 15, Colors.Green);
            myPlot.Add.Markers(xs, cos, MarkerShape.FilledDiamond, 10, Colors.Magenta);
        }
    }

    public class MarkersColormap : RecipeBase
    {
        public override string Name => "Marker with Colormap";
        public override string Description => "A colormap may be used to style a collection of markers";

        [Test]
        public override void Execute()
        {
            double[] xs = Generate.Consecutive(51);
            double[] ys = Generate.Sin(51);

            var markers = myPlot.Add.Markers(xs, ys);
            markers.Colormap = new ScottPlot.Colormaps.MellowRainbow();
        }
    }

    public class ImageMarkerQuickstart : RecipeBase
    {
        public override string Name => "Image Marker";
        public override string Description => "An ImageMarker can be placed on the plot " +
            "to display an image centered at a location in coordinate space.";

        [Test]
        public override void Execute()
        {
            myPlot.Add.Signal(Generate.Sin());
            myPlot.Add.Signal(Generate.Cos());

            // An image can be loaded from a file or created dynamically
            ScottPlot.Image image = SampleImages.ScottPlotLogo(48, 48);

            Coordinates location1 = new(5, .5);
            Coordinates location2 = new(25, .5);

            myPlot.Add.ImageMarker(location1, image);
            myPlot.Add.ImageMarker(location2, image, scale: 2);

            var m1 = myPlot.Add.Marker(location1);
            var m2 = myPlot.Add.Marker(location2);
            m1.Color = Colors.Orange;
            m2.Color = Colors.Orange;
        }
    }

    public class MarkerLineOnly : RecipeBase
    {
        public override string Name => "Line Only Markers";
        public override string Description => "Markers composed of lines only do not have fill properties.";

        [Test]
        public override void Execute()
        {
            MarkerShape[] lineOnlyMarkerShapes = [
                MarkerShape.OpenCircle,
                MarkerShape.OpenSquare,
                MarkerShape.OpenTriangleUp,
                MarkerShape.Eks,
                MarkerShape.Cross,
                MarkerShape.Asterisk,
                MarkerShape.HashTag,
            ];

            for (int i = 0; i < lineOnlyMarkerShapes.Length; i++)
            {
                var marker = myPlot.Add.Marker(i, 0, lineOnlyMarkerShapes[i]);

                // line only markers have line customization options
                marker.MarkerLineColor = Colors.Blue;
                marker.LineWidth = 2;
                marker.MarkerSize = 20;

                // line only markers are unaffected by changes in fill properties
                marker.MarkerFillColor = Colors.Green;
            }

            myPlot.Layout.Frameless();
            myPlot.HideGrid();
        }
    }

    public class MarkerWithFill : RecipeBase
    {
        public override string Name => "Markers with Fills";
        public override string Description => "Markers with fills support customization.";

        [Test]
        public override void Execute()
        {
            MarkerShape[] filledMarkerShapes = [
                MarkerShape.FilledCircle,
                MarkerShape.FilledSquare,
                MarkerShape.FilledTriangleUp,
                MarkerShape.FilledTriangleDown,
                MarkerShape.FilledDiamond,
            ];

            for (int i = 0; i < filledMarkerShapes.Length; i++)
            {
                var markerFill = myPlot.Add.Marker(i, 1, filledMarkerShapes[i]);
                markerFill.MarkerSize = 20;

                var markerFillAndOutline = myPlot.Add.Marker(i, -1, filledMarkerShapes[i]);
                markerFillAndOutline.MarkerSize = 20;

                // filled markers have a customizable fill color
                markerFill.MarkerFillColor = Colors.Green.WithAlpha(.5);
                markerFillAndOutline.MarkerFillColor = Colors.Green.WithAlpha(.5);

                // filled markers can be given an outline
                markerFillAndOutline.MarkerLineColor = Colors.Blue;
                markerFillAndOutline.LineWidth = 2;
            }

            myPlot.Layout.Frameless();
            myPlot.HideGrid();
            myPlot.Axes.SetLimitsY(-5, 5);
        }
    }
}

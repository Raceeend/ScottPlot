﻿//This is a cmocean colormap
//All credit to Kristen Thyng
//This colormap is under the MIT License
//All cmocean colormaps are available at https://github.com/matplotlib/cmocean/tree/master/cmocean/rgb

namespace ScottPlot.Drawing.Colormaps
{
    public class Phase : IColormap
    {
        public (byte r, byte g, byte b) GetRGB(byte value) =>
            (cmaplocal[value, 0], cmaplocal[value, 1], cmaplocal[value, 2]);

        private static readonly byte[,] cmaplocal = {
            { 168, 120, 13 },
            { 169, 119, 15 },
            { 171, 118, 17 },
            { 172, 117, 19 },
            { 174, 116, 20 },
            { 175, 115, 22 },
            { 177, 114, 24 },
            { 178, 113, 25 },
            { 179, 112, 27 },
            { 181, 111, 29 },
            { 182, 110, 30 },
            { 183, 109, 32 },
            { 185, 108, 34 },
            { 186, 107, 35 },
            { 187, 106, 37 },
            { 189, 105, 38 },
            { 190, 104, 40 },
            { 191, 103, 42 },
            { 192, 102, 43 },
            { 193, 101, 45 },
            { 194, 100, 46 },
            { 196, 98, 48 },
            { 197, 97, 50 },
            { 198, 96, 51 },
            { 199, 95, 53 },
            { 200, 94, 55 },
            { 201, 93, 56 },
            { 202, 92, 58 },
            { 203, 90, 60 },
            { 204, 89, 62 },
            { 205, 88, 63 },
            { 206, 87, 65 },
            { 207, 86, 67 },
            { 208, 84, 69 },
            { 208, 83, 71 },
            { 209, 82, 73 },
            { 210, 81, 75 },
            { 211, 79, 77 },
            { 212, 78, 79 },
            { 213, 77, 81 },
            { 213, 75, 83 },
            { 214, 74, 85 },
            { 215, 73, 87 },
            { 216, 71, 90 },
            { 216, 70, 92 },
            { 217, 69, 94 },
            { 217, 67, 97 },
            { 218, 66, 99 },
            { 219, 64, 102 },
            { 219, 63, 104 },
            { 220, 61, 107 },
            { 220, 60, 109 },
            { 221, 58, 112 },
            { 221, 57, 115 },
            { 221, 56, 118 },
            { 222, 54, 120 },
            { 222, 53, 123 },
            { 222, 51, 126 },
            { 222, 50, 129 },
            { 223, 49, 132 },
            { 223, 47, 135 },
            { 223, 46, 138 },
            { 223, 45, 141 },
            { 223, 43, 144 },
            { 223, 42, 147 },
            { 222, 41, 151 },
            { 222, 40, 154 },
            { 222, 40, 157 },
            { 222, 39, 160 },
            { 221, 38, 163 },
            { 221, 38, 166 },
            { 220, 37, 169 },
            { 220, 37, 173 },
            { 219, 37, 176 },
            { 218, 37, 179 },
            { 218, 38, 182 },
            { 217, 38, 185 },
            { 216, 39, 188 },
            { 215, 39, 190 },
            { 214, 40, 193 },
            { 213, 41, 196 },
            { 212, 42, 199 },
            { 211, 43, 201 },
            { 210, 45, 204 },
            { 209, 46, 206 },
            { 208, 47, 208 },
            { 207, 49, 211 },
            { 205, 50, 213 },
            { 204, 52, 215 },
            { 203, 53, 217 },
            { 201, 55, 219 },
            { 200, 57, 221 },
            { 198, 58, 223 },
            { 197, 60, 225 },
            { 195, 62, 226 },
            { 194, 63, 228 },
            { 192, 65, 229 },
            { 190, 67, 231 },
            { 189, 69, 232 },
            { 187, 70, 233 },
            { 185, 72, 235 },
            { 184, 74, 236 },
            { 182, 75, 237 },
            { 180, 77, 238 },
            { 178, 79, 239 },
            { 176, 80, 239 },
            { 174, 82, 240 },
            { 172, 84, 241 },
            { 170, 85, 241 },
            { 169, 87, 242 },
            { 167, 89, 243 },
            { 164, 90, 243 },
            { 162, 92, 243 },
            { 160, 93, 244 },
            { 158, 95, 244 },
            { 156, 96, 244 },
            { 154, 98, 244 },
            { 152, 99, 244 },
            { 149, 101, 244 },
            { 147, 102, 244 },
            { 145, 104, 244 },
            { 143, 105, 244 },
            { 140, 107, 243 },
            { 138, 108, 243 },
            { 135, 109, 243 },
            { 133, 111, 242 },
            { 130, 112, 241 },
            { 128, 113, 241 },
            { 125, 115, 240 },
            { 123, 116, 239 },
            { 120, 117, 239 },
            { 118, 119, 238 },
            { 115, 120, 237 },
            { 112, 121, 236 },
            { 110, 122, 235 },
            { 107, 123, 233 },
            { 104, 124, 232 },
            { 102, 126, 231 },
            { 99, 127, 230 },
            { 96, 128, 228 },
            { 93, 129, 227 },
            { 90, 130, 225 },
            { 88, 131, 223 },
            { 85, 132, 222 },
            { 82, 133, 220 },
            { 79, 134, 218 },
            { 77, 135, 216 },
            { 74, 135, 215 },
            { 71, 136, 213 },
            { 69, 137, 211 },
            { 66, 138, 209 },
            { 64, 138, 207 },
            { 61, 139, 205 },
            { 59, 140, 203 },
            { 56, 140, 201 },
            { 54, 141, 199 },
            { 52, 142, 196 },
            { 50, 142, 194 },
            { 48, 143, 192 },
            { 46, 143, 190 },
            { 44, 144, 188 },
            { 42, 144, 186 },
            { 40, 145, 184 },
            { 39, 145, 182 },
            { 37, 145, 180 },
            { 36, 146, 178 },
            { 35, 146, 176 },
            { 33, 146, 174 },
            { 32, 147, 172 },
            { 31, 147, 170 },
            { 30, 147, 168 },
            { 29, 148, 166 },
            { 28, 148, 164 },
            { 27, 148, 162 },
            { 26, 148, 160 },
            { 25, 149, 158 },
            { 25, 149, 156 },
            { 24, 149, 154 },
            { 23, 149, 152 },
            { 22, 150, 150 },
            { 21, 150, 148 },
            { 20, 150, 146 },
            { 20, 150, 144 },
            { 19, 151, 142 },
            { 18, 151, 140 },
            { 17, 151, 138 },
            { 16, 151, 136 },
            { 15, 151, 134 },
            { 14, 152, 132 },
            { 13, 152, 130 },
            { 13, 152, 128 },
            { 12, 152, 126 },
            { 12, 152, 124 },
            { 11, 153, 121 },
            { 11, 153, 119 },
            { 11, 153, 117 },
            { 12, 153, 115 },
            { 13, 153, 112 },
            { 14, 153, 110 },
            { 15, 154, 107 },
            { 17, 154, 105 },
            { 19, 154, 102 },
            { 21, 154, 99 },
            { 23, 154, 97 },
            { 25, 154, 94 },
            { 28, 154, 91 },
            { 31, 154, 88 },
            { 33, 154, 85 },
            { 36, 154, 82 },
            { 39, 154, 79 },
            { 43, 154, 76 },
            { 46, 154, 73 },
            { 49, 153, 70 },
            { 53, 153, 67 },
            { 56, 153, 64 },
            { 60, 153, 60 },
            { 64, 152, 57 },
            { 67, 152, 54 },
            { 71, 151, 50 },
            { 75, 151, 47 },
            { 79, 150, 44 },
            { 83, 150, 41 },
            { 86, 149, 38 },
            { 90, 148, 35 },
            { 94, 148, 32 },
            { 97, 147, 30 },
            { 101, 146, 27 },
            { 104, 145, 25 },
            { 107, 144, 23 },
            { 111, 144, 22 },
            { 114, 143, 20 },
            { 116, 142, 19 },
            { 119, 141, 18 },
            { 122, 140, 17 },
            { 125, 139, 16 },
            { 127, 139, 15 },
            { 130, 138, 15 },
            { 132, 137, 14 },
            { 134, 136, 14 },
            { 136, 135, 14 },
            { 139, 134, 13 },
            { 141, 133, 13 },
            { 143, 132, 13 },
            { 145, 131, 13 },
            { 147, 131, 13 },
            { 149, 130, 13 },
            { 151, 129, 13 },
            { 153, 128, 13 },
            { 155, 127, 13 },
            { 157, 126, 13 },
            { 159, 125, 13 },
            { 161, 124, 13 },
            { 162, 123, 13 },
            { 164, 122, 13 },
            { 166, 121, 13 },
            { 168, 120, 13 }

        };
    }
}


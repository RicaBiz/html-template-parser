using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Raylib_cs.Rectangle;

namespace html_template_parser.View
{
    internal class FileInputTextBox(int screenWidth, int screenHeight, int x, int y, int width, int height, int maxCharLength, int fontSize, TwoColorPalette normalPalette, TwoColorPalette focusPalette) : InputTextBox(screenWidth, screenHeight, x, y, width, height, maxCharLength, fontSize, normalPalette, focusPalette)
    {
        private String absolutePath = "";
        public String AbsolutePath { get => absolutePath; set => absolutePath = value; }

    }
}

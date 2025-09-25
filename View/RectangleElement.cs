using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Rectangle = Raylib_cs.Rectangle;
using Color = Raylib_cs.Color;

namespace html_template_parser.View
{
    internal class RectangleElement(int screenWidth, int screenHeight, int x, int y, int width, int height)
    {
        protected int x = x;
        protected int y = y;
        protected readonly double xRatio = (double)x / screenWidth;
        protected readonly double yRatio = (double)y / screenHeight;
        protected void UpdateRelativePosition()
        {
            x = (int)(xRatio * GetScreenWidth());
            y = (int)(yRatio * GetScreenHeight());
        }

        public void Draw(Color backgroundColor)
        {
            UpdateRelativePosition();
            DrawRectangleRec(GetRectangle(), backgroundColor);
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(x - width / 2, y - height / 2, width, height);
        }
    }
}

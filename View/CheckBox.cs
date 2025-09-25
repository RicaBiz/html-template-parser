using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace html_template_parser.View
{
    internal class CheckBox(int screenWidth, int screenHeight, int x, int y, int edgeLength, TwoColorPalette colorPalette) : RectangleElement(screenWidth, screenHeight, x, y, edgeLength, edgeLength)
    {
        private bool isChecked = false;
        public bool IsChecked { get => isChecked; set => isChecked = value; }
        public void Draw()
        {
            base.Draw(colorPalette.BackgroundColor);
            var square = GetRectangle();
            DrawRectangleLinesEx(square, 5, colorPalette.DetailColor);
            if (isChecked)
            {
                DrawLineEx(new(square.X + 5, square.Y + 5), new(square.X + edgeLength - 5, square.Y + edgeLength - 5), 5, colorPalette.DetailColor);
                DrawLineEx(new(square.X + edgeLength - 5, square.Y + 5), new(square.X + 5, square.Y + edgeLength - 5), 5, colorPalette.DetailColor);
            }
        }

        public void UpdateState()
        {
            if (CheckCollisionPointRec(GetMousePosition(), GetRectangle()))
            {
                if (IsMouseButtonReleased(MouseButton.Left))
                    isChecked = !isChecked;
            }
        }
    }
}

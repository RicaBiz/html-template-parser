using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rectangle = Raylib_cs.Rectangle;
using Color = Raylib_cs.Color;

namespace html_template_parser.View
{
    internal class Button(int screenWidth, int screenHeight, int x, int y, int width, int height, string text, int fontSize, TwoColorPalette normalPalette, TwoColorPalette pressedPalette, TwoColorPalette hoverPalette) : RectangleElement(screenWidth, screenHeight, x, y, width, height)
    {
        private class StatesEnum { public const int NORMAL = 0, HOVER = 1, PRESSED = 2; }
        private int state = StatesEnum.NORMAL;

        public void Draw()
        {
            TwoColorPalette palette = state switch
            {
                StatesEnum.NORMAL => normalPalette,
                StatesEnum.HOVER => hoverPalette,
                StatesEnum.PRESSED => pressedPalette,
                _ => new(Color.Red, Color.Red)
            };
            base.Draw(palette.BackgroundColor);
            DrawText(text, x - MeasureText(text, fontSize) / 2, y - fontSize / 2, fontSize, palette.DetailColor);
        }

        public bool UpdateState()
        {
            if (CheckCollisionPointRec(GetMousePosition(), GetRectangle()))
            {
                if (IsMouseButtonDown(MouseButton.Left))
                    state = StatesEnum.PRESSED;
                else
                    state = StatesEnum.HOVER;

                if (IsMouseButtonReleased(MouseButton.Left))
                    return true;
            }
            else
                state = StatesEnum.NORMAL;
            return false;
        }
    }
}

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
    internal class InputTextBox(int screenWidth, int screenHeight, int x, int y, int width, int height, int maxCharLength, int fontSize, TwoColorPalette normalPalette, TwoColorPalette focusPalette) : TextBox(screenWidth, screenHeight, x, y, width, height, fontSize, normalPalette, focusPalette)
    {
        private int counter = 0;
        public new void Draw()
        {
            TwoColorPalette palette = focus ? focusPalette : normalPalette;
            base.Draw();
            if (focus)
                if (counter < 30)
                {
                    DrawText("_", x + MeasureText(Text, fontSize) / 2, y - fontSize / 2, fontSize, palette.DetailColor);
                }
                else { }
            else
                counter = 0;
            counter = (counter + 1) % 60;
        }

        public new void UpdateState()
        {
            if (CheckCollisionPointRec(GetMousePosition(), GetRectangle()))
            {
                focus = true;
                SetMouseCursor(MouseCursor.IBeam);

                int key = GetCharPressed();

                while (key > 0 && Text.Length < maxCharLength)
                {
                    if (key >= 32 && key <= 125)
                    {
                        Text += (char)key;
                    }
                    key = GetCharPressed();
                }

                if (IsKeyPressed(KeyboardKey.Backspace))
                {
                    if (Text.Length > 0)
                        Text = Text.Remove(Text.Length - 1);
                }
            }
            else
            {
                if (focus)
                {
                    focus = false;
                    SetMouseCursor(MouseCursor.Default);
                }
            } 
        }

    }
}

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
    internal class TextBox(int screenWidth, int screenHeight, int x, int y, int width, int height, int fontSize, TwoColorPalette normalPalette, TwoColorPalette focusPalette) : RectangleElement(screenWidth, screenHeight, x, y, width, height)
    {
        protected bool focus = false;
        private string text = "";
        public string Text { get => this.text; set => this.text = value; }

        public void Draw()
        {
            TwoColorPalette palette = focus ? focusPalette : normalPalette;
            base.Draw(palette.BackgroundColor);
            DrawRectangleLinesEx(GetRectangle(), 5, palette.DetailColor);
            DrawText(Text, x - MeasureText(Text, fontSize) / 2, y - fontSize / 2, fontSize, palette.DetailColor);
        }

        public void UpdateState()
        {
            if (CheckCollisionPointRec(GetMousePosition(), GetRectangle()))
            {
                focus = true;
                SetMouseCursor(MouseCursor.IBeam);
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

        public void ClearText()
        {
            this.Text = "";
        }
    }
}

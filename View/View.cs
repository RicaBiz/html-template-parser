using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Windows.Forms;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Color = Raylib_cs.Color;

namespace html_template_parser.View
{
    struct TwoColorPalette(Color backgroundColor, Color detailColor)
    {
        public Color BackgroundColor = backgroundColor;
        public Color DetailColor = detailColor;
    }

    internal class View
    {
        private const int lineSpacing = 25;

        private static int screenWidth = 1500;
        private static int screenHeight = 1000;
        private const int targetFPS = 60;

        private const int padding = 20;

        private const int defaultTextFontSize = 40;
        private static Color defaultTextColor = Color.DarkPurple;
        private const int defaultLabelFontSize = defaultTextFontSize - 5;
        private const int defaultButtonWidth = 300;
        private const int defaultButtonHeight = 100;
        private const int defaultButtonFontSize = 50;
        private static TwoColorPalette defaultButtonPalette = new(Color.Blue, Color.LightGray);
        private static TwoColorPalette defaultButtonPressedPalette = new(Color.DarkPurple, Color.LightGray);
        private static TwoColorPalette defaultButtonHoverPalette = new(Color.DarkBlue, Color.RayWhite);
        private const int defaultTextBoxWidth = 300;
        private const int defaultTextBoxHeight = 50;
        private const int defaultTextBoxFontSize = 30;
        private static TwoColorPalette defaultTextBoxPalette = new(Color.LightGray, Color.DarkPurple);
        private static TwoColorPalette defaultTextBoxFocusPalette = new(Color.RayWhite, Color.Blue);
        private const int defaultInputTextBoxMaxChars = 30;
        private const int defaultCheckBoxEdgeLength = 50;

        //File Specification Section
        private const int importButtonFontSize = 30;
        private const int importButtonWidth = 150;
        private const int importButtonHeight = 50;
        private const int clearButtonFontSize = 20;
        private const int clearButtonWidth = 120;
        private const int clearButtonHeight = 40;
        internal class ComponentTemplates
        {
            public static Button ImportButton(int posX, int posY) =>
                new(screenWidth, screenHeight, posX, posY, importButtonWidth, importButtonHeight, "import", importButtonFontSize, defaultButtonPalette, defaultButtonPressedPalette, defaultButtonHoverPalette);
            public static Button ClearButton(int posX, int posY) =>
                new(screenWidth, screenHeight, posX, posY, clearButtonWidth, clearButtonHeight, "clear", clearButtonFontSize, defaultButtonPalette, defaultButtonPressedPalette, defaultButtonHoverPalette);
            public static TextBox TextBox(int posX, int posY) =>
                new(screenWidth, screenHeight, posX, posY, defaultTextBoxWidth, defaultTextBoxHeight, defaultTextBoxFontSize, defaultTextBoxPalette, defaultTextBoxFocusPalette);
            public static InputTextBox InputTextBox(int posX, int posY) =>
                new InputTextBox(screenWidth, screenHeight, posX, posY, defaultTextBoxWidth, defaultTextBoxHeight, defaultInputTextBoxMaxChars, defaultTextBoxFontSize, defaultTextBoxPalette, defaultTextBoxFocusPalette);
        }

        private Button pageTemplateImportButton = ComponentTemplates.ImportButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) / 10 - importButtonHeight / 2);
        private Button headerImportButton = ComponentTemplates.ImportButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 3 / 10 - importButtonHeight / 2);
        private Button footerImportButton = ComponentTemplates.ImportButton(screenWidth / 3 -importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 5 / 10 - importButtonHeight / 2);
        private Button articleImportButton = ComponentTemplates.ImportButton(screenWidth / 3 -importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 7 / 10 - importButtonHeight / 2);
        private Button filenameImportButton = ComponentTemplates.ImportButton(screenWidth / 3 -importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 9 / 10 - importButtonHeight / 2);
        private Button pageTemplateClearButton = ComponentTemplates.ClearButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) / 10 + clearButtonHeight / 2);
        private Button headerClearButton = ComponentTemplates.ClearButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 3 / 10 + clearButtonHeight / 2);
        private Button footerClearButton = ComponentTemplates.ClearButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 5 / 10 + clearButtonHeight / 2);
        private Button articleClearButton = ComponentTemplates.ClearButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight - defaultTextFontSize) * 7 / 10 + clearButtonHeight / 2);
        private Button filenameClearButton = ComponentTemplates.ClearButton(screenWidth / 3 - importButtonWidth / 2 - 10, (screenHeight -defaultTextFontSize) * 9 / 10 + clearButtonHeight / 2);
        private TextBox pageTemplateTextBox = ComponentTemplates.TextBox(padding + defaultTextBoxWidth / 2, (screenHeight - defaultTextFontSize) / 10);
        private TextBox headerTextBox = ComponentTemplates.TextBox(padding + defaultTextBoxWidth / 2, (screenHeight - defaultTextFontSize) * 3 / 10);
        private TextBox footerTextBox = ComponentTemplates.TextBox(padding + defaultTextBoxWidth / 2, (screenHeight - defaultTextFontSize) * 5 / 10);
        private TextBox articleTextBox = ComponentTemplates.TextBox(padding + defaultTextBoxWidth / 2, (screenHeight - defaultTextFontSize) * 7 / 10);
        private InputTextBox filenameTextBox = ComponentTemplates.InputTextBox(padding + defaultTextBoxWidth / 2, (screenHeight - defaultTextFontSize) * 9 / 10);

        //Draw Options Section
        private CheckBox pageTemplateCheckBox = new(screenWidth, screenHeight, screenWidth * 2 / 3 - defaultCheckBoxEdgeLength / 2 - padding, (screenHeight - defaultTextFontSize) / 6, defaultCheckBoxEdgeLength, defaultTextBoxPalette);
        private CheckBox headerCheckBox = new(screenWidth, screenHeight, screenWidth * 2 / 3 - defaultCheckBoxEdgeLength / 2 - padding, (screenHeight - defaultTextFontSize) * 2 / 6, defaultCheckBoxEdgeLength, defaultTextBoxPalette);
        private CheckBox footerCheckBox = new(screenWidth, screenHeight, screenWidth * 2 / 3 - defaultCheckBoxEdgeLength / 2 - padding, (screenHeight - defaultTextFontSize) * 3 / 6, defaultCheckBoxEdgeLength, defaultTextBoxPalette);
        private CheckBox articleCheckBox = new(screenWidth, screenHeight, screenWidth * 2 / 3 - defaultCheckBoxEdgeLength / 2 - padding, (screenHeight - defaultTextFontSize) * 4 / 6, defaultCheckBoxEdgeLength, defaultTextBoxPalette);
        private InputTextBox pageTitleTextBox = new InputTextBox(screenWidth, screenHeight, screenWidth / 2, screenHeight * 5 / 6 - defaultTextBoxHeight / 2, defaultTextBoxWidth * 3 / 2, defaultTextBoxHeight, defaultInputTextBoxMaxChars, defaultTextBoxFontSize, defaultTextBoxPalette, defaultTextBoxFocusPalette);
        private Button runScriptButton = new(screenWidth, screenHeight, screenWidth / 2, screenHeight - defaultButtonHeight / 2 - padding, defaultButtonWidth, defaultButtonHeight, "Run Script", defaultButtonFontSize, defaultButtonPalette, defaultButtonPressedPalette, defaultButtonHoverPalette);

        //Status Message Box
        private List<String> messages = [];
        private const int maxMessages = 30;
        private const int messagesFontSize = 20;

        public View()
        {
            SetConfigFlags(ConfigFlags.ResizableWindow);
            InitWindow(screenWidth, screenHeight, "HTML Template Parser");
            int display = GetCurrentMonitor();
            SetWindowSize(GetMonitorWidth(display) - 100, GetMonitorHeight(display) - 100);
            SetTargetFPS(targetFPS);
        }
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public bool Update()
        {
            if (WindowShouldClose())
                return false;

            BeginDrawing();
            DrawScreen();
            EndDrawing();

            CheckCommand();
            UpdateWindowSize();
            //fpsCount = ++fpsCount % targetFPS;
            return true;
        }

        private void UpdateWindowSize()
        {
            if (GetScreenWidth() != screenWidth || GetScreenHeight() != screenHeight)
            {
                screenWidth = GetScreenWidth();
                screenHeight = GetScreenHeight();
            }
        }
        private void DrawScreen()
        {
            ClearBackground(Color.RayWhite);
            DrawText("HTML Template Parser", screenWidth / 2 - MeasureText("HTML Template Parser", defaultTextFontSize) / 2, 5, defaultTextFontSize, defaultTextColor);
            //Draw Separation Lines
            DrawLine(screenWidth / 3, defaultTextFontSize, screenWidth / 3, screenHeight, Color.DarkGray);
            DrawLine(screenWidth * 2 / 3, defaultTextFontSize, screenWidth * 2 / 3, screenHeight, Color.DarkGray);

            //Draw File Specification Section
            DrawText("Page Template", padding, (screenHeight - defaultTextFontSize) / 10 - defaultTextBoxHeight / 2 - defaultLabelFontSize, defaultLabelFontSize, defaultTextColor);
            DrawText("Header", padding, (screenHeight - defaultTextFontSize) * 3 / 10 - defaultTextBoxHeight / 2 - defaultLabelFontSize, defaultLabelFontSize, defaultTextColor);
            DrawText("Footer", padding, (screenHeight - defaultTextFontSize) * 5 / 10 - defaultTextBoxHeight / 2 - defaultLabelFontSize, defaultLabelFontSize, defaultTextColor);
            DrawText("Article", padding, (screenHeight - defaultTextFontSize) * 7 / 10 - defaultTextBoxHeight / 2 - defaultLabelFontSize, defaultLabelFontSize, defaultTextColor);
            DrawText("File Name", padding, (screenHeight - defaultTextFontSize) * 9 / 10 - defaultTextBoxHeight / 2 - defaultLabelFontSize, defaultLabelFontSize, defaultTextColor);
            pageTemplateTextBox.Draw();
            headerTextBox.Draw();
            footerTextBox.Draw();
            articleTextBox.Draw();
            filenameTextBox.Draw();
            pageTemplateImportButton.Draw();
            headerImportButton.Draw();
            footerImportButton.Draw();
            articleImportButton.Draw();
            filenameImportButton.Draw();
            pageTemplateClearButton.Draw();
            headerClearButton.Draw();
            footerClearButton.Draw();
            articleClearButton.Draw();
            filenameClearButton.Draw();



            //Draw Options Section
            pageTemplateCheckBox.Draw();
            footerCheckBox.Draw();
            headerCheckBox.Draw();
            articleCheckBox.Draw();
            pageTitleTextBox.Draw();
            DrawText("Page Template", screenWidth * 2 / 3 - defaultCheckBoxEdgeLength - padding * 2 - MeasureText("Page Template", defaultLabelFontSize), (screenHeight - defaultTextFontSize) / 6 - defaultLabelFontSize / 2, defaultLabelFontSize, defaultTextColor);
            DrawText("Header", screenWidth * 2 / 3 - defaultCheckBoxEdgeLength - padding * 2 - MeasureText("Header", defaultLabelFontSize), (screenHeight - defaultTextFontSize) * 2 / 6 - defaultLabelFontSize / 2, defaultLabelFontSize, defaultTextColor);
            DrawText("Footer", screenWidth * 2 / 3 - defaultCheckBoxEdgeLength - padding * 2 - MeasureText("Footer", defaultLabelFontSize), (screenHeight - defaultTextFontSize) * 3 / 6 - defaultLabelFontSize / 2, defaultLabelFontSize, defaultTextColor);
            DrawText("Article", screenWidth * 2 / 3 - defaultCheckBoxEdgeLength - padding * 2 - MeasureText("Article", defaultLabelFontSize), (screenHeight - defaultTextFontSize) * 4 / 6 - defaultLabelFontSize / 2, defaultLabelFontSize, defaultTextColor);
            DrawText("Page Title", screenWidth / 2 - MeasureText("Page Title", defaultLabelFontSize) / 2, screenHeight * 5 / 6 - defaultTextBoxHeight / 2 - defaultLabelFontSize - padding, defaultLabelFontSize, defaultTextColor);
            DrawText("Options", screenWidth / 2 - MeasureText("Options", defaultTextFontSize) / 2, defaultTextFontSize + lineSpacing, defaultTextFontSize, defaultTextColor);
            DrawLine(screenWidth / 3 + padding, screenHeight * 5 / 6 - defaultTextBoxHeight - defaultTextFontSize - padding, screenWidth * 2 / 3 - padding, screenHeight * 5 / 6 - defaultTextBoxHeight - defaultTextFontSize - padding, Color.DarkGray);
            runScriptButton.Draw();

            //Draw Status Message Box
            DrawRectangleLinesEx(new(screenWidth * 2 / 3 + padding, defaultTextFontSize + padding, screenWidth / 3 - padding * 2, screenHeight - defaultTextFontSize - padding * 2), 5, defaultTextBoxPalette.DetailColor);
            int i = 0;
            while (messages.Count > maxMessages)
            {
                messages.RemoveAt(0);
            }
            foreach (string message in messages)
            {
                DrawText(message, screenWidth * 2 / 3 + padding * 2,  defaultTextFontSize + padding * 2 + i++ * lineSpacing, messagesFontSize, defaultTextColor);
            }
        }

        private void CheckCommand()
        {
            //File Specification Section
            if (pageTemplateImportButton.UpdateState())
            {
                String pageTemplateFilename = SelectHtml();
                pageTemplateTextBox.Text = pageTemplateFilename;
                messages.Add("Selected Page Template: " + pageTemplateFilename);
            }
            if (headerImportButton.UpdateState())
            {
                String headerFilename = SelectHtml();
                headerTextBox.Text = headerFilename;
                messages.Add("Selected Header: " + headerFilename);
            }
            if (footerImportButton.UpdateState())
            {
                String footerFilename = SelectHtml();
                footerTextBox.Text = footerFilename;
                messages.Add("Selected Footer: " + footerFilename);
            }
            if (articleImportButton.UpdateState())
            {
                String articleFilename = SelectTxt();
                articleTextBox.Text = articleFilename;
                messages.Add("Selected Article: " + articleFilename);
            }
            if (filenameImportButton.UpdateState())
            {
                String filename = SelectHtml();
                filenameTextBox.Text = filename;
                messages.Add("Selected Output File: " + filename);
            }
            if (pageTemplateClearButton.UpdateState())
            {
                pageTemplateTextBox.ClearText();
                messages.Add("Cleared Page Template");
            }
            if (headerClearButton.UpdateState())
            {
                headerTextBox.ClearText();
                messages.Add("Cleared Header");
            }
            if (footerClearButton.UpdateState())
            {
                footerTextBox.ClearText();
                messages.Add("Cleared Footer");
            }
            if (articleClearButton.UpdateState())
            {
                articleTextBox.ClearText();
                messages.Add("Cleared Article");
            }
            if (filenameClearButton.UpdateState())
            {
                filenameTextBox.ClearText();
                messages.Add("Cleared File Name");
            }
            pageTemplateTextBox.UpdateState();
            headerTextBox.UpdateState();
            footerTextBox.UpdateState();
            articleTextBox.UpdateState();
            filenameTextBox.UpdateState();

            //Options Section
            pageTemplateCheckBox.UpdateState();
            headerCheckBox.UpdateState();
            footerCheckBox.UpdateState();
            articleCheckBox.UpdateState();
            pageTitleTextBox.UpdateState();
            if (runScriptButton.UpdateState())
            {
                if (!pageTemplateCheckBox.IsChecked && !headerCheckBox.IsChecked && !footerCheckBox.IsChecked && !articleCheckBox.IsChecked)
                {
                    messages.Add("No options selected!");
                    return;
                }
                if (filenameTextBox.Text == "")
                {
                    messages.Add("Output File not specified!");
                    return;
                }
                if (pageTemplateCheckBox.IsChecked)
                {
                    if (pageTemplateTextBox.Text == "")
                    {
                        messages.Add("Page Template not specified!");
                        return;
                    }
                    if (pageTitleTextBox.Text == "")
                    {
                        messages.Add("Page Title not specified!");
                        return;
                    }
                    Script.CreatePageTemplate(filenameTextBox.Text, pageTemplateTextBox.Text, pageTitleTextBox.Text);
                }
                if (headerCheckBox.IsChecked)
                {
                    if (headerTextBox.Text == "")
                    {
                        messages.Add("Header not specified!");
                        return;
                    }
                    Script.AddHeaderAndFooter(filenameTextBox.Text, headerTextBox.Text);
                }
                if (footerCheckBox.IsChecked)
                {
                    if (footerTextBox.Text == "")
                    {
                        messages.Add("Footer not specified!");
                        return;
                    }
                    Script.AddFooter(filenameTextBox.Text, footerTextBox.Text);
                }
                if (articleCheckBox.IsChecked)
                {
                    if (articleTextBox.Text == "")
                    {
                        messages.Add("Article not specified!");
                        return;
                    }
                    Script.AddArticle(filenameTextBox.Text, articleTextBox.Text);
                }
            }
        }
        private String SelectHtml()
        {
            return SelectFile("html");
        }
        private String SelectTxt()
        {
            return SelectFile("txt");
        }
        private String SelectFile(String extension)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select file",
                Filter = extension + " Files (*." + extension + ")|*." + extension
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SafeFileName;
            }
            return "";
        }
    }
}

using html_template_parser.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace html_template_parser
{
    internal class Program
    {
        private static View.View view = new();

        [STAThread]
        public static void Main()
        {
            while (view.Update()) ;
            view.CloseWindow();
        }
    }
}

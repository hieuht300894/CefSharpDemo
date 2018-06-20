using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CefSharpDemo.Model
{
    public class ActionData
    {
        public Control Control { get; set; }
        public Action<ChromiumWebBrowser> Action { get; set; }
    }
}

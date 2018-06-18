using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.BLL
{
    public static class ChromeHandle
    {
        public static void Init(this ChromiumWebBrowser browser)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("function triggerMouseEvent(node, eventType) {");
            sbScript.AppendLine("    var clickEvent = document.createEvent('MouseEvents');");
            sbScript.AppendLine("    clickEvent.initEvent(eventType, true, true);");
            sbScript.AppendLine("    node.dispatchEvent(clickEvent);");
            sbScript.AppendLine("}");

            browser.ExecuteScriptAsync(sbScript.ToString());
        }
    }
}

using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.BLL
{
    public static class MouseHandle
    {
        public static JavascriptResponse InitEventClick(this ChromiumWebBrowser browser)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("function triggerMouseEvent(node, eventType) {");
            sbScript.AppendLine("    var clickEvent = document.createEvent('MouseEvents');");
            sbScript.AppendLine("    clickEvent.initEvent(eventType, true, true);");
            sbScript.AppendLine("    node.dispatchEvent(clickEvent);");
            sbScript.AppendLine("}");

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse SendClickById(this ChromiumWebBrowser browser, string id)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.getElementById('{id}'), 'click');").Result;
        }
        public static JavascriptResponse SendClickByName(this ChromiumWebBrowser browser, string name)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.getElementById('{name}'), 'click');").Result;
        }
        public static JavascriptResponse SendClickByClassName(this ChromiumWebBrowser browser, string name)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.getElementsByClassName('{name}')[0], 'click');").Result;
        }
    }
}

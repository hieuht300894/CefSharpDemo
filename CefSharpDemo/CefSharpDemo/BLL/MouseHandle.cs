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
        public static JavascriptResponse InitEventClick(this ChromiumWebBrowser browser, int x, int y)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine($"function triggerMouseEvent(node, eventType, {x}, {y}) {{");
            sbScript.AppendLine("    var clickEvent = document.createEvent('MouseEvents');");
            sbScript.AppendLine("    clickEvent.initEvent(eventType, true, true);");
            sbScript.AppendLine("    node.dispatchEvent(clickEvent);");
            sbScript.AppendLine("}");

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse SendClickById(this ChromiumWebBrowser browser, string value)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.querySelector('[id={value}]'), 'click');").Result;
        }
        public static JavascriptResponse SendClickByName(this ChromiumWebBrowser browser, string value)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.querySelector('[name={value}]'), 'click');").Result;
        }
        public static JavascriptResponse SendClickByClassName(this ChromiumWebBrowser browser, string value)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.querySelector('[class={value}]'), 'click');").Result;
        }
        public static JavascriptResponse SendClickBy(this ChromiumWebBrowser browser, string tagName, string attrName, string value)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.querySelector('{tagName}[{attrName}={value}]'), 'click');").Result;
        }
        public static JavascriptResponse SendClickBy(this ChromiumWebBrowser browser, string script)
        {
            return browser.EvaluateScriptAsync($"triggerMouseEvent(document.querySelector('{script}'), 'click');").Result;
        }
    }
}

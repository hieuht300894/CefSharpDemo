using CefSharp;
using CefSharp.WinForms;
using CefSharpDemo.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.BLL
{
    public static class MouseHandle
    {
        public static JavascriptResponse InitMouseHandle(this ChromiumWebBrowser browser)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("function MouseHandle(element, eventType) {");
            sbScript.AppendLine("    var clickEvent = document.createEvent('MouseEvents');");
            sbScript.AppendLine("    clickEvent.initEvent(eventType, true, true);");
            sbScript.AppendLine("    element.dispatchEvent(clickEvent);");
            sbScript.AppendLine("    console.log(eventType);");
            sbScript.AppendLine("}");

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse SendMouseHandleById(this ChromiumWebBrowser browser, string eventType, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('[id={value}]'), '{eventType}');").Result;
        }
        public static JavascriptResponse SendMouseHandleByName(this ChromiumWebBrowser browser, string eventType, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('[name={value}]'), '{eventType}');").Result;
        }
        public static JavascriptResponse SendMouseHandleByClassName(this ChromiumWebBrowser browser, string eventType, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('[class={value}]'), '{eventType}');").Result;
        }
        public static JavascriptResponse SendMouseHandle(this ChromiumWebBrowser browser, string eventType, string tagName, string attrName, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('{tagName}[{attrName}={value}]'), '{eventType}');").Result;
        }
        public static JavascriptResponse SendMouseHandle(this ChromiumWebBrowser browser, string eventType, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('{value}'), '{eventType}');").Result;
        }

        public static void InitMouseHandlePoint(this ChromiumWebBrowser browser)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("function MouseHandlePoint(element, eventType, clientX, clientY) {");
            sbScript.AppendLine("    var event = document.createEvent('MouseEvents');");
            sbScript.AppendLine("    var _element = document.elementFromPoint(clientX, clientY);");
            sbScript.AppendLine("    event.initMouseEvent(");
            sbScript.AppendLine("    /*type*/ eventType,");
            sbScript.AppendLine("    /*canBubble*/ true,");
            sbScript.AppendLine("    /*cancelable*/ true,");
            sbScript.AppendLine("    /*view*/ window,");
            sbScript.AppendLine("    /*detail*/ 0,");
            sbScript.AppendLine("    /*screenX*/ 0,");
            sbScript.AppendLine("    /*screenY*/ 0,");
            sbScript.AppendLine("    /*clientX*/ clientX,");
            sbScript.AppendLine("    /*clientY*/ clientY,");
            sbScript.AppendLine("    /*ctrlKey*/ false,");
            sbScript.AppendLine("    /*altKey*/ false,");
            sbScript.AppendLine("    /*shiftKey*/ false,");
            sbScript.AppendLine("    /*metaKey*/ false,");
            sbScript.AppendLine("    /*button*/ 3,");
            sbScript.AppendLine("    /*relatedTarget*/ null);");
            sbScript.AppendLine("    _element.dispatchEvent(event);");
            sbScript.AppendLine("    console.log(eventType);");
            sbScript.AppendLine("}");

            var result = browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static void SendMouseHandle(this ChromiumWebBrowser browser, string eventType, int x, int y)
        {
            var result = browser.EvaluateScriptAsync($"MouseHandlePoint(document, '{eventType}', {x}, {y});").Result;
        }
        public static void SendMouseHandleById(this ChromiumWebBrowser browser, string eventType, string value, int x, int y)
        {
            var result = browser.EvaluateScriptAsync($"MouseHandlePoint(document.querySelector('[id={value}]'), '{eventType}', {x}, {y});").Result;
        }
    }
}

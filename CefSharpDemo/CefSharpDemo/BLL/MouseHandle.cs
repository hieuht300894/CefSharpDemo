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
            sbScript.AppendLine("    clickEvent.initMouseEvent(eventType, true, true);");
            sbScript.AppendLine("    element.dispatchEvent(clickEvent);");
            sbScript.AppendLine("    console.log(eventType);");
            sbScript.AppendLine("}");

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse SendMouseHandle(this ChromiumWebBrowser browser, string eventType, string value)
        {
            return browser.EvaluateScriptAsync($"MouseHandle(document.querySelector('{value}'), '{eventType}');").Result;
        }

        public static JavascriptResponse InitMouseHandlePoint(this ChromiumWebBrowser browser)
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

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse SendMouseHandle(this ChromiumWebBrowser browser, string eventType, int x, int y)
        {
            return browser.EvaluateScriptAsync($"MouseHandlePoint(document, '{eventType}', {x}, {y});").Result;
        }
    }
}

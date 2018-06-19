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
            sbScript.AppendLine("    console.log(eventType);");
            sbScript.AppendLine("}");

            return browser.EvaluateScriptAsync(sbScript.ToString()).Result;
        }
        public static JavascriptResponse InitEventClickPoint(this ChromiumWebBrowser browser)
        {
            StringBuilder sbScript = new StringBuilder();
            sbScript.AppendLine("function MouseHandle(element, eventType, clientX, clientY) {");
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
        public static void SendMouseDown(this ChromiumWebBrowser browser, int x, int y)
        {
            browser.ExecuteScriptAsync($"MouseHandle(document, 'mousedown', {x}, {y});");
        }
        public static void SendMouseMove(this ChromiumWebBrowser browser, int x, int y)
        {
            browser.ExecuteScriptAsync($"MouseHandle(document, 'mousemove', {x}, {y});");
        }
    }
}

using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.BLL
{
    public static class InputHandle
    {
        public static JavascriptResponse SendTextById(this ChromiumWebBrowser browser, string id, string value)
        {
            return browser.EvaluateScriptAsync($"$('#{id}').val('{value}');").Result;
        }
        public static JavascriptResponse SendTextByName(this ChromiumWebBrowser browser, string name, string value)
        {
            return browser.EvaluateScriptAsync($"$('#{name}').val('{value}');").Result;
        }
        public static JavascriptResponse SendText(this ChromiumWebBrowser browser, string query, string value)
        {
            return browser.EvaluateScriptAsync($"document.querySelector('{query}').value = '{value}';").Result;
        }
    }
}

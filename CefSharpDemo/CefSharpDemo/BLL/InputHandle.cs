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
        public static JavascriptResponse SendText(this ChromiumWebBrowser browser, string query, string value)
        {
            return browser.EvaluateScriptAsync($"document.querySelector('{query}').value = '{value}';").Result;
        }
    }
}
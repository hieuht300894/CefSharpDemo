using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CefSharpDemo.General
{
    public static class Extension
    {
        public static void InitDocument(this XmlDocument xmlDoc)
        {
            xmlDoc.LoadXml($"<{Define.Page}></{Define.Page}>");

            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.InsertBefore(xmlDec, xmlDoc.DocumentElement);
        }
    }
}

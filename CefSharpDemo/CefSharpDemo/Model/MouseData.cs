using CefSharpDemo.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CefSharpDemo.Model
{
    public class MouseData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public static List<MouseData> GetData()
        {
            List<MouseData> lstResult = new List<MouseData>();
            lstResult.Add(new MouseData() { ID = nameof(Define.Click), Name = "Click", Value = "click" });
            lstResult.Add(new MouseData() { ID = nameof(Define.DblClick), Name = "Double Click", Value = "dblclick" });
            lstResult.Add(new MouseData() { ID = nameof(Define.MouseDown), Name = "Mouse Down", Value = "mousedown" });
            lstResult.Add(new MouseData() { ID = nameof(Define.MouseMove), Name = "Mouse Move", Value = "mousemove" });
            lstResult.Add(new MouseData() { ID = nameof(Define.MouseUp), Name = "Mouse Up", Value = "mouseup" });
            lstResult.Add(new MouseData() { ID = nameof(Define.MouseOver), Name = "Mouse Over", Value = "mouseover" });
            lstResult.Add(new MouseData() { ID = nameof(Define.MouseOut), Name = "Mouse Out", Value = "mouseout" });
            return lstResult;
        }
    }
}

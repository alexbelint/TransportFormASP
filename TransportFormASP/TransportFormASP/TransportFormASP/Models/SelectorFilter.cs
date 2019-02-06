using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    //public class SelectorFilter
    //{
    //    public string Column { get; set; }
    //    public string Value { get; set; }
    //    public bool Editing { get; set; }
    //    public SelectorTable? Table { get; set; }
    //}
    public class SelectorFilter
    {
        public string Column { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Editing { get; set; }
        public SelectorTable? Table { get; set; }
    }
}
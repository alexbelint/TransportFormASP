using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TransportFormASP.Models
{
    public class Filter
    {
        public string Column { get; set; }
        public string Value { get; set; }
        public Table Table { get; set; }
        public bool Editing { get; set; }
    }
}
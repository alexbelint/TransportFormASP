using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookGNG
    {
        [Key]
        public Guid idRefBookGNG { get; set; }
        public DateTime DateDownload { get; set; }
        public string Kod { get; set; }
        public string Name { get; set; }
        public string ClassETT { get; set; }
        public string KodETSNG { get; set; }
        public string ETnPos { get; set; }
        public string PID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
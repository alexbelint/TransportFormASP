using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookETSNG
    {
        [Key]
        public Guid idRefBookETSNG { get; set; }
        public DateTime DateDownload { get; set; }
        public string Kod { get; set; }
        public string Name { get; set; }
        public string ClassN { get; set; }
        public string MinNew { get; set; }
        public string KodGNG8 { get; set; }
        public string PID { get; set; }

        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookOwnFirm
    {
        [Key]
        public Guid idRefBookOwnFirm { get; set; }
        public DateTime DateDownload { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
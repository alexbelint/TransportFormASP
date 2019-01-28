using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookStatus
    {
        [Key]
        public Guid idRefBookStatus { get; set; }
        public string NameStatus { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
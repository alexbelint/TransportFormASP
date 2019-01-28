using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookOwner
    {
        [Key]
        public Guid idRefBookOwner { get; set; }
        public DateTime DateDownload { get; set; }
        public string OwnerId { get; set; }
        public string OwnerDsc { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
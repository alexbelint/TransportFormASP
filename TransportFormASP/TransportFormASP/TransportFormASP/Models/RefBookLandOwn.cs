using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookLandOwn
    {
        [Key]
        public Guid idRefBookLandOwn { get; set; }
        public DateTime DateDownload { get; set; }
        public string LandId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
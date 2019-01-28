using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookOtpr
    {
        [Key]
        public Guid idRefBookOtpr { get; set; }
        public DateTime DateDownload { get; set; }
        public string OtprId { get; set; }
        public string SendId { get; set; }
        public string OtprN { get; set; }
        public string SendN { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
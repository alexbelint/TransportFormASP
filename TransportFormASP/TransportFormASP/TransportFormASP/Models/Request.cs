using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class Request
    {
        [Key]
        public Guid idRequest { get; set; }

        public Guid idRefBookStatus { get; set; }
        public virtual RefBookStatus RefBookStatus { get; set; }

        public int NumberRequest { get; set; }
        public DateTime DateRequestInput { get; set; }

        public Guid idRefBookClientOld { get; set; }
        public string RequestNote { get; set; }

        public Guid idRefBookOfficer { get; set; }
        public virtual RefBookOfficer RefBookOfficer { get; set; }

        public Guid idRefBookClient { get; set; }
        public virtual RefBookClient RefBookClient { get; set; }

        public DateTime DateBeginRequest { get; set; }
        public DateTime DateEndRequest { get; set; }

        public virtual ICollection<RequestSp> RequestSp { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookClient
    {
        [Key]
        public Guid idRefBookClient { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string UNN { get; set; }
        public Guid idRefBookLand { get; set; }
        public string AddressLegal { get; set; }
        public string DirectorPositionIP { get; set; }
        public string DirectorSurnameIP { get; set; }
        public string BookerPositionIP { get; set; }
        public string BookerSurnameIP { get; set; }
        public string DirectorSurnameRP { get; set; }
        public string DirectorPositionRP { get; set; }
        public string BankAccount { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string BankCity { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<RequestSp> idReceiptVirt { get; set; }
        public virtual ICollection<RequestSp> idSenderVirt { get; set; }
    }
}
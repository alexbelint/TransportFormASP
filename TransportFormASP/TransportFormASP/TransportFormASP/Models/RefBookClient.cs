
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookClient()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
            this.TransportationRequest1 = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRefBookClient { get; set; }
        [Display(Name = "Клиент")]
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string UNN { get; set; }
        public Nullable<System.Guid> idRefBookLand { get; set; }
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest1 { get; set; }
        public virtual RefBookLand RefBookLand { get; set; }
        public virtual RefBookLand RefBookLand1 { get; set; }
    }
}


namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookLand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookLand()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
            this.TransportationRequest1 = new HashSet<TransportationRequest>();
            this.RefBookClient = new HashSet<RefBookClient>();
            this.RefBookClient1 = new HashSet<RefBookClient>();
        }
    
        public System.Guid idRefBookLand { get; set; }
        public System.DateTime DateDownload { get; set; }
        [Display(Name = "Код страны")]
        public string LandId { get; set; }
        [Display(Name = "Страна")]
        public string LName { get; set; } //название страны
        public string RName { get; set; }
        public string Land_Int { get; set; }
        public string Land_OSJD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefBookClient> RefBookClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefBookClient> RefBookClient1 { get; set; }
    }
}

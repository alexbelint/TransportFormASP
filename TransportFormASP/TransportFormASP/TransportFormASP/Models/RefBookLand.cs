//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    
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
        public string LandId { get; set; }
        public string LName { get; set; }
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

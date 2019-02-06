
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RailwayDispatch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RailwayDispatch()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRailwayDispatch { get; set; }
        [Display(Name = "Вид отправки")]
        public string DispatchType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
    }
}

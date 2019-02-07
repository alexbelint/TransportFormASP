
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookETSNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookETSNG()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRefBookETSNG { get; set; }
        public System.DateTime DateDownload { get; set; }
        [Display(Name = "Код ЕТСНГ")]
        public string Kod { get; set; }
        [Display(Name = "Наименование ЕТСНГ")]
        public string Name { get; set; }
        public string ClassN { get; set; }
        public string MinNew { get; set; }
        public string KodGNG8 { get; set; }
        public string PID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
    }
}

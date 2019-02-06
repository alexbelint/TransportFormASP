
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookGNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookGNG()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRefBookGNG { get; set; }
        public System.DateTime DateDownload { get; set; }
        [Display(Name = "ส๎ไ รอร")]
        public string Kod { get; set; }
        [Display(Name = "ร๐๓็ รอร")]
        public string Name { get; set; }
        public string ClassETT { get; set; }
        public string KodETSNG { get; set; }
        public string ETnPos { get; set; }
        public string PID { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
    }
}

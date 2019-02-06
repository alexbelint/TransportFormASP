

namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookStations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookStations()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
            this.TransportationRequest1 = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRefBookStation { get; set; }
        public System.DateTime DateDownload { get; set; }
        public string Kod { get; set; }
        public string NewCode { get; set; }
        public string Name { get; set; }
        [Display(Name = "Станция отправления")]
        public string NewName { get; set; }
        public string NewParaT { get; set; }
        public string VrParAdd { get; set; }
        public string VrParDel { get; set; }
        public string Road { get; set; }
        public string Land { get; set; }
        public string LinkCode { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string RoadID { get; set; }
        public string LandID { get; set; }
        public string RoadAbbr { get; set; }
        public string LandAbbr { get; set; }
        public string PID { get; set; }
        public string DP { get; set; }
        public string PPLand { get; set; }
        public string RegName { get; set; }
        public string OblSity { get; set; }
        public string ParagTxt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest1 { get; set; }
    }
}

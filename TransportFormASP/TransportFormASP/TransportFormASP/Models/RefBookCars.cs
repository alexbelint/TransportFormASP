
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class RefBookCars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefBookCars()
        {
            this.TransportationRequest = new HashSet<TransportationRequest>();
        }
    
        public System.Guid idRefBookCars { get; set; }
        public System.DateTime DateDownload { get; set; }
        public string CarId { get; set; }
        [Display(Name = "��� ��")]
        public string Name { get; set; }
        public string Model { get; set; }
        public string GP { get; set; }
        public string Volume { get; set; }
        public string Axis { get; set; }
        public string TareW { get; set; }
        public string CarType { get; set; }
        public string Gross { get; set; }
        public string Length { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportationRequest> TransportationRequest { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookCars
    {
        [Key]
        public Guid idRefBookCars { get; set; }
        public DateTime DateDownload { get; set; }
        public string CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string GP { get; set; }
        public string Volume { get; set; }
        public string Axis { get; set; }
        public string TareW { get; set; }
        public string CarType { get; set; }
        public string Gross { get; set; }
        public string Length { get; set; }
        public virtual ICollection<RequestSp> RequestSp { get; set; }
    }
}
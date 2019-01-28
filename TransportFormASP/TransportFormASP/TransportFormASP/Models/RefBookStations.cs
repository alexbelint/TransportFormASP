using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RefBookStations
    {
        [Key]
        public Guid idRefBookStation { get; set; }
        public DateTime DateDownload { get; set; }
        public string Kod { get; set; }
        public string NewCode { get; set; }
        public string Name { get; set; }
        public string NewName { get; set; }
        public string NewParaT { get; set; }
        public string VrParAdd { get; set; }
        public string VrParDel { get; set; }
        public string Road { get; set; }
        public string Land { get; set; }
        public string LinkCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
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

        public virtual ICollection <RequestSp> idBorderCrossFromVirt { get; set; }
        public virtual ICollection<RequestSp> idBorderCrossInVirt { get; set; }
        public virtual ICollection<RequestSp> idRefBookStationFromVirt { get; set; }
        public virtual ICollection<RequestSp> idRefBookStationToVirt { get; set; }
    }
}
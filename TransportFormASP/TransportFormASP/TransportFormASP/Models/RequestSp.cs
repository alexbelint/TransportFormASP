using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class RequestSp
    {
        [Key]
        public Guid idRequestSp { get; set; }
      
        public Guid idRequest { get; set; }
        public virtual Request Request { get; set; }

        public Guid idRefBookStatus { get; set; }
        public virtual RefBookStatus RefBookStatus { get; set; }

        public Guid idRefBookStationFrom { get; set; }
        public virtual RefBookStations idRefBookStationFromVirt { get; set; }//**idRefBookStationFrom

        public Guid idRefBookStationTo { get; set; }
        public virtual RefBookStations idRefBookStationToVirt { get; set; }//**idRefBookStationTo

        public string TypeTransportation { get; set; }

        public Guid idRefBookOtpr { get; set; }
        public virtual RefBookOtpr RefBookOtpr { get; set; }

        public Guid idRefBookETSNG { get; set; }
        public virtual RefBookETSNG RefBookETSNG { get; set; }

        public Guid idRefBookGNG { get; set; }
        public virtual RefBookGNG RefBookGNG { get; set; }

        public double Weight { get; set; }
        public bool IsDangers { get; set; }

        public Guid idRefBookCars { get; set; }
        public virtual RefBookCars RefBookCars { get; set; }

        public Guid idRefBookOwner { get; set; }
        public virtual RefBookOwner RefBookOwner { get; set; }

        public Guid idRefBookOwnFirm { get; set; }
        public virtual RefBookOwnFirm RefBookOwnFirm { get; set; }

        public Guid idRefBookLandOwn { get; set; }
        public virtual RefBookLandOwn RefBookLandOwn { get; set; }

        public int CountCars { get; set; }
        public int CountWagon { get; set; }
        public string RequestSpNote { get; set; }
        public DateTime DateRequestSpInput { get; set; }

        public Guid idSender { get; set; }
        public virtual RefBookClient idSenderVirt { get; set; } //idSender

        public Guid idRecipient { get; set; }
        public virtual RefBookClient idReceiptVirt { get; set; } //idReceipt

        public Guid idBorderCrossFrom { get; set; }
        public virtual RefBookStations idBorderCrossFromVirt { get; set; }//idBorderCrossFrom

        public Guid idBorderCrossIn { get; set; }
        public virtual RefBookStations idBorderCrossInVirt { get; set; }//idBorderCrossIn
    }
}
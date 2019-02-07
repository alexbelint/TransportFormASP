
namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TransportationRequest
    {
        public System.Guid idTransportationRequest { get; set; }
        public System.Guid idTranshipmentMethod { get; set; }
        [Display(Name = "Период перевозки")]
        public Nullable<System.Guid> idDateMonth { get; set; }
        [Display(Name = "Страна отправления")]
        public Nullable<System.Guid> idRefBookLandFrom { get; set; }
        [Display(Name = "Страна назначения")]
        public Nullable<System.Guid> idRefBookLandTo { get; set; }
        public Nullable<System.Guid> idRefBookETSNG { get; set; }
        public Nullable<System.Guid> idRefBookGNG { get; set; }
        public string DeliveryType { get; set; }
        [Display(Name = "Станция отправления")]
        public Nullable<System.Guid> RefBookStationFrom { get; set; }
        [Display(Name = "Станция назначения")]
        public Nullable<System.Guid> RefBookStationTo { get; set; }
        [Display(Name = "Пункт отправления")]
        public string DepartuePoint { get; set; }
        [Display(Name = "Пункт назначения")]
        public string DestinationPoint { get; set; }
        public string PointAdress { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        [Display(Name = "Грузоотправитель")]
        public Nullable<System.Guid> Shipper { get; set; }
        [Display(Name = "Грузополучатель")]
        public Nullable<System.Guid> Consignee { get; set; }
        [Display(Name = "Вид отправки")]
        public Nullable<System.Guid> idRailwayDispatch { get; set; }
        [Display(Name = "Род ПС")]
        public Nullable<System.Guid> idRefBookCars { get; set; }
        [Display(Name = "Принадлежность ПС")]
        public Nullable<System.Guid> idRefBookOwner { get; set; }
        [Display(Name = "Вес груза")]
        public string Weight { get; set; }
        [Display(Name = "Количество вагонов/контейнеров")]
        public Nullable<int> CargoUnitAmmount { get; set; }
        [Display(Name = "Особые условия")]
        public Nullable<System.Guid> idSpecialCondition { get; set; }
        [Display(Name = "Примечание")]
        public string Note { get; set; }
        [Display(Name = "Номера вагонов/контейнеров")]
        public string CargoUnitNumber1 { get; set; }
    
        public virtual DateMonth DateMonth { get; set; }
        public virtual RailwayDispatch RailwayDispatch { get; set; }
        public virtual SpecialCondition SpecialCondition { get; set; }
        public virtual TranshipmentMethod TranshipmentMethod { get; set; }
        public virtual RefBookCars RefBookCars { get; set; }
        public virtual RefBookClient RefBookClient { get; set; }
        public virtual RefBookClient RefBookClient1 { get; set; }
        public virtual RefBookETSNG RefBookETSNG { get; set; }
        public virtual RefBookGNG RefBookGNG { get; set; }
        public virtual RefBookLand RefBookLand { get; set; }
        public virtual RefBookLand RefBookLand1 { get; set; }
        public virtual RefBookOwner RefBookOwner { get; set; }
        public virtual RefBookStations RefBookStations { get; set; }
        public virtual RefBookStations RefBookStations1 { get; set; }
    }
}

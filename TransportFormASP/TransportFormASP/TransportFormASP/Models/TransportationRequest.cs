namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TransportationRequest
    {
        public System.Guid idTransportationRequest { get; set; }
        [Display(Name = "Период перевозки")]
        public Nullable<System.Guid> idDateMonth { get; set; }
        [Display(Name = "Страна отправления")]
        public Nullable<System.Guid> idRefBookLandFrom { get; set; }
        [Display(Name = "Страна назначения")]
        public Nullable<System.Guid> idRefBookLandTo { get; set; }
        [Display(Name = "Код ЕТСНГ")]
        public Nullable<System.Guid> idRefBookETSNG { get; set; }
        [Display(Name = "Код ГНГ")]
        public Nullable<System.Guid> idRefBookGNG { get; set; }
        [Display(Name = "Тип перевозки")]
        public string DeliveryType { get; set; }
        [Display(Name = "Станция отправления")]
        public Nullable<System.Guid> RefBookStationFrom { get; set; }
        [Display(Name = "Станция назначения")]
        public Nullable<System.Guid> RefBookStationTo { get; set; }
        [Display(Name = "Пункт отправления")]
        public Nullable<System.Guid> idDepartuePoint { get; set; }
        [Display(Name = "Пункт назначения")]
        public Nullable<System.Guid> idDestinationPoint { get; set; }
        [Display(Name = "Порт отправления")]
        public Nullable<System.Guid> idDepartuePort { get; set; }
        [Display(Name = "Порт назначения")]
        public Nullable<System.Guid> idDestinationPort { get; set; }
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
        [Display(Name = "Вес")]
        public Nullable<double> Weight { get; set; }
        [Display(Name = "Количество вагонов/контейнеров")]
        public Nullable<int> CargoUnitAmmount { get; set; }
        [Display(Name = "Номера вагонов/контейнеров")]
        public Nullable<System.Guid> idCargoUnitNumber { get; set; }
        [Display(Name = "Особые условия")]
        public Nullable<System.Guid> idSpecialCondition { get; set; }
        [Display(Name = "Примечание")]
        public string Note { get; set; }
        [Display(Name = "Вид перевозки")]
        public System.Guid idTranshipmentMethod { get; set; }

        [Display(Name = "Количество вагонов/котейнеров")]
        public virtual CargoUnitNumber CargoUnitNumber { get; set; }
        [Display(Name = "Период перевозки")]
        public virtual DateMonth DateMonth { get; set; }
        [Display(Name = "Пункт отправления")]
        public virtual DepartuePoint DepartuePoint { get; set; }
        [Display(Name = "Пункт назначения")]
        public virtual DestinationPoint DestinationPoint { get; set; }
        [Display(Name = "Порт отправления")]
        public virtual DestinationPort DestinationPort { get; set; }
        [Display(Name = "Порт отправления")]
        public virtual DepartuePort DepartuePort1 { get; set; }
        [Display(Name = "Вид отправки")]
        public virtual RailwayDispatch RailwayDispatch { get; set; }
        [Display(Name = "Особые условия")]
        public virtual SpecialCondition SpecialCondition { get; set; }
        [Display(Name = "Род ПС")]
        public virtual RefBookCars RefBookCars { get; set; }
        [Display(Name = "Грузоотправитель")]
        public virtual RefBookClient RefBookClient { get; set; }
        [Display(Name = "Грузополучатель")]
        public virtual RefBookClient RefBookClient1 { get; set; }
        [Display(Name = "Код ЕТСНГ")]
        public virtual RefBookETSNG RefBookETSNG { get; set; }
        [Display(Name = "Код ГНГ")]
        public virtual RefBookGNG RefBookGNG { get; set; }
        [Display(Name = "Страна отправления")]
        public virtual RefBookLand RefBookLand { get; set; }
        [Display(Name = "Страна назначения")]
        public virtual RefBookLand RefBookLand1 { get; set; }
        [Display(Name = "Принадлежность ПС")]
        public virtual RefBookOwner RefBookOwner { get; set; }
        [Display(Name = "Станция отправления")]
        public virtual RefBookStations RefBookStations { get; set; }
        [Display(Name = "Станция назначения")]
        public virtual RefBookStations RefBookStations1 { get; set; }
        [Display(Name = "Вид перевозки")]
        public virtual TranshipmentMethod TranshipmentMethod { get; set; }

    }
}

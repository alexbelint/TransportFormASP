namespace TransportFormASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TransportationRequest
    {
        public System.Guid idTransportationRequest { get; set; }
        [Display(Name = "������ ���������")]
        public Nullable<System.Guid> idDateMonth { get; set; }
        [Display(Name = "������ �����������")]
        public Nullable<System.Guid> idRefBookLandFrom { get; set; }
        [Display(Name = "������ ����������")]
        public Nullable<System.Guid> idRefBookLandTo { get; set; }
        [Display(Name = "��� �����")]
        public Nullable<System.Guid> idRefBookETSNG { get; set; }
        [Display(Name = "��� ���")]
        public Nullable<System.Guid> idRefBookGNG { get; set; }
        [Display(Name = "��� ���������")]
        public string DeliveryType { get; set; }
        [Display(Name = "������� �����������")]
        public Nullable<System.Guid> RefBookStationFrom { get; set; }
        [Display(Name = "������� ����������")]
        public Nullable<System.Guid> RefBookStationTo { get; set; }
        [Display(Name = "����� �����������")]
        public Nullable<System.Guid> idDepartuePoint { get; set; }
        [Display(Name = "����� ����������")]
        public Nullable<System.Guid> idDestinationPoint { get; set; }
        [Display(Name = "���� �����������")]
        public Nullable<System.Guid> idDepartuePort { get; set; }
        [Display(Name = "���� ����������")]
        public Nullable<System.Guid> idDestinationPort { get; set; }
        [Display(Name = "����������������")]
        public Nullable<System.Guid> Shipper { get; set; }
        [Display(Name = "���������������")]
        public Nullable<System.Guid> Consignee { get; set; }
        [Display(Name = "��� ��������")]
        public Nullable<System.Guid> idRailwayDispatch { get; set; }
        [Display(Name = "��� ��")]
        public Nullable<System.Guid> idRefBookCars { get; set; }
        [Display(Name = "�������������� ��")]
        public Nullable<System.Guid> idRefBookOwner { get; set; }
        [Display(Name = "���")]
        public Nullable<double> Weight { get; set; }
        [Display(Name = "���������� �������/�����������")]
        public Nullable<int> CargoUnitAmmount { get; set; }
        [Display(Name = "������ �������/�����������")]
        public Nullable<System.Guid> idCargoUnitNumber { get; set; }
        [Display(Name = "������ �������")]
        public Nullable<System.Guid> idSpecialCondition { get; set; }
        [Display(Name = "����������")]
        public string Note { get; set; }
        [Display(Name = "��� ���������")]
        public System.Guid idTranshipmentMethod { get; set; }

        [Display(Name = "���������� �������/����������")]
        public virtual CargoUnitNumber CargoUnitNumber { get; set; }
        [Display(Name = "������ ���������")]
        public virtual DateMonth DateMonth { get; set; }
        [Display(Name = "����� �����������")]
        public virtual DepartuePoint DepartuePoint { get; set; }
        [Display(Name = "����� ����������")]
        public virtual DestinationPoint DestinationPoint { get; set; }
        [Display(Name = "���� �����������")]
        public virtual DestinationPort DestinationPort { get; set; }
        [Display(Name = "���� �����������")]
        public virtual DepartuePort DepartuePort1 { get; set; }
        [Display(Name = "��� ��������")]
        public virtual RailwayDispatch RailwayDispatch { get; set; }
        [Display(Name = "������ �������")]
        public virtual SpecialCondition SpecialCondition { get; set; }
        [Display(Name = "��� ��")]
        public virtual RefBookCars RefBookCars { get; set; }
        [Display(Name = "����������������")]
        public virtual RefBookClient RefBookClient { get; set; }
        [Display(Name = "���������������")]
        public virtual RefBookClient RefBookClient1 { get; set; }
        [Display(Name = "��� �����")]
        public virtual RefBookETSNG RefBookETSNG { get; set; }
        [Display(Name = "��� ���")]
        public virtual RefBookGNG RefBookGNG { get; set; }
        [Display(Name = "������ �����������")]
        public virtual RefBookLand RefBookLand { get; set; }
        [Display(Name = "������ ����������")]
        public virtual RefBookLand RefBookLand1 { get; set; }
        [Display(Name = "�������������� ��")]
        public virtual RefBookOwner RefBookOwner { get; set; }
        [Display(Name = "������� �����������")]
        public virtual RefBookStations RefBookStations { get; set; }
        [Display(Name = "������� ����������")]
        public virtual RefBookStations RefBookStations1 { get; set; }
        [Display(Name = "��� ���������")]
        public virtual TranshipmentMethod TranshipmentMethod { get; set; }

    }
}

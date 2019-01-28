using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TransportFormASP.Models
{
    public class AppDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public AppDBContext() : base("name=AppDBContext")
        {
        }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RequestSp> RequestSps { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookCars> RefBookCars { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookETSNG> RefBookETSNGs { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookGNG> RefBookGNGs { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookLandOwn> RefBookLandOwns { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookOtpr> RefBookOtprs { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookOwner> RefBookOwners { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookOwnFirm> RefBookOwnFirms { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.RefBookStatus> RefBookStatus { get; set; }

        public System.Data.Entity.DbSet<TransportFormASP.Models.Request> Requests { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SportskoDrustvoEntities2 : DbContext
    {
        public SportskoDrustvoEntities2()
            : base("name=SportskoDrustvoEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClanUpravnogOdbora> ClanUpravnogOdboras { get; set; }
        public virtual DbSet<GeneralniDirektor> GeneralniDirektors { get; set; }
        public virtual DbSet<Igrac> Igracs { get; set; }
        public virtual DbSet<Klub> Klubs { get; set; }
        public virtual DbSet<Predsjednik> Predsjedniks { get; set; }
        public virtual DbSet<Sacinjava> Sacinjavas { get; set; }
        public virtual DbSet<SD> SDs { get; set; }
        public virtual DbSet<SportskiDirektor> SportskiDirektors { get; set; }
        public virtual DbSet<Teren> Terens { get; set; }
        public virtual DbSet<Trener> Treners { get; set; }
        public virtual DbSet<Trening> Trenings { get; set; }
        public virtual DbSet<Uprava> Upravas { get; set; }
        public virtual DbSet<Vlada> Vladas { get; set; }
        public virtual DbSet<PogledKlubTrenerIgraci> PogledKlubTrenerIgracis { get; set; }
        public virtual DbSet<TreningView> TreningViews { get; set; }
    
        [DbFunction("SportskoDrustvoEntities2", "udfKlub_Treneri_Igraci")]
        public virtual IQueryable<udfKlub_Treneri_Igraci_Result> udfKlub_Treneri_Igraci(Nullable<int> iDKlub)
        {
            var iDKlubParameter = iDKlub.HasValue ?
                new ObjectParameter("IDKlub", iDKlub) :
                new ObjectParameter("IDKlub", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfKlub_Treneri_Igraci_Result>("[SportskoDrustvoEntities2].[udfKlub_Treneri_Igraci](@IDKlub)", iDKlubParameter);
        }
    
        [DbFunction("SportskoDrustvoEntities2", "udfTeren_Igraci")]
        public virtual IQueryable<udfTeren_Igraci_Result> udfTeren_Igraci(Nullable<int> iDTeren)
        {
            var iDTerenParameter = iDTeren.HasValue ?
                new ObjectParameter("IDTeren", iDTeren) :
                new ObjectParameter("IDTeren", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfTeren_Igraci_Result>("[SportskoDrustvoEntities2].[udfTeren_Igraci](@IDTeren)", iDTerenParameter);
        }
    
        [DbFunction("SportskoDrustvoEntities2", "udfTeren_Treneri")]
        public virtual IQueryable<udfTeren_Treneri_Result> udfTeren_Treneri(Nullable<int> iDTeren)
        {
            var iDTerenParameter = iDTeren.HasValue ?
                new ObjectParameter("IDTeren", iDTeren) :
                new ObjectParameter("IDTeren", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfTeren_Treneri_Result>("[SportskoDrustvoEntities2].[udfTeren_Treneri](@IDTeren)", iDTerenParameter);
        }
    
        [DbFunction("SportskoDrustvoEntities2", "udfTrening")]
        public virtual IQueryable<udfTrening_Result> udfTrening(Nullable<int> iDTrening)
        {
            var iDTreningParameter = iDTrening.HasValue ?
                new ObjectParameter("IDTrening", iDTrening) :
                new ObjectParameter("IDTrening", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<udfTrening_Result>("[SportskoDrustvoEntities2].[udfTrening](@IDTrening)", iDTreningParameter);
        }
    
        public virtual int uspKlub_Igraci_Treneri(Nullable<int> iDKlub, ObjectParameter return_value)
        {
            var iDKlubParameter = iDKlub.HasValue ?
                new ObjectParameter("IDKlub", iDKlub) :
                new ObjectParameter("IDKlub", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspKlub_Igraci_Treneri", iDKlubParameter, return_value);
        }
    }
}
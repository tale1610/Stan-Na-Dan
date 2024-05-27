using FluentNHibernate.Conventions.Helpers;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class NajamMapiranja : ClassMap<Najam>
    {
        public NajamMapiranja() {

            Table("NAJAM");

            Id(p => p.IdNajma, "ID_NAJMA").GeneratedBy.TriggerIdentity();

            Map(p => p.DatumPocetka,"DATUM_POCETKA");
            Map(p => p.DatumZavrsetka, "DATUM_ZAVRSETKA");
            Map(p => p.BrojDana, "BROJ_DANA");
            Map(p => p.CenaPoDanu, "CENA_PO_DANU");
            Map(p => p.CenaSaPopustom, "CENA_SA_POPUSTOM");
            Map(p => p.ZaradaOdDodatnihUsluga, "ZARADA_OD_DODATNIH_USLUGA");
            Map(p => p.UkupnaCena, "UKUPNA_CENA");
            Map(p => p.ProvizijaAgencije, "PROVIZIJA_AGENCIJE");

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad().Cascade.All();

            
            References(p => p.Agent).Column("MBR_AGENTA").LazyLoad().Cascade.All();

            References(p => p.SpoljniSaradnik)
            .Columns("MBR_AGENTA_ZA_SPOLJNOG", "ID_SPOLJNJEG_RADNIKA")//.Not.Insert().Not.Update()//ForeignKey("FK_NAJAM_SPOLJNI")//ovde ti je potencijalno pucanje ako nesto zeza
            .Cascade.All();//.NotFound.Ignore();

            

            //HasManyToMany(p => p.Sobe)
            //    .Table("IZNAJMLJENA_SOBA")
            //    .ParentKeyColumn("ID_NAJMA")
            //    .ChildKeyColumn("ID_SOBE")
            //    .Cascade.All().Inverse();
        }
    }
}

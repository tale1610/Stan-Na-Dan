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

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();

            References(p => p.Agent).Column("MBR_AGENT").LazyLoad();

            References(p => p.SpoljniSaradnik).Column("ID_Spoljnjeg_Radnika").LazyLoad();

            HasManyToMany(p => p.Sobe)
                .Table("IZNAJMLJENA_SOBA")
                .ParentKeyColumn("ID_NAJMA")
                .ChildKeyColumn("ID_SOBE")
                .Cascade.All().Inverse();
        }
    }
}

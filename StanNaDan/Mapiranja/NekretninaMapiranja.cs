using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class NekretninaMapiranja : ClassMap<Nekretnina>
    {
        public NekretninaMapiranja() {
            Table("NEKRETNINA");

            DiscriminateSubClassesOnColumn("TIP_NEKRETNINE");


            Id(p => p.IdNekretnine, "ID_NEKRETNINE").GeneratedBy.TriggerIdentity();

            Map(p => p.Kvadratura, "KVADRATURA");
            Map(p => p.BrojTerasa, "BROJ_TERASA");
            Map(p => p.BrojKupatila, "BROJ_LUPATILA");
            Map(p => p.BrojSpavacihSoba, "BROJ_SPAVACIH_SOBA");
            Map(p => p.PosedujeTV, "POSEDUJE_TV_PRIKLJUCAK");
            Map(p => p.PosedujeKuhinju, "POSEDUJE_KUHINJU");
            Map(p => p.PosedujeInternet, "POSEDUJE_INTERNET");
            Map(p => p.Ulica, "ULICA");
            Map(p => p.Broj, "BROJ");

            References(p => p.Kvart).Column("ID_KVARTA").LazyLoad();

            References(p => p.Vlasnik).Column("ID_VLASNIKA").LazyLoad();

            HasMany(p => p.DodatnaOprema).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

            HasMany(p => p.Parking).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

            HasMany(p => p.Kreveti).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

            HasMany(p => p.Sobe).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

            HasMany(p => p.SajtoviNekretnine).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

            HasMany(p => p.Najmovi).KeyColumn("ID_NEKRETNINE").LazyLoad().Cascade.All().Inverse();

        }
    }

    class StanMapiranja : SubclassMap<Stan>
    {
        public StanMapiranja()
        {
            DiscriminatorValue("stan");

            Map(p => p.Sprat, "SPRAT");
            Map(p => p.PosedujeLift, "POSEDUJE_LIFT");

        }
    }

    class KucaMapiranja : SubclassMap<Kuca>
    {
        public KucaMapiranja()
        {
            DiscriminatorValue("kuca");

            Map(p => p.Spratnos, "SPRATNOST_KUCE");
            Map(p => p.PosedujeDvoriste, "POSEDUJE_DVORISTE");
        }

    }
}


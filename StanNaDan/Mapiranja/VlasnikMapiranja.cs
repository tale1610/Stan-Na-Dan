using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class VlasnikMapiranja : ClassMap<Vlasnik>
    {
        public VlasnikMapiranja()
        {
            Table("VLASNIK");

            Id(p => p.IdVlasnika).GeneratedBy.TriggerIdentity();

            Map(p => p.Banka, "BANKA");
            Map(p => p.BrojBankovnogRacuna, "BROJ_BANKOVNOG_RACUNA");

            HasMany(p => p.Nekretnine).KeyColumn("ID_VLASNIKA").LazyLoad().Inverse().Cascade.All();

            HasOne(p => p.FizickoLice).Constrained().Cascade.All();

            HasOne(p => p.PravnoLice).Constrained().Cascade.All();

        }
    }
}

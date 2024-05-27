using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class SajtoviMapiranja : ClassMap<SajtoviNekretnine>
    {
        public SajtoviMapiranja()
        {
            Table("SAJTOVI");

            CompositeId(p => p.ID)
            .KeyProperty(p => p.Sajt, "SAJT")
            .KeyReference(p => p.Nekretnina, "ID_NEKRETNINE");

            //Map(p => p.Sajt, "Sajt");
            //References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();
        }
    }
}

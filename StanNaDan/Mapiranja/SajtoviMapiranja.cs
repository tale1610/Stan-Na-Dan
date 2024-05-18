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

            Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(p => p.Sajt, "Sajt");

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();
        }
    }
}

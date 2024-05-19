using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class KrevetMapiranja : ClassMap<Krevet>
    {
        public KrevetMapiranja() {
            Table("KREVET");

            Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(p => p.Tip, "TIP");
            Map(p => p.Dimenzije, "DIMENZIJE");
            Map(p => p.IdKreveta, "ID_KREVETA_U_NEKRETNINI");

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();

        }
    }
}

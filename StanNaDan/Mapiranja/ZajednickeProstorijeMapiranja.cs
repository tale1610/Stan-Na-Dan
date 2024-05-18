using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class ZajednickeProstorijeMapiranja : ClassMap<ZajednickeProstorije>
    {
        public ZajednickeProstorijeMapiranja() {
            Table("ZAJEDNICKE_PROSTORIJE");

            Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(p => p.ZajednickaProstorija, "ZAJEDNICKA_PROSTORIJA");

            References(p => p.Soba).Column("ID_SOBE").LazyLoad();

        }
    }
}

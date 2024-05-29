using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class ZajednickeProstorijeMapiranja : ClassMap<ZajednickeProstorije>
    {
        public ZajednickeProstorijeMapiranja()
        {
            Table("ZAJEDNICKE_PROSTORIJE");

            CompositeId(p => p.ID)
                .KeyProperty(p => p.ZajednickaProstorija, "ZAJEDNICKA_PROSTORIJA")
                .KeyReference(p => p.Soba, "ID_NEKRETNINE", "ID_SOBE");
        }
    }
}

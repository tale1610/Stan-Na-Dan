using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class KvartMapiranja : ClassMap<Kvart>
    {
        public KvartMapiranja() {
            Table("KVART");

            Id(p => p.ID, "ID_KVARTA").GeneratedBy.TriggerIdentity();

            Map(p => p.GradskaZona, "GRADSKA_ZONA");

            //HasMany(p => p.Nekretnine).KeyColumn("ID_KVARTA").LazyLoad().Inverse().Cascade.All();

            References(p => p.PoslovnicaZaduzenaZaNjega).Column("ID_POSLOVNICE").LazyLoad().Cascade.All();

        }
    }
}

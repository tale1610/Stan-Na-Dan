using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class IznajmljenaSobaMapiranja : ClassMap<IznajmljenaSoba>
    {
        public IznajmljenaSobaMapiranja() {
            Table("IZNAJMLJENA_SOBA");

            Id(p => p.ID, "ID_IZNAJMLJIVANJA_SOBE").GeneratedBy.TriggerIdentity();

            References(p => p.Soba).Column("ID_SOBE").LazyLoad();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class SobaMapiranja : ClassMap<Soba>
    {
        public SobaMapiranja() {
            Table("SOBA");

            Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(p => p.IdSobe, "ID_SOBE_U_NEKRETNINI");

            References(p => p.Nekretnina).Column("ID_NEKRENTINE").LazyLoad();

            HasManyToMany(p => p.Najmovi)
                .Table("IZNAJMLJENA_SOBA")
                .ParentKeyColumn("ID_SOBE")
                .ChildKeyColumn("ID_NAJMA"); 

            HasMany(p => p.ZajednickeProstorije).KeyColumn("ID_SOBE").Cascade.All().Inverse();
        }
    }
}

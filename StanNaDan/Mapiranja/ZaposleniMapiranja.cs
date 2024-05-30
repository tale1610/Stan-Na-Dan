using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class ZaposleniMapiranja : ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja() {
            Table("ZAPOSLENI");

            DiscriminateSubClassesOnColumn("TIP_POSLA");

            Id(p => p.MBR, "MBR").GeneratedBy.Assigned();

            Map(p => p.Ime, "IME");
            Map(p => p.Prezime, "PREZIME");
            Map(p => p.DatumZaposlenja, "DATUM_ZAPOSLENJA");

            References(p => p.Poslovnica).Column("ID_POSLOVNICE").LazyLoad();
        }
    }
    class SefMapiranja : SubclassMap<Sef>
    {
        public SefMapiranja()
        {
            DiscriminatorValue("sef");

            Map(p => p.DatumPostavljanja, "DATUM_POSTAVLJANJA");
        }
    }
    class AgentMapiranja : SubclassMap<Agent>
    {
        public AgentMapiranja()
        {
            DiscriminatorValue("agent");

            Map(p => p.StrucnaSprema, "STRUCNA_SPREMA");

            HasMany(p => p.AngazovaniSaradnici).KeyColumn("MBR_AGENTA").Cascade.All().Inverse();
            HasMany(p => p.RealizovaniNajmovi).KeyColumn("MBR_AGENTA").Cascade.All().Inverse();
        }
    }
    class RadnikMapiranja : SubclassMap<Radnik>
    {
        public RadnikMapiranja()
        {
            DiscriminatorValue("ostalo");
        }
    }
}



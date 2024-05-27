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

            //1:N veza ka prodanici, ako je sef to mu je prodavnica sefovanja ako je agent ili ostalo tu radi
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

            HasMany(p => p.AngazovaniSaradnici).KeyColumn("MBR_AGENTA").Cascade.SaveUpdate().Inverse();//ovo sam stavio bez cascade.all() jer ako se obrise zaposleni iz baze podataka, sa cascade.all bi otisli i njegovi spoljni saradnici, i najmovi koje je realizovao (linija ispod), sto je besmisleno jer najmovi bi trebali da ostanu kad se obrise agent koji je realizovao najam, e sad to je malo cudno jer sta ako se onda zatrazi taj najam i pokusa da vrati tog agenta a on vise ne postoji u bazi sta onda
            HasMany(p => p.RealizovaniNajmovi).KeyColumn("MBR_AGENTA").Cascade.SaveUpdate().Inverse();
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



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class DodatnaOpremaMapiranja : ClassMap<DodatnaOprema>
    {
        public DodatnaOpremaMapiranja() {

            Table("DODATNA_OPREMA");

            Id(p => p.IdOpreme, "ID_OPREME").GeneratedBy.TriggerIdentity();

            Map(p => p.TipOpreme, "TIP_OPREME");
            Map(p => p.BesplatnoKoriscenje, "BESPLATNO_KORISCENJE");
            Map(p => p.CenaKoriscenja, "CENA_KORISCENJA");

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();
        }
    }
}

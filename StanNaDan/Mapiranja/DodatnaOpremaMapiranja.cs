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

            CompositeId(p => p.ID)
            .KeyProperty(p => p.IdOpreme, "ID_OPREME")
            .KeyReference(p => p.Nekretnina, "ID_NEKRETNINE");
             
            Map(p => p.TipOpreme, "TIP_OPREME");
            Map(p => p.BesplatnoKoriscenje, "BESPLATNO_KORISCENJE").CustomType<BooleanToStringType>();
            Map(p => p.CenaKoriscenja, "CENA_KORISCENJA");

            //References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad(); //ako nesot jebe omoguci i ovo i u entitetu dodaj ovaj property tj skini komentar
            //References(x => x.Nekretnina).Column("ID_NEKRETNINE").Not.Insert().Not.Update();
        }
    }
}

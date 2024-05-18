using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class BrojeviTelefonaMapiranja : ClassMap<BrojeviTelefona>
    {
        public BrojeviTelefonaMapiranja() {

            Table("BROJEVI_TELEFONA");

            Id(p => p.BrojTelefona, "BROJ_TELEFONA").GeneratedBy.Assigned();

            References(p => p.FizickoLice).Column("JMBG_LICA").LazyLoad();
        
        }
    }
}

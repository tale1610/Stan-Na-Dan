using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class TelefoniKontaktOsobeMapiranja : ClassMap<TelefoniKontaktOsobe>
    {
        public TelefoniKontaktOsobeMapiranja()
        {
            Table("TELEFONI_KONTAKT_OSOBE");
            Id(p => p.BrojTelefona, "BROJ_TELEFONA").GeneratedBy.Assigned();
            References(p => p.PravnoLice).Column("PIB_FIRME").LazyLoad();
        }
    }
}

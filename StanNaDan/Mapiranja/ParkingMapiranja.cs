using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class ParkingMapiranja : ClassMap<Parking>
    {
        public ParkingMapiranja() {
            Table("PARKING");

            Id(p => p.ID, "ID").GeneratedBy.TriggerIdentity();

            Map(p => p.IdParkinga, "ID_PARKINGA");
            Map(p => p.Besplatan, "BESPLATAN");
            Map(p => p.Cena, "CENA");
            Map(p => p.USastavuNekretnine, "U_SASTAVU_NEKRETNINE");
            Map(p => p.USastavuJavnogParkinga, "U_SASTAVU_JAVNOG_PARKINGA");

            References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();


        }

    }
}

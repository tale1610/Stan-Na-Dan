﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class PoslovnicaMapiranja :ClassMap<Poslovnica>
    {
        public PoslovnicaMapiranja() {
            Table("POSLOVNICA");

            Id(p => p.ID, "ID_POSLOVNICE").GeneratedBy.TriggerIdentity();

            Map(p => p.Adresa, "ADRESA");
            Map(p => p.RadnoVreme, "RADNO_VREME");

            HasMany(p => p.Zaposleni).KeyColumn("ID_POSLOVNICE").LazyLoad().Cascade.All().Inverse();
            HasMany(p => p.Kvartovi).KeyColumn("ID_POSLOVNICE").LazyLoad().Cascade.All().Inverse();
            References(p => p.Sef).Column("MBR_SEFA").LazyLoad().Cascade.All();
        }
    }
}

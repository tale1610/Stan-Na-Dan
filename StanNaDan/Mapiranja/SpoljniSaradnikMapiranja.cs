using FluentNHibernate.Conventions.Inspections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Mapiranja
{
    class SpoljniSaradnikMapiranja : ClassMap<SpoljniSaradnik>
    {
        public SpoljniSaradnikMapiranja()
        {
            Table("SPOLJNI_SARADNIK");

            Id(p => p.ID,"ID").GeneratedBy.TriggerIdentity();

            Map(p => p.Ime, "IME");
            Map(p => p.Prezime, "PREZIME");
            Map(p => p.DatumAngazovanja, "DATUM_ANGAZOVANJA");
            Map(p => p.Telefon, "TELEFON");
            Map(p => p.ProcenatOdNajma, "PROCENAT_OD_NAJMA");

            References(p => p.AgentAngazovanja).Column("MBR_AGENTA").LazyLoad();

            HasMany(p => p.RealizovaniNajmovi).KeyColumn("ID_Spoljnjeg_Radnika").LazyLoad().Cascade.All();
        }
    }
}

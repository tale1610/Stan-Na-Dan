﻿using NHibernate.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanNaDan.Entiteti
{
    public class FizickoLice
    {
        public virtual required string JMBG { get; set; }
        public virtual required string Ime { get; set; }
        public virtual required string ImeRoditelja { get; set; }
        public virtual required string Prezime { get; set; }
        public virtual required string Drzava { get; set; }
        public virtual required string MestoStanovanja { get; set; }
        public virtual required string AdresaStanovanja { get; set; }
        public virtual required DateTime DatumRodjenja { get; set; }
        public virtual required string Email { get; set; }

        public virtual required Vlasnik Vlasnik { get; set; }
        public virtual IList<BrojeviTelefona> BrojeviTelefona { get; set; } = [];
    }
}

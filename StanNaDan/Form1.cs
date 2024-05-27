using NHibernate;

namespace StanNaDan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDodajPoslovnicu_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    Poslovnica poslovnica = new()
                    {
                        Adresa = "PIROT, Nikole Tesle 32",
                        RadnoVreme = "09:00 - 20:00"
                    };
                    Kvart kvart = new()
                    {
                        GradskaZona = "Kale",
                        PoslovnicaZaduzenaZaNjega = poslovnica
                    };

                    poslovnica.Kvartovi.Add(kvart);
                    await session.SaveOrUpdateAsync(poslovnica);//poenta svega je ova funkcija jer nam menja sql naredbe i CRUD operacije
                    //meni nije jasno kako ovo pukne na upisivanju kvarta ali ipak upise poslovnicu to ne bi smelo nikako da se desi
                    //save or update na osnovu ID zna da li da uradi save ili update, ako pronadje taj id onda ce da uradi update, ako ne pronadje save
                    await session.FlushAsync();
                    //ovako se osiguravamo da on nece da pokusa da izvrsi save ili update nekad kasnije nego odmah cim se ovo desi

                    MessageBox.Show($"Poslovnica {poslovnica.Adresa} sa ID: {poslovnica.ID} je upisana.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    //var poslovnica = session.Load<Poslovnica>(7);//vrni mi poslovnicu sa id7 trebalo bi slavonska
                    //MessageBox.Show($"Poslovnica sa id {poslovnica.ID} ima adresu {poslovnica.Adresa} i dodajemo joj ovog novog radnika.");
                    Poslovnica poslovnica = new()
                    {
                        Adresa = "PIROT, Jevrejska 33",
                        RadnoVreme = "09:00 - 20:00"
                    };

                    Sef zaposleni = new()
                    {
                        DatumZaposlenja = DateTime.Now,
                        DatumPostavljanja = DateTime.Now,
                        Ime = "Dimitrije",
                        Prezime = "Najdanovic",
                        MBR = "9898989898989",
                        Poslovnica = poslovnica
                    };
                    poslovnica.Zaposleni.Add(zaposleni);

                    await session.SaveOrUpdateAsync(poslovnica);
                    await session.FlushAsync();

                    MessageBox.Show($"Zaposleni {zaposleni.Ime} sa ID: {zaposleni.MBR} je upisan i zaposljen u poslovnicu {zaposleni.Poslovnica.Adresa}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajKvart_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var poslovnica = session.Load<Poslovnica>(7);//vrni mi poslovnicu sa id7 trebalo bi slavonska
                    MessageBox.Show($"Poslovnica sa id {poslovnica.ID} ima adresu {poslovnica.Adresa} i dodajemo joj ovaj novi kvart na upravljanje.");
                    Kvart kvart = new()
                    {
                        GradskaZona = "Kale",
                        PoslovnicaZaduzenaZaNjega = poslovnica
                    };

                    poslovnica.Kvartovi.Add(kvart);
                    await session.SaveOrUpdateAsync(poslovnica);
                    await session.FlushAsync();

                    MessageBox.Show($"Kvart {kvart.GradskaZona} sa ID: {kvart.ID} je upisan i dodat na upravljanje poslovnici {poslovnica.Adresa}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajNekretninu_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var vlasnik = session.Load<Vlasnik>(1);
                    MessageBox.Show($"Nadjen vlasnik sa id: {vlasnik.IdVlasnika}, njemu ce da se pripise ova nekretnina.");
                    var kvart = session.Load<Kvart>(8);
                    Kuca nekretnina = new()
                    {
                        Ulica = "Slavonska",
                        Broj = "66",
                        BrojKupatila = 3,
                        BrojSpavacihSoba = 4,
                        BrojTerasa = 4,
                        Kvadratura = 300,
                        Kvart = kvart,
                        PosedujeInternet = true,
                        PosedujeKuhinju = true,
                        PosedujeTV = true,
                        Vlasnik = vlasnik,
                        Spratnos = 2,
                        PosedujeDvoriste = true
                    };

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Kuca na adresi {nekretnina.Ulica} {nekretnina.Broj} je dodata.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajDodatnuOpremuNekretnini_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var nekretnina = session.Load<Nekretnina>(1);
                    MessageBox.Show($"Pronasli smo nekretninu sa ID: {nekretnina.IdNekretnine} i ubacicemo joj dodatnu opremu.");

                    var dodatnaOprema = new DodatnaOprema
                    {
                        BesplatnoKoriscenje = true,
                        ID = new DodatnaOpremaId
                        {
                            IdOpreme = 5,
                            Nekretnina = nekretnina
                        },
                        TipOpreme = "Daska za peglanje"
                    };
                    nekretnina.DodatnaOprema.Add(dodatnaOprema);

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Nekretnini {nekretnina.IdNekretnine} smo dodali tip opreme: {dodatnaOprema.TipOpreme}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }

        }

        private async void btnDodajParkingNekretnini_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var nekretnina = session.Load<Nekretnina>(1);
                    MessageBox.Show($"Pronasli smo nekretninu sa ID: {nekretnina.IdNekretnine} i dodacemo joj parking mesto.");

                    var parking = new Parking
                    {
                        ID = new ParkingId
                        {
                            IdParkinga = 5,
                            Nekretnina = nekretnina
                        },
                        Besplatan = true,
                        USastavuJavnogParkinga = false,
                        USastavuNekretnine = true
                    };
                    nekretnina.Parking.Add(parking);

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Nekretnini {nekretnina.IdNekretnine} smo dodali parking {(parking.USastavuNekretnine ? "koji je u sastavu nekretnine" : "koji nije u sastavu nekretnine")}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajKrevetNekretnini_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var nekretnina = session.Load<Nekretnina>(1);
                    MessageBox.Show($"Pronasli smo nekretninu sa ID: {nekretnina.IdNekretnine} i dodacemo joj novi krevet.");

                    var krevet = new Krevet
                    {
                        ID = new KrevetId
                        {
                            IdKreveta = 5,
                            Nekretnina = nekretnina
                        },
                        Dimenzije = "200x90",
                        Tip = "Jednopersonski"
                    };
                    nekretnina.Kreveti.Add(krevet);

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Nekretnini {nekretnina.IdNekretnine} smo dodali krevet dimenzija {krevet.Dimenzije}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajSajtIzdavanjaNekretnini_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var nekretnina = session.Load<Nekretnina>(1);
                    MessageBox.Show($"Pronasli smo nekretninu sa ID: {nekretnina.IdNekretnine} i dodacemo joj novo izdavanje na novom sajtu.");

                    var sajt = new SajtoviNekretnine
                    {
                        ID = new SajtoviNekretnineId
                        {
                            Sajt = "sajtzaizdavanje.rs",
                            Nekretnina = nekretnina
                        }
                    };
                    nekretnina.SajtoviNekretnine.Add(sajt);

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Nekretninu {nekretnina.IdNekretnine} smo izdali na sajtu {sajt.ID.Sajt}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajSobuNekretnini_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var nekretnina = session.Load<Nekretnina>(4);
                    MessageBox.Show($"Pronasli smo nekretninu sa ID: {nekretnina.IdNekretnine} i dodacemo joj novu sobu za izdavanje.");

                    var soba = new Soba
                    {
                        ID = new SobaId
                        {
                            IdSobe = 5,
                            Nekretnina = nekretnina
                        }
                    };
                    nekretnina.Sobe.Add(soba);

                    await session.SaveOrUpdateAsync(nekretnina);
                    await session.FlushAsync();

                    MessageBox.Show($"Nekretnini {nekretnina.IdNekretnine} smo dodali sobu za izdavanje sa ID: {soba.ID.IdSobe}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnPribaviNajam_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    var najam = session.Load<Najam>(2);
                    MessageBox.Show($"Pribavljeni najam iz baze:\n" +
                        $"Id najma:\t\t\t{najam.IdNajma}\n" +
                        $"Datum pocetka:\t\t{najam.DatumPocetka}\n" +
                        $"Datum zavrsetka:\t\t{najam.DatumZavrsetka}\n" +
                        $"Broj dana:\t\t\t{najam.BrojDana}\n" +
                        $"Cena po danu:\t\t{najam.CenaPoDanu}\n" +
                        $"Popust:\t\t\t{(najam.Popust > 0 ? najam.Popust : "Nema popusta")}\n" +
                        $"Cena sa popustom:\t\t{najam.CenaSaPopustom}\n" +
                        $"Ukupna cena:\t\t{najam.UkupnaCena}\n" +
                        $"Provizija agencije:\t\t{najam.ProvizijaAgencije}\n" +
                        $"IdSpoljnogSaradnika:\t\t{(najam.SpoljniSaradnik != null ? najam.SpoljniSaradnik.ID.IdSaradnika : "Nema spoljnog saradnika za ovaj najam")}\n"
                        );

                    //await session.SaveOrUpdateAsync(nekretnina);
                    //await session.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnIznajmiNekretninu_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    Kuca nekretnina = new()
                    {
                        Ulica = "PIROT, Slavonska",
                        Broj = "66",
                        BrojKupatila = 3,
                        BrojSpavacihSoba = 4,
                        BrojTerasa = 4,
                        Kvadratura = 300,
                        Kvart = new()
                        {
                            GradskaZona = "Kale",
                            PoslovnicaZaduzenaZaNjega = new()
                            {
                                Adresa = "PIROT, Jevrejska 33",
                                RadnoVreme = "09:00 - 20:00"
                            }
                        },
                        PosedujeInternet = true,
                        PosedujeKuhinju = true,
                        PosedujeTV = true,
                        PosedujeDvoriste = true,
                        Spratnos = 2,
                        Vlasnik = new()
                        {
                            Banka = "UniCredit",
                            BrojBankovnogRacuna = "39410492101"
                        }
                    };
                    var agent = session.Load<Agent>("4444444444444");
                    var spoljniSaradnik = agent.AngazovaniSaradnici.FirstOrDefault(s => s.ID.IdSaradnika == 1);
                    MessageBox.Show($"Ucitan agent sa MBR {agent.MBR} koji ce da realizuje ovaj najam uz angazovanje njegovog spoljnog saradnika sa ID: {spoljniSaradnik.ID.IdSaradnika} ");
                    Najam najam = new()
                    {
                        Agent = agent,
                        SpoljniSaradnik = spoljniSaradnik,
                        Nekretnina = nekretnina,
                        DatumPocetka = DateTime.Now,
                        DatumZavrsetka = DateTime.Now.AddDays(10),
                        BrojDana = 10,
                        CenaPoDanu = 1000,
                        UkupnaCena = 10 * 1000
                    };

                    MessageBox.Show($"Novom najmu smo dodali spoljnog saradnika {najam.SpoljniSaradnik.Ime} i daj boze da radi sve");
                    await session.SaveOrUpdateAsync(najam);
                    await session.FlushAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }

        private async void btnDodajFizickoLice_Click(object sender, EventArgs e)
        {
            ISession? session = null;
            try
            {
                session = DataLayer.GetSession();

                if (session != null && session.IsOpen)
                {
                    Vlasnik vlasnik = new()
                    {
                        Banka = "proba",
                        BrojBankovnogRacuna = "000000000"
                    };

                    FizickoLice fl = new()
                    {
                        JMBG = "1107002732512",
                        AdresaStanovanja = " Proba",
                        DatumRodjenja = DateTime.Now,
                        Drzava = "Proba",
                        Email = "Proba",
                        Ime = "Proba",
                        Prezime = "Proba",
                        ImeRoditelja = "Proba",
                        MestoStanovanja = "Proba",
                        Vlasnik = vlasnik
                    };

                   

                    await session.SaveOrUpdateAsync(fl);
                    await session.FlushAsync();

                    MessageBox.Show($"Fizicko lice {fl.Ime} smo dodali u bazu kao vlasnika: {vlasnik.IdVlasnika}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.FormatExceptionMessage());
            }
            finally
            {
                session?.Close();
            }
        }
    }
}

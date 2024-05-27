﻿using NHibernate;
using StanNaDan.Entiteti;
using System.Runtime.Intrinsics.X86;

namespace StanNaDan;

public class DTOManager
{
    #region Poslovnica
    public static List<PoslovnicaPregled> vratiSvePoslovnice()
    {
        List<PoslovnicaPregled> poslovnice = new List<PoslovnicaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Poslovnica> svePoslovnice = from poslovnica
                                                                           in session.Query<StanNaDan.Entiteti.Poslovnica>()
                                                                           select poslovnica;

                foreach (StanNaDan.Entiteti.Poslovnica p in svePoslovnice)
                {
                    if (p.Sef == null)
                    {
                        poslovnice.Add(new PoslovnicaPregled(p.ID, p.Adresa, p.RadnoVreme, null));
                    }
                    else
                    {
                        poslovnice.Add(new PoslovnicaPregled(p.ID, p.Adresa, p.RadnoVreme, p.Sef.Ime));
                    }
                }
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

        return poslovnice;
    }

    public static void dodajPoslovnicu(PoslovnicaBasic poslovnicaBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = new()
                {
                    Adresa = poslovnicaBasic.Adresa,
                    RadnoVreme = poslovnicaBasic.RadnoVreme
                };

                session.SaveOrUpdate(poslovnica);
                session.Flush();
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

    public static PoslovnicaBasic vratiPoslovnicu(int id)
    {
        PoslovnicaBasic poslovnicaBasic = new PoslovnicaBasic();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(id);
                poslovnicaBasic = new PoslovnicaBasic(poslovnica.ID, poslovnica.Adresa, poslovnica.RadnoVreme, poslovnica.Sef);
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
        return poslovnicaBasic;
    }

    public static void azurirajPoslovnicu(PoslovnicaBasic poslovnicaBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(poslovnicaBasic.ID);//kreiramo novu koju cemo da prosledimo u saveOrUpdate, na osnovu ove koju smo prosledili i ucitali sad koju zelimo da izmenimo
                poslovnica.Adresa = poslovnicaBasic.Adresa;
                poslovnica.RadnoVreme = poslovnicaBasic.RadnoVreme;
                poslovnica.Sef = poslovnicaBasic.Sef;

                session.SaveOrUpdate(poslovnica);
                session.Flush();
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

    public static void obrisiPoslovnicu(int id)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(id);//ucitamo je za brisanje
                string adresa = poslovnica.Adresa;
                session.Delete(poslovnica);
                session.Flush();
                MessageBox.Show($"Uspesno ste obrisali poslovnicu koja je bila na adresi: {adresa}, svi njeni zaposleni su automatski otpusteni.");
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

    #endregion

    #region Zaposleni
    public static List<ZaposleniPregled> vratiSveZaposlene()
    {
        List<ZaposleniPregled> zaposleniToReturn = new List<ZaposleniPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Sef> sviSefovi = from sef
                                                                in session.Query<StanNaDan.Entiteti.Sef>()
                                                                select sef;

                foreach (StanNaDan.Entiteti.Sef z in sviSefovi)
                {
                    zaposleniToReturn.Add(new SefPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.Poslovnica.Adresa, nameof(Sef), (DateTime)z.DatumPostavljanja));
                    Poslovnica poslovnicaToUpdate = session.Load<Poslovnica>(z.Poslovnica.ID);
                    poslovnicaToUpdate.Sef = z;
                    session.SaveOrUpdate(poslovnicaToUpdate);
                    session.Flush();
                }

                IEnumerable<StanNaDan.Entiteti.Agent> sviAgenti = from agent
                                                                     in session.Query<StanNaDan.Entiteti.Agent>()
                                                                  select agent;

                foreach (StanNaDan.Entiteti.Agent z in sviAgenti)
                {
                    zaposleniToReturn.Add(new AgentPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.StrucnaSprema, z.Poslovnica.Adresa, nameof(Agent)));
                }
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

        return zaposleniToReturn;
    }

    public static List<ZaposleniPregled> vratiSveZaposlenePoslovnice(int idPoslovnice)
    {
        List<ZaposleniPregled> zaposleniToReturn = new List<ZaposleniPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Sef> sviSefovi = from sef
                                                                in session.Query<StanNaDan.Entiteti.Sef>()
                                                                where sef.Poslovnica.ID == idPoslovnice
                                                                select sef;

                foreach (StanNaDan.Entiteti.Sef z in sviSefovi)
                {
                    zaposleniToReturn.Add(new SefPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.Poslovnica.Adresa, nameof(Sef), (DateTime)z.DatumPostavljanja));
                }

                IEnumerable<StanNaDan.Entiteti.Agent> sviAgenti = from agent
                                                                  in session.Query<StanNaDan.Entiteti.Agent>()
                                                                  where agent.Poslovnica.ID == idPoslovnice
                                                                  select agent;

                foreach (StanNaDan.Entiteti.Agent z in sviAgenti)
                {
                    zaposleniToReturn.Add(new AgentPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.StrucnaSprema, z.Poslovnica.Adresa, nameof(Agent)));
                }
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

        return zaposleniToReturn;
    }

    public static void obrisiZaposlenog(string mbr)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Zaposleni zaposleni = session.Load<Zaposleni>(mbr);//ucitamo ga za brisanje
                string _mbr = zaposleni.MBR;
                session.Delete(zaposleni);
                session.Flush();
                MessageBox.Show($"Uspesno ste obrisali zaposlenog sa mbr: {_mbr}.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);//vidi kako ce ovo da se ponasa sa usrani najmovi kad se posle trazi najam na kom je on radio
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

    #endregion

    #region Agent
    public static List<AgentPregled> vratiSveAgente()
    {
        List<AgentPregled> agentiToReturn = new List<AgentPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Agent> sviAgenti = from agent
                                                                     in session.Query<StanNaDan.Entiteti.Agent>()
                                                                  select agent;

                foreach (StanNaDan.Entiteti.Agent z in sviAgenti)
                {
                    agentiToReturn.Add(new AgentPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.StrucnaSprema, z.Poslovnica.Adresa, nameof(Agent)));
                }
            }
            return agentiToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<AgentPregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static AgentBasic vratiAgenta(string mbr)
    {
        AgentBasic agentBasic = new AgentBasic();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Agent agent = session.Load<Agent>(mbr);
                PoslovnicaBasic poslovnicaBasic = new PoslovnicaBasic(agent.Poslovnica.ID, agent.Poslovnica.Adresa, agent.Poslovnica.RadnoVreme, agent.Poslovnica.Sef);
                agentBasic = new AgentBasic(agent.MBR, agent.Ime, agent.Prezime, agent.DatumZaposlenja, agent.StrucnaSprema, poslovnicaBasic);
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
        return agentBasic;
    }

    public static void dodajNovogAgenta(int idPoslovnice, AgentBasic agentBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(idPoslovnice);

                Agent agent = new()
                {
                    MBR = agentBasic.MBR,
                    Ime = agentBasic.Ime,
                    Prezime = agentBasic.Prezime,
                    DatumZaposlenja = agentBasic.DatumZaposlenja,
                    StrucnaSprema = agentBasic.StrucnaSprema,
                    Poslovnica = poslovnica
                    //TODO: DODAJ ANGAZOVANE SARADNIKE I REALIZOVANE NAJMOVE
                };
                poslovnica.Zaposleni.Add(agent);

                session.SaveOrUpdate(agent);
                session.Flush();
                MessageBox.Show($"Agent {agent.Ime} {agent.Prezime} je zaposlen u poslovnicu {poslovnica.Adresa}.");
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
    #endregion

    #region Sef
    public static List<SefPregled> vratiSveSefove()
    {
        List<SefPregled> sefoviToReturn = new List<SefPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Sef> sviSefovi = from sef
                                                                in session.Query<StanNaDan.Entiteti.Sef>()
                                                                select sef;

                foreach (StanNaDan.Entiteti.Sef z in sviSefovi)
                {
                    sefoviToReturn.Add(new SefPregled(z.MBR, z.Ime, z.Prezime, z.DatumZaposlenja, z.Poslovnica.Adresa, nameof(Sef), (DateTime)z.DatumPostavljanja));
                }
            }
            return sefoviToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<SefPregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static void dodajNovogSefa(int idPoslovnice, SefBasic sefBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(idPoslovnice);
                if (poslovnica.Sef != null)
                {
                    MessageBox.Show($"Poslovnica moze da ima samo jednog sefa! Morate da skinete sa funkcije postojeceg da biste postavili novog");
                    return;
                }
                Sef sef = new()
                {
                    MBR = sefBasic.MBR,
                    Ime = sefBasic.Ime,
                    Prezime = sefBasic.Prezime,
                    DatumZaposlenja = sefBasic.DatumZaposlenja,
                    DatumPostavljanja = sefBasic.DatumPostavljanja,
                    Poslovnica = poslovnica
                };
                poslovnica.Sef = sef;
                poslovnica.Zaposleni.Add(sef);

                session.SaveOrUpdate(poslovnica);
                session.Flush();
                MessageBox.Show($"Sef {sef.Ime} {sef.Prezime} je zaposlen u poslovnicu {poslovnica.Adresa}.");
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

    #endregion

    #region SpoljniSaradnik
    public static List<SpoljniSaradnikPregled> vratiSveSpoljneSaradnike()
    {
        List<SpoljniSaradnikPregled> spoljniToReturn = new List<SpoljniSaradnikPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.SpoljniSaradnik> sviSpoljni = from spoljniSaradnik
                                                                             in session.Query<StanNaDan.Entiteti.SpoljniSaradnik>()
                                                                             select spoljniSaradnik;

                foreach (StanNaDan.Entiteti.SpoljniSaradnik s in sviSpoljni)
                {
                    spoljniToReturn.Add(new SpoljniSaradnikPregled(s.ID.AgentAngazovanja.MBR, s.ID.IdSaradnika, s.Ime, s.Prezime, s.DatumAngazovanja, s.Telefon, s.ProcenatOdNajma));
                }
            }
            return spoljniToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<SpoljniSaradnikPregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<SpoljniSaradnikPregled> vratiSveSpoljneSaradnikeAgenta(string mbrAgentaAngazovanja)
    {
        List<SpoljniSaradnikPregled> spoljniToReturn = new List<SpoljniSaradnikPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.SpoljniSaradnik> sviSpoljni = from spoljniSaradnik
                                                                             in session.Query<StanNaDan.Entiteti.SpoljniSaradnik>()
                                                                             where spoljniSaradnik.ID.AgentAngazovanja.MBR == mbrAgentaAngazovanja
                                                                             select spoljniSaradnik;

                foreach (StanNaDan.Entiteti.SpoljniSaradnik s in sviSpoljni)
                {
                    spoljniToReturn.Add(new SpoljniSaradnikPregled(s.ID.AgentAngazovanja.MBR, s.ID.IdSaradnika, s.Ime, s.Prezime, s.DatumAngazovanja, s.Telefon, s.ProcenatOdNajma));
                }
            }
            return spoljniToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<SpoljniSaradnikPregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static SpoljniSaradnikBasic vratiSpoljnogSaradnika(string mbrAgentaAngazovanja, int idSpoljnogSaradnika)
    {
        SpoljniSaradnikBasic spoljniToReturn = new SpoljniSaradnikBasic();
        ISession? session = null;
        try
        {
            SpoljniSaradnikId ssID = new()
            {
                AgentAngazovanja = session.Load<Agent>(mbrAgentaAngazovanja),
                IdSaradnika = idSpoljnogSaradnika
            };
            SpoljniSaradnik spoljniSaradnik = session.Load<SpoljniSaradnik>(ssID);
            PoslovnicaBasic poslovnicaBasic = new()
            {
                ID = spoljniSaradnik.ID.AgentAngazovanja.Poslovnica.ID,
                Adresa = spoljniSaradnik.ID.AgentAngazovanja.Poslovnica.Adresa,
                RadnoVreme = spoljniSaradnik.ID.AgentAngazovanja.Poslovnica.RadnoVreme,
                Sef = spoljniSaradnik.ID.AgentAngazovanja.Poslovnica.Sef == null ? spoljniSaradnik.ID.AgentAngazovanja.Poslovnica.Sef : null
            };
            AgentBasic agentAngazovanjaBasic = new()
            {
                DatumZaposlenja = spoljniSaradnik.ID.AgentAngazovanja.DatumZaposlenja,
                Ime = spoljniSaradnik.ID.AgentAngazovanja.Ime,
                Prezime = spoljniSaradnik.ID.AgentAngazovanja.Prezime,
                MBR = spoljniSaradnik.ID.AgentAngazovanja.MBR,
                StrucnaSprema = spoljniSaradnik.ID.AgentAngazovanja.StrucnaSprema,
                Poslovnica = poslovnicaBasic
            };
            spoljniToReturn.IdSaradnika = spoljniSaradnik.ID.IdSaradnika;
            spoljniToReturn.DatumAngazovanja = spoljniSaradnik.DatumAngazovanja;
            spoljniToReturn.ProcenatOdNajma = spoljniSaradnik.ProcenatOdNajma;
            spoljniToReturn.AgentAngazovanja = agentAngazovanjaBasic;
            spoljniToReturn.Ime = spoljniSaradnik.Ime;
            spoljniToReturn.Prezime = spoljniSaradnik.Prezime;
            spoljniToReturn.Telefon = spoljniSaradnik.Telefon;

            return spoljniToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new SpoljniSaradnikBasic();
        }
        finally
        {
            session?.Close();
        }
    }

    public static void obrisiSpoljnogSaradnika(string mbrAgentaAngazovanja, int idSpoljnog)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                SpoljniSaradnikId ssID = new()
                {
                    AgentAngazovanja = session.Load<Agent>(mbrAgentaAngazovanja),
                    IdSaradnika = idSpoljnog
                };
                SpoljniSaradnik spoljniSaradnik = session.Load<SpoljniSaradnik>(ssID);//ucitamo ga za brisanje
                string ime = spoljniSaradnik.Ime;
                session.Delete(spoljniSaradnik);
                session.Flush();
                MessageBox.Show($"Uspesno ste obrisali spoljnog saradnika {ime}.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);//vidi kako ce ovo da se ponasa sa usrani najmovi kad se posle trazi najam na kom je on radio
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

    public static void dodajNovogSpoljnogSaradnika(SpoljniSaradnikBasic ssBasic, string mbrAgentaAngazovanja)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Agent agent = session.Load<Agent>(mbrAgentaAngazovanja);
                SpoljniSaradnikId ssID = new()
                {
                    AgentAngazovanja = agent,
                    IdSaradnika = ssBasic.IdSaradnika
                };
                SpoljniSaradnik spoljniSaradnik = new()
                {
                    Ime = ssBasic.Ime,
                    Prezime = ssBasic.Prezime,
                    DatumAngazovanja = ssBasic.DatumAngazovanja,
                    ProcenatOdNajma = ssBasic.ProcenatOdNajma,
                    Telefon = ssBasic.Telefon,
                    ID = ssID
                    //TODO: DODAJ I REALIZOVANE NAJMOVE
                };
                agent.AngazovaniSaradnici.Add(spoljniSaradnik);

                session.SaveOrUpdate(spoljniSaradnik);
                session.Flush();
                MessageBox.Show($"Spoljnog saradnika {spoljniSaradnik.Ime} {spoljniSaradnik.Prezime} je angazovao agent {agent.Ime} {agent.Prezime}.");
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



    #endregion

    #region Kvart
    public static List<KvartPregled> vratiSveKvartove()
    {
        List<KvartPregled> kvartovi = new List<KvartPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Kvart> sviKvartovi = from kvart
                                                                    in session.Query<StanNaDan.Entiteti.Kvart>()
                                                                    select kvart;

                foreach (StanNaDan.Entiteti.Kvart k in sviKvartovi)
                {
                    kvartovi.Add(new KvartPregled(k.ID, k.GradskaZona, k.PoslovnicaZaduzenaZaNjega.Adresa));
                }
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

        return kvartovi;
    }

    public static List<KvartPregled> vratiSveKvartovePoslovnice(int idPoslovnice)
    {
        List<KvartPregled> kvartovi = new List<KvartPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Kvart> sviKvartovi = from kvart
                                                                    in session.Query<StanNaDan.Entiteti.Kvart>()
                                                                    where kvart.PoslovnicaZaduzenaZaNjega.ID == idPoslovnice
                                                                    select kvart;

                foreach (StanNaDan.Entiteti.Kvart k in sviKvartovi)
                {
                    kvartovi.Add(new KvartPregled(k.ID, k.GradskaZona, k.PoslovnicaZaduzenaZaNjega.Adresa));
                }
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

        return kvartovi;
    }

    public static KvartBasic vratiKvart(int idKvarta)
    {
        KvartBasic kvartBasic = new KvartBasic();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Kvart kvart = session.Load<Kvart>(idKvarta);
                PoslovnicaBasic poslovnicaBasic = new PoslovnicaBasic(kvart.PoslovnicaZaduzenaZaNjega.ID, kvart.PoslovnicaZaduzenaZaNjega.Adresa, kvart.PoslovnicaZaduzenaZaNjega.RadnoVreme, kvart.PoslovnicaZaduzenaZaNjega.Sef);
                kvartBasic = new KvartBasic(kvart.ID, kvart.GradskaZona, poslovnicaBasic);
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
        return kvartBasic;
    }

    public static void dodajNoviKvart(int idPoslovnice, KvartBasic kvartBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Poslovnica poslovnica = session.Load<Poslovnica>(idPoslovnice);

                Kvart kvart = new()
                {
                    GradskaZona = kvartBasic.GradskaZona,
                    PoslovnicaZaduzenaZaNjega = poslovnica
                    //TODO: DODAJ NEKRETNINE KOJE SE NALAZE NA NJEMU
                };
                poslovnica.Kvartovi.Add(kvart);

                session.SaveOrUpdate(kvart);
                session.Flush();
                MessageBox.Show($"Kvart {kvart.GradskaZona} je dodat i zaduzen u poslovnici {poslovnica.Adresa}.");
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
    #endregion

    #region Vlasnik
    public static void obrisiVlasnika(string jmbg = null, string pib = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                if (jmbg != null)
                {
                    FizickoLice fizickoLice = session.Load<FizickoLice>(jmbg);
                    int idVlasnika = fizickoLice.Vlasnik.IdVlasnika;
                    session.Delete(fizickoLice);
                    session.Flush();
                    MessageBox.Show($"Uspesno ste obrisali vlasnika sa ID: {idVlasnika}.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);//vidi kako ce ovo da se ponasa sa usrani najmovi kad se posle trazi najam na kom je on radio
                }
                if (pib != null)
                {
                    PravnoLice pravnoLice = session.Load<PravnoLice>(pib);
                    int idVlasnika = pravnoLice.Vlasnik.IdVlasnika;
                    session.Delete(pravnoLice);
                    session.Flush();
                    MessageBox.Show($"Uspesno ste obrisali vlasnika sa ID: {idVlasnika}.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);//vidi kako ce ovo da se ponasa sa usrani najmovi kad se posle trazi najam na kom je on radio

                }
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
    #endregion

    #region FizickoLice
    public static List<FizickoLicePregled> vratiSvaFizickaLica()
    {
        List<FizickoLicePregled> fizickaLicaToReturn = new List<FizickoLicePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.FizickoLice> svaFizickaLica = from fizickoLice
                                                                             in session.Query<StanNaDan.Entiteti.FizickoLice>()
                                                                             select fizickoLice;

                foreach (StanNaDan.Entiteti.FizickoLice fl in svaFizickaLica)
                {
                    VlasnikPregled vlasnikPregled = new VlasnikPregled(fl.Vlasnik.IdVlasnika, fl.Vlasnik.Banka, fl.Vlasnik.BrojBankovnogRacuna);
                    fizickaLicaToReturn.Add(new FizickoLicePregled(fl.JMBG, fl.Ime, fl.ImeRoditelja, fl.Prezime, fl.Drzava, fl.MestoStanovanja, fl.AdresaStanovanja, fl.DatumRodjenja, fl.Email, vlasnikPregled));
                }
            }
            return fizickaLicaToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<FizickoLicePregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static void dodajNovoFizickoLice(FizickoLiceBasic fizickoLiceBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Vlasnik vlasnik = new()
                {
                    Banka = fizickoLiceBasic.Vlasnik.Banka,
                    BrojBankovnogRacuna = fizickoLiceBasic.Vlasnik.BrojBankovnogRacuna
                };

                FizickoLice fizickoLice = new()
                {
                    JMBG = fizickoLiceBasic.JMBG,
                    Ime = fizickoLiceBasic.Ime,
                    Prezime = fizickoLiceBasic.Prezime,
                    ImeRoditelja = fizickoLiceBasic.ImeRoditelja,
                    MestoStanovanja = fizickoLiceBasic.MestoStanovanja,
                    AdresaStanovanja = fizickoLiceBasic.MestoStanovanja,
                    DatumRodjenja = fizickoLiceBasic.DatumRodjenja,
                    Drzava = fizickoLiceBasic.Drzava,
                    Email = fizickoLiceBasic.Email,
                    Vlasnik = vlasnik
                    //TODO: DODAJ NJEGOVE NEKRETNINE I NJEGOVE BROJEVE TELEFONA
                };

                session.SaveOrUpdate(fizickoLice);
                session.Flush();
                MessageBox.Show($"Fizicko lice {fizickoLice.Ime} {fizickoLice.Prezime} je upisano u bazu podataka kao vlasnik sa ID {vlasnik.IdVlasnika}.");
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
    #endregion

    #region PravnoLice
    public static List<PravnoLicePregled> vratiSvaPravnaLica()
    {
        List<PravnoLicePregled> pravnaLicaToReturn = new List<PravnoLicePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.PravnoLice> svaPravnaLica = from pravnoLice
                                                                           in session.Query<StanNaDan.Entiteti.PravnoLice>()
                                                                           select pravnoLice;

                foreach (StanNaDan.Entiteti.PravnoLice pl in svaPravnaLica)
                {
                    VlasnikPregled vlasnikPregled = new VlasnikPregled(pl.Vlasnik.IdVlasnika, pl.Vlasnik.Banka, pl.Vlasnik.BrojBankovnogRacuna);
                    pravnaLicaToReturn.Add(new PravnoLicePregled(pl.PIB, pl.Naziv, pl.AdresaSedista, pl.ImeKontaktOsobe, pl.EmailKontaktOsobe, vlasnikPregled));
                }
            }
            return pravnaLicaToReturn;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<PravnoLicePregled>();
        }
        finally
        {
            session?.Close();
        }
    }

    public static void dodajNovoPravnoLice(PravnoLiceBasic pravnoLiceBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Vlasnik vlasnik = new()
                {
                    Banka = pravnoLiceBasic.Vlasnik.Banka,
                    BrojBankovnogRacuna = pravnoLiceBasic.Vlasnik.BrojBankovnogRacuna
                };

                PravnoLice pravnoLice = new()
                {
                    PIB = pravnoLiceBasic.PIB,
                    Naziv = pravnoLiceBasic.Naziv,
                    AdresaSedista = pravnoLiceBasic.AdresaSedista,
                    ImeKontaktOsobe = pravnoLiceBasic.ImeKontaktOsobe,
                    EmailKontaktOsobe = pravnoLiceBasic.EmailKontaktOsobe,
                    Vlasnik = vlasnik
                    //TODO: DODAJ NJEGOVE NEKRETNINE I NJEGOVE BROJEVE TELEFONA
                };

                session.SaveOrUpdate(pravnoLice);
                session.Flush();
                MessageBox.Show($"Fizicko lice {pravnoLice.Naziv} je upisano u bazu podataka kao vlasnik sa ID {vlasnik.IdVlasnika}.");
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
    #endregion

    #region Nekretnina

    public static void DodajNekretninu(int idKvarta, int idVlasnika, NekretninaBasic novaNekretnina)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Kvart kvart = session.Load<Kvart>(idKvarta);
                Vlasnik vlasnik = session.Load<Vlasnik>(idVlasnika);
                Nekretnina nekretnina = new Nekretnina
                {
                    Ulica = novaNekretnina.Ulica,
                    Broj = novaNekretnina.Broj,
                    Kvadratura = novaNekretnina.Kvadratura,
                    BrojTerasa = novaNekretnina.BrojTerasa,
                    BrojKupatila = novaNekretnina.BrojKupatila,
                    BrojSpavacihSoba = novaNekretnina.BrojSpavacihSoba,
                    PosedujeTV = novaNekretnina.PosedujeTV,
                    PosedujeInternet = novaNekretnina.PosedujeInternet,
                    PosedujeKuhinju = novaNekretnina.PosedujeKuhinju,
                    Kvart = kvart,
                    Vlasnik = vlasnik
                };

                session.Save(nekretnina);
                session.Flush();
                // Prikaz poruke o uspešnom dodavanju može se prilagoditi tvojoj aplikaciji
                Console.WriteLine("Nova nekretnina je uspešno dodata.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<NekretninaPregled> VratiSveNekretnine()// dodaj prikaz da li je stan ili kuca
    {
        List<NekretninaPregled> nekretnine = new List<NekretninaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Nekretnina> sveNekretnine = from nekretnina
                                                                           in session.Query<StanNaDan.Entiteti.Nekretnina>()
                                                                           select nekretnina;

                foreach (StanNaDan.Entiteti.Nekretnina p in sveNekretnine)
                {
                    nekretnine.Add(new NekretninaPregled(
                        p.IdNekretnine,
                        p.Ulica,
                        p.Broj,
                        p.Kvadratura,
                        p.BrojTerasa,
                        p.BrojKupatila,
                        p.BrojSpavacihSoba,
                        p.PosedujeTV,
                        p.PosedujeInternet,
                        p.PosedujeKuhinju,
                        p.Kvart.GradskaZona,
                        p.Vlasnik.IdVlasnika));
                }
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

        return nekretnine;
    }

    public static List<NekretninaPregled> VratiSveNekretnineKvarta(int idKvarta)
    {
        List<NekretninaPregled> nekretnine = new List<NekretninaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Nekretnina> sveNekretnine = from nekretnina
                                                                           in session.Query<StanNaDan.Entiteti.Nekretnina>()
                                                                           where nekretnina.Kvart.ID == idKvarta
                                                                           select nekretnina;

                foreach (StanNaDan.Entiteti.Nekretnina p in sveNekretnine)
                {
                    if (p.Kvart.ID == idKvarta)
                    {
                        nekretnine.Add(new NekretninaPregled(
                            p.IdNekretnine,
                            p.Ulica,
                            p.Broj,
                            p.Kvadratura,
                            p.BrojTerasa,
                            p.BrojKupatila,
                            p.BrojSpavacihSoba,
                            p.PosedujeTV,
                            p.PosedujeInternet,
                            p.PosedujeKuhinju,
                            p.Kvart.GradskaZona,
                            p.Vlasnik.IdVlasnika));
                    }
                }
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

        return nekretnine;
    }

    public static List<NekretninaPregled> VratiSveNekretnineVlasnika(int idVlasnika)
    {
        List<NekretninaPregled> nekretnine = new List<NekretninaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Nekretnina> sveNekretnine = from nekretnina
                                                                           in session.Query<StanNaDan.Entiteti.Nekretnina>()
                                                                           where nekretnina.Vlasnik.IdVlasnika == idVlasnika
                                                                           select nekretnina;

                foreach (StanNaDan.Entiteti.Nekretnina p in sveNekretnine)
                {
                    if (p.Kvart.ID == idVlasnika)
                    {
                        nekretnine.Add(new NekretninaPregled(
                        p.IdNekretnine,
                        p.Ulica,
                        p.Broj,
                        p.Kvadratura,
                        p.BrojTerasa,
                        p.BrojKupatila,
                        p.BrojSpavacihSoba,
                        p.PosedujeTV,
                        p.PosedujeInternet,
                        p.PosedujeKuhinju,
                        p.Kvart.GradskaZona,
                        p.Vlasnik.IdVlasnika));
                    }
                }
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

        return nekretnine;
    }

    public static void IzmeniNekretninu(NekretninaBasic izmenjenaNekretnina, FizickoLiceBasic flBasic = null, PravnoLiceBasic plBasic = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Get<Nekretnina>(izmenjenaNekretnina.IdNekretnine);
                Vlasnik vlasnik = null;
                if (nekretnina != null)
                {
                    if (flBasic != null)
                    {
                        vlasnik = session.Get<Vlasnik>(flBasic.Vlasnik.IdVlasnika);
                        if (vlasnik == null)
                        {
                            dodajNovoFizickoLice(flBasic);
                            vlasnik = session.Get<Vlasnik>(flBasic.Vlasnik.IdVlasnika);
                        }
                    }
                    else if (plBasic != null)
                    {
                        vlasnik = session.Get<Vlasnik>(plBasic.Vlasnik.IdVlasnika);
                        if (vlasnik == null)
                        {
                            dodajNovoPravnoLice(plBasic);
                            vlasnik = session.Get<Vlasnik>(plBasic.Vlasnik.IdVlasnika);
                        }
                    }

                    nekretnina.Ulica = izmenjenaNekretnina.Ulica;
                    nekretnina.Broj = izmenjenaNekretnina.Broj;
                    nekretnina.Kvadratura = izmenjenaNekretnina.Kvadratura;
                    nekretnina.BrojTerasa = izmenjenaNekretnina.BrojTerasa;
                    nekretnina.BrojKupatila = izmenjenaNekretnina.BrojKupatila;
                    nekretnina.BrojSpavacihSoba = izmenjenaNekretnina.BrojSpavacihSoba;
                    nekretnina.PosedujeTV = izmenjenaNekretnina.PosedujeTV;
                    nekretnina.PosedujeInternet = izmenjenaNekretnina.PosedujeInternet;
                    nekretnina.PosedujeKuhinju = izmenjenaNekretnina.PosedujeKuhinju;
                    nekretnina.Vlasnik = vlasnik;

                    session.Update(nekretnina);
                    session.Flush();
                    // Prikaz poruke o uspešnoj izmeni može se prilagoditi tvojoj aplikaciji
                    Console.WriteLine($"Podaci za nekretninu sa ID {izmenjenaNekretnina.IdNekretnine} su izmenjeni.");
                }
                else
                {
                    // Prikaz poruke kada nekretnina nije pronađena može se prilagoditi tvojoj aplikaciji
                    Console.WriteLine($"Nekretnina sa ID {izmenjenaNekretnina.IdNekretnine} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiNekretninu(int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Get<Nekretnina>(idNekretnine);
                if (nekretnina != null)
                {
                    session.Delete(nekretnina);
                    session.Flush();
                    // Prikaz poruke o uspešnom brisanju može se prilagoditi tvojoj aplikaciji
                    Console.WriteLine($"Nekretnina sa ID {idNekretnine} je obrisana.");
                }
                else
                {
                    // Prikaz poruke kada nekretnina nije pronađena može se prilagoditi tvojoj aplikaciji
                    Console.WriteLine($"Nekretnina sa ID {idNekretnine} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region DodatnaOprema

    public static void DodajDodatnuOpremu(DodatnaOpremaBasic novaOprema, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                DodatnaOpremaId doID = new()
                {
                    IdOpreme = novaOprema.IdOpreme,
                    Nekretnina = nekretnina
                };

                DodatnaOprema dodatnaOprema = new DodatnaOprema
                {
                    ID = doID,
                    TipOpreme = novaOprema.TipOpreme,
                    BesplatnoKoriscenje = novaOprema.BesplatnoKoriscenje,
                    CenaKoriscenja = novaOprema.CenaKoriscenja
                };

                session.Save(dodatnaOprema);
                session.Flush();
                Console.WriteLine("Nova dodatna oprema je uspešno dodata.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<DodatnaOpremaPregled> VratiSvuDodatnuOpremuNekretnine(int idNekretnine)
    {
        List<DodatnaOpremaPregled> dodatnaOprema = new List<DodatnaOpremaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<DodatnaOprema> svaOprema = from oprema
                                                       in session.Query<DodatnaOprema>()
                                                       where oprema.ID.Nekretnina.IdNekretnine == idNekretnine
                                                       select oprema;

                foreach (DodatnaOprema op in svaOprema)
                {
                    dodatnaOprema.Add(new DodatnaOpremaPregled(
                        op.ID.IdOpreme,
                        op.ID.Nekretnina.IdNekretnine,
                        op.TipOpreme,
                        op.BesplatnoKoriscenje,
                        op.CenaKoriscenja
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return new List<DodatnaOpremaPregled>();
        }
        finally
        {
            session?.Close();
        }

        return dodatnaOprema;
    }

    public static DodatnaOpremaPregled VratiDodatnuOpremu(DodatnaOpremaId id)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                DodatnaOprema oprema = session.Get<DodatnaOprema>(id);
                if (oprema != null)
                {
                    return new DodatnaOpremaPregled(
                        oprema.ID.IdOpreme,
                        oprema.ID.Nekretnina.IdNekretnine,
                        oprema.TipOpreme,
                        oprema.BesplatnoKoriscenje,
                        oprema.CenaKoriscenja
                    );
                }
                else
                {
                    Console.WriteLine($"Dodatna oprema sa ID {id} nije pronađena.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniDodatnuOpremu(DodatnaOpremaBasic izmenjenaOprema, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                DodatnaOpremaId doID = new()
                {
                    IdOpreme = izmenjenaOprema.IdOpreme,
                    Nekretnina = session.Get<Nekretnina>(idNekretnine)
                };

                DodatnaOprema oprema = session.Get<DodatnaOprema>(doID);
                if (oprema != null)
                {
                    oprema.TipOpreme = izmenjenaOprema.TipOpreme;
                    oprema.BesplatnoKoriscenje = izmenjenaOprema.BesplatnoKoriscenje;
                    oprema.CenaKoriscenja = izmenjenaOprema.CenaKoriscenja;

                    session.Update(oprema);
                    session.Flush();
                    Console.WriteLine($"Podaci za dodatnu opremu sa ID {doID} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Dodatna oprema sa ID {doID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiDodatnuOpremu(int idOpreme, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Get<Nekretnina>(idNekretnine);
                DodatnaOpremaId doID = new()
                {
                    IdOpreme = idOpreme,
                    Nekretnina = nekretnina
                };
                DodatnaOprema oprema = session.Get<DodatnaOprema>(doID);
                if (oprema != null)
                {
                    session.Delete(oprema);
                    session.Flush();
                    Console.WriteLine($"Dodatna oprema sa ID {doID} je obrisana.");
                }
                else
                {
                    Console.WriteLine($"Dodatna oprema sa ID {doID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region Krevet

    public static void DodajKrevet(int idNekretnine, KrevetBasic noviKrevet)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                KrevetId kID = new()
                {
                    IdKreveta = noviKrevet.IdKreveta,
                    Nekretnina = nekretnina
                };
                Krevet krevet = new Krevet
                {
                    ID = kID,
                    Tip = noviKrevet.Tip,
                    Dimenzije = noviKrevet.Dimenzije
                };

                session.Save(krevet);
                session.Flush();
                Console.WriteLine("Novi krevet je uspešno dodan.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<KrevetPregled> VratiSveKreveteNekretnine(int idNekretnine)
    {
        List<KrevetPregled> kreveti = new List<KrevetPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Krevet> sviKreveti = from krevet
                                                 in session.Query<Krevet>()
                                                 where krevet.ID.Nekretnina.IdNekretnine == idNekretnine
                                                 select krevet;

                foreach (Krevet k in sviKreveti)
                {
                    kreveti.Add(new KrevetPregled(
                        k.ID.IdKreveta,
                        k.ID.Nekretnina.IdNekretnine,
                        k.Tip,
                        k.Dimenzije
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return kreveti;
    }

    public static KrevetPregled VratiKrevet(int idKreveta, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                KrevetId kID = new()
                {
                    IdKreveta = idKreveta,
                    Nekretnina = nekretnina
                };
                Krevet krevet = session.Get<Krevet>(kID);
                if (krevet != null)
                {
                    return new KrevetPregled(
                        krevet.ID.IdKreveta,
                        krevet.ID.Nekretnina.IdNekretnine,
                        krevet.Tip,
                        krevet.Dimenzije
                    );
                }
                else
                {
                    Console.WriteLine($"Krevet sa ID {idKreveta} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniKrevet(KrevetBasic izmenjeniKrevet, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                KrevetId kID = new()
                {
                    IdKreveta = izmenjeniKrevet.IdKreveta,
                    Nekretnina = nekretnina
                };
                Krevet krevet = session.Get<Krevet>(kID);
                if (krevet != null)
                {
                    krevet.Tip = izmenjeniKrevet.Tip;
                    krevet.Dimenzije = izmenjeniKrevet.Dimenzije;

                    session.Update(krevet);
                    session.Flush();
                    Console.WriteLine($"Podaci za krevet sa ID {izmenjeniKrevet.IdKreveta} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Krevet sa ID {izmenjeniKrevet.IdKreveta} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiKrevet(int idKreveta, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                KrevetId kID = new()
                {
                    IdKreveta = idKreveta,
                    Nekretnina = nekretnina
                };
                Krevet krevet = session.Get<Krevet>(kID);
                if (krevet != null)
                {
                    session.Delete(krevet);
                    session.Flush();
                    Console.WriteLine($"Krevet sa ID {kID} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Krevet sa ID {kID} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region Parking

    public static void DodajParking(ParkingBasic noviParking, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                ParkingId pID = new()
                {
                    IdParkinga = noviParking.IdParkinga,
                    Nekretnina = nekretnina
                };
                Parking parking = new Parking
                {
                    ID = pID,
                    Besplatan = noviParking.Besplatan,
                    Cena = noviParking.Cena,
                    USastavuNekretnine = noviParking.USastavuNekretnine,
                    USastavuJavnogParkinga = noviParking.USastavuJavnogParkinga
                };

                session.Save(parking);
                session.Flush();
                Console.WriteLine("Novi parking je uspešno dodat.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<ParkingPregled> VratiSveParkingeNekretnine(int idNekretnine)
    {
        List<ParkingPregled> parkinzi = new List<ParkingPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Parking> sviParkinzi = from parking
                                                   in session.Query<Parking>()
                                                   where parking.ID.Nekretnina.IdNekretnine == idNekretnine
                                                   select parking;

                foreach (Parking p in sviParkinzi)
                {
                    parkinzi.Add(new ParkingPregled(
                        p.ID.IdParkinga,
                        p.ID.Nekretnina.IdNekretnine,
                        p.Besplatan,
                        p.Cena,
                        p.USastavuNekretnine,
                        p.USastavuJavnogParkinga
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return parkinzi;
    }

    public static ParkingPregled VratiParking(int idParkinga, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                ParkingId pID = new()
                {
                    IdParkinga = idParkinga,
                    Nekretnina = nekretnina
                };
                Parking parking = session.Get<Parking>(pID);
                if (parking != null)
                {
                    return new ParkingPregled(
                        parking.ID.IdParkinga,
                        parking.ID.Nekretnina.IdNekretnine,
                        parking.Besplatan,
                        parking.Cena,
                        parking.USastavuNekretnine,
                        parking.USastavuJavnogParkinga
                    );
                }
                else
                {
                    Console.WriteLine($"Parking sa ID {pID} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniParking(ParkingBasic izmenjeniParking, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                ParkingId pID = new()
                {
                    IdParkinga = izmenjeniParking.IdParkinga,
                    Nekretnina = nekretnina
                };
                Parking parking = session.Get<Parking>(pID);
                if (parking != null)
                {
                    parking.Besplatan = izmenjeniParking.Besplatan;
                    parking.Cena = izmenjeniParking.Cena;
                    parking.USastavuNekretnine = izmenjeniParking.USastavuNekretnine;
                    parking.USastavuJavnogParkinga = izmenjeniParking.USastavuJavnogParkinga;

                    session.Update(parking);
                    session.Flush();
                    Console.WriteLine($"Podaci za parking sa ID {pID} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Parking sa ID {pID} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiParking(int idParkinga, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                ParkingId pID = new()
                {
                    IdParkinga = idParkinga,
                    Nekretnina = nekretnina
                };
                Parking parking = session.Get<Parking>(pID);
                if (parking != null)
                {
                    session.Delete(parking);
                    session.Flush();
                    Console.WriteLine($"Parking sa ID {pID} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Parking sa ID {pID} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region SajtoviNekretnine

    public static void DodajSajtNekretnine(SajtoviNekretnineBasic noviSajt, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SajtoviNekretnineId sajtID = new()
                {
                    Sajt = noviSajt.Sajt,
                    Nekretnina = nekretnina
                };
                SajtoviNekretnine sajtoviNekretnine = new()
                {
                    ID = sajtID
                };

                session.Save(sajtoviNekretnine);
                session.Flush();
                Console.WriteLine("Novi sajt nekretnine je uspešno dodat.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<SajtoviNekretninePregled> VratiSveSajtoveNekretnine(int idNekretnine)
    {
        List<SajtoviNekretninePregled> sajtovi = new List<SajtoviNekretninePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<SajtoviNekretnine> sviSajtovi = from sajt
                                                            in session.Query<SajtoviNekretnine>()
                                                            where sajt.ID.Nekretnina.IdNekretnine == idNekretnine
                                                            select sajt;

                foreach (SajtoviNekretnine s in sviSajtovi)
                {
                    sajtovi.Add(new SajtoviNekretninePregled(
                        s.ID.Sajt,
                        s.ID.Nekretnina.IdNekretnine,
                        s.ID.Nekretnina.Ulica + " " + s.ID.Nekretnina.Broj
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return sajtovi;
    }

    public static SajtoviNekretninePregled VratiSajtNekretnine(string sajt, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SajtoviNekretnineId sID = new()
                {
                    Sajt = sajt,
                    Nekretnina = nekretnina
                };
                SajtoviNekretnine sajtNekretnine = session.Get<SajtoviNekretnine>(sID);
                if (sajtNekretnine != null)
                {
                    return new SajtoviNekretninePregled(
                        sajtNekretnine.ID.Sajt,
                        sajtNekretnine.ID.Nekretnina.IdNekretnine,
                        sajtNekretnine.ID.Nekretnina.Ulica + " " + sajtNekretnine.ID.Nekretnina.Broj
                    );
                }
                else
                {
                    Console.WriteLine($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniSajtNekretnine(SajtoviNekretnineBasic izmenjeniSajt, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SajtoviNekretnineId sID = new()
                {
                    Sajt = izmenjeniSajt.Sajt,
                    Nekretnina = nekretnina
                };
                SajtoviNekretnine sajtNekretnine = session.Get<SajtoviNekretnine>(sID);
                if (sajtNekretnine != null)
                {
                    sajtNekretnine.ID = sID;
                    //sajtNekretnine.Sajt = izmenjeniSajt.Sajt;
                    //sajtNekretnine.Nekretnina = nekretnina;

                    session.Update(sajtNekretnine);
                    session.Flush();
                    Console.WriteLine($"Podaci za sajt nekretnine sa sajtom {izmenjeniSajt.Sajt} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Sajt nekretnine sa sajtom {izmenjeniSajt.Sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiSajtNekretnine(string sajt, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SajtoviNekretnineId sID = new SajtoviNekretnineId
                {
                    Sajt = sajt,
                    Nekretnina = nekretnina
                };
                SajtoviNekretnine sajtNekretnine = session.Get<SajtoviNekretnine>(sID);
                if (sajtNekretnine != null)
                {
                    session.Delete(sajtNekretnine);
                    session.Flush();
                    Console.WriteLine($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region BrojeviTelefona

    public static void DodajBrojTelefona(BrojeviTelefonaBasic noviBroj, string jmbgFizickogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Load<FizickoLice>(jmbgFizickogLica);
                BrojeviTelefona brojTelefona = new BrojeviTelefona
                {
                    BrojTelefona = noviBroj.BrojTelefona,
                    FizickoLice = fizickoLice
                };

                session.Save(brojTelefona);
                session.Flush();
                Console.WriteLine("Novi broj telefona je uspešno dodat.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<BrojeviTelefonaPregled> VratiSveBrojeveTelefona(string jmbgFizickogLica)
    {
        List<BrojeviTelefonaPregled> brojevi = new List<BrojeviTelefonaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<BrojeviTelefona> sviBrojevi = from broj
                                                          in session.Query<BrojeviTelefona>()
                                                          where broj.FizickoLice.JMBG == jmbgFizickogLica
                                                          select broj;

                foreach (BrojeviTelefona b in sviBrojevi)
                {
                    brojevi.Add(new BrojeviTelefonaPregled(
                        b.BrojTelefona,
                        b.FizickoLice.JMBG,
                        b.FizickoLice.Ime,
                        b.FizickoLice.Prezime
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return brojevi;
    }

    public static BrojeviTelefonaPregled VratiBrojTelefona(string brojTelefona, string jmbgFizickogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Load<FizickoLice>(jmbgFizickogLica);
                BrojeviTelefona brojTelefonaObj = session.Get<BrojeviTelefona>(brojTelefona);

                if (brojTelefonaObj != null)
                {
                    return new BrojeviTelefonaPregled(
                        brojTelefonaObj.BrojTelefona,
                        brojTelefonaObj.FizickoLice.JMBG,
                        brojTelefonaObj.FizickoLice.Ime,
                        brojTelefonaObj.FizickoLice.Prezime
                    );
                }
                else
                {
                    Console.WriteLine($"Broj telefona sa brojem {brojTelefona} i JMBG-om {jmbgFizickogLica} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniBrojTelefona(BrojeviTelefonaBasic izmenjeniBroj, string jmbgFizickogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Load<FizickoLice>(jmbgFizickogLica);
                BrojeviTelefona brojTelefona = session.Get<BrojeviTelefona>(izmenjeniBroj.BrojTelefona);

                if (brojTelefona != null)
                {
                    brojTelefona.BrojTelefona = izmenjeniBroj.BrojTelefona;
                    brojTelefona.FizickoLice = fizickoLice;

                    session.Update(brojTelefona);
                    session.Flush();
                    Console.WriteLine($"Podaci za broj telefona {izmenjeniBroj.BrojTelefona} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Broj telefona sa brojem {izmenjeniBroj.BrojTelefona} i JMBG-om {jmbgFizickogLica} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiBrojTelefona(string brojTelefona, string jmbgFizickogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Load<FizickoLice>(jmbgFizickogLica);
                BrojeviTelefona brojTelefonaObj = session.Get<BrojeviTelefona>(brojTelefona);
                if (brojTelefonaObj != null)
                {
                    session.Delete(brojTelefonaObj);
                    session.Flush();
                    Console.WriteLine($"Broj telefona {brojTelefona} za fizičko lice sa JMBG-om {jmbgFizickogLica} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Broj telefona {brojTelefona} za fizičko lice sa JMBG-om {jmbgFizickogLica} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region TelefoniKontaktOsobe

    public static void DodajTelefonKontaktOsobe(TelefoniKontaktOsobeBasic noviTelefon, string pibPravnogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Load<PravnoLice>(pibPravnogLica);
                TelefoniKontaktOsobe telefon = new TelefoniKontaktOsobe
                {
                    BrojTelefona = noviTelefon.BrojTelefona,
                    PravnoLice = pravnoLice
                };

                session.Save(telefon);
                session.Flush();
                Console.WriteLine("Novi telefon kontakt osobe je uspešno dodat.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<TelefoniKontaktOsobePregled> VratiSveTelefoneKontaktOsobe(string pibPravnogLica)
    {
        List<TelefoniKontaktOsobePregled> telefoni = new List<TelefoniKontaktOsobePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<TelefoniKontaktOsobe> sviTelefoni = from telefon
                                                                in session.Query<TelefoniKontaktOsobe>()
                                                                where telefon.PravnoLice.PIB == pibPravnogLica
                                                                select telefon;

                foreach (TelefoniKontaktOsobe t in sviTelefoni)
                {
                    telefoni.Add(new TelefoniKontaktOsobePregled(
                        t.BrojTelefona,
                        t.PravnoLice.PIB,
                        t.PravnoLice.Naziv,
                        t.PravnoLice.ImeKontaktOsobe
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return telefoni;
    }

    public static TelefoniKontaktOsobePregled VratiTelefonKontaktOsobe(string brojTelefona, string pibPravnogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Load<PravnoLice>(pibPravnogLica);
                TelefoniKontaktOsobe telefon = session.Get<TelefoniKontaktOsobe>(brojTelefona);
                if (telefon != null)
                {
                    return new TelefoniKontaktOsobePregled(
                        telefon.BrojTelefona,
                        telefon.PravnoLice.PIB,
                        telefon.PravnoLice.Naziv,
                        telefon.PravnoLice.ImeKontaktOsobe
                    );
                }
                else
                {
                    Console.WriteLine($"Telefon kontakt osobe sa brojem {brojTelefona} i PIB-om {pibPravnogLica} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniTelefonKontaktOsobe(TelefoniKontaktOsobeBasic izmenjeniTelefon, string pibPravnogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Load<PravnoLice>(pibPravnogLica);
                TelefoniKontaktOsobe telefon = session.Get<TelefoniKontaktOsobe>(izmenjeniTelefon.BrojTelefona);
                if (telefon != null)
                {
                    telefon.BrojTelefona = izmenjeniTelefon.BrojTelefona;
                    telefon.PravnoLice = pravnoLice;

                    session.Update(telefon);
                    session.Flush();
                    Console.WriteLine($"Podaci za telefon kontakt osobe {izmenjeniTelefon.BrojTelefona} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Telefon kontakt osobe sa brojem {izmenjeniTelefon.BrojTelefona} i PIB-om {pibPravnogLica} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiTelefonKontaktOsobe(string brojTelefona, string pibPravnogLica)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Load<PravnoLice>(pibPravnogLica);
                TelefoniKontaktOsobe telefon = session.Get<TelefoniKontaktOsobe>(brojTelefona);
                if (telefon != null)
                {
                    session.Delete(telefon);
                    session.Flush();
                    Console.WriteLine($"Telefon kontakt osobe {brojTelefona} za pravno lice sa PIB-om {pibPravnogLica} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Telefon kontakt osobe {brojTelefona} za pravno lice sa PIB-om {pibPravnogLica} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region Soba

    public static void DodajSobu(SobaBasic novaSoba, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SobaId sID = new()
                {
                    IdSobe = novaSoba.IdSobe,
                    Nekretnina = nekretnina
                };
                Soba soba = new()
                {
                    ID = sID
                };

                session.Save(soba);
                session.Flush();
                Console.WriteLine("Nova soba je uspešno dodata.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<SobaPregled> VratiSveSobeNekretnine(int idNekretnine)
    {
        List<SobaPregled> sobe = new List<SobaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Soba> sveSobe = from soba
                                            in session.Query<Soba>()
                                            where soba.ID.Nekretnina.IdNekretnine == idNekretnine
                                            select soba;

                foreach (Soba s in sveSobe)
                {
                    sobe.Add(new SobaPregled(
                        s.ID.IdSobe,
                        s.ID.Nekretnina.IdNekretnine
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return sobe;
    }

    public static SobaPregled VratiSobu(int idSobe, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SobaId sID = new()
                {
                    IdSobe = idSobe,
                    Nekretnina = nekretnina
                };
                Soba soba = session.Get<Soba>(sID);
                if (soba != null)
                {
                    return new SobaPregled(
                        soba.ID.IdSobe,
                        soba.ID.Nekretnina.IdNekretnine
                    );
                }
                else
                {
                    Console.WriteLine($"Soba sa ID {sID} nije pronađena.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniSobu(SobaBasic izmenjenaSoba, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SobaId sID = new()
                {
                    IdSobe = izmenjenaSoba.IdSobe,
                    Nekretnina = nekretnina
                };
                Soba soba = session.Get<Soba>(sID);
                if (soba != null)
                {
                    soba.ID = sID;

                    session.Update(soba);
                    session.Flush();
                    Console.WriteLine($"Podaci za sobu sa ID {sID} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Soba sa ID {sID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiSobu(int idSobe, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                SobaId sID = new()
                {
                    IdSobe = idSobe,
                    Nekretnina = nekretnina
                };
                Soba soba = session.Get<Soba>(sID);
                if (soba != null)
                {
                    session.Delete(soba);
                    session.Flush();
                    Console.WriteLine($"Soba sa ID {sID} je obrisana.");
                }
                else
                {
                    Console.WriteLine($"Soba sa ID {sID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region ZajednickeProstorije

    public static void DodajZajednickuProstoriju(ZajednickeProstorijeBasic novaProstorija, int idSobe, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Soba soba = session.Load<Soba>(new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                ZajednickeProstorijeId zpID = new ZajednickeProstorijeId
                {
                    Soba = soba,
                    ZajednickaProstorija = novaProstorija.ZajednickaProstorija
                };
                ZajednickeProstorije zajednickaProstorija = new ZajednickeProstorije
                {
                    ID = zpID
                };

                session.Save(zajednickaProstorija);
                session.Flush();
                Console.WriteLine("Nova zajednička prostorija je uspešno dodata.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<ZajednickeProstorijePregled> VratiSveZajednickeProstorije(int idSobe, int idNekretnine)
    {
        List<ZajednickeProstorijePregled> prostorije = new List<ZajednickeProstorijePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<ZajednickeProstorije> sveProstorije = from zp
                                                                  in session.Query<ZajednickeProstorije>()
                                                                  where zp.ID.Soba.ID.IdSobe == idSobe && zp.ID.Soba.ID.Nekretnina.IdNekretnine == idNekretnine
                                                                  select zp;

                foreach (ZajednickeProstorije zp in sveProstorije)
                {
                    prostorije.Add(new ZajednickeProstorijePregled(
                        zp.ID.Soba.ID.Nekretnina.IdNekretnine,
                        zp.ID.Soba.ID.IdSobe,
                        zp.ID.ZajednickaProstorija
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return prostorije;
    }

    public static ZajednickeProstorijePregled VratiZajednickuProstoriju(int idSobe, int idNekretnine, string zajednickaProstorija)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Soba soba = session.Load<Soba>(new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                ZajednickeProstorijeId zpID = new ZajednickeProstorijeId
                {
                    Soba = soba,
                    ZajednickaProstorija = zajednickaProstorija
                };
                ZajednickeProstorije prostorija = session.Get<ZajednickeProstorije>(zpID);
                if (prostorija != null)
                {
                    return new ZajednickeProstorijePregled(
                        prostorija.ID.Soba.ID.Nekretnina.IdNekretnine,
                        prostorija.ID.Soba.ID.IdSobe,
                        prostorija.ID.ZajednickaProstorija
                    );
                }
                else
                {
                    Console.WriteLine($"Zajednička prostorija sa ID {zpID} nije pronađena.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniZajednickuProstoriju(ZajednickeProstorijeBasic izmenjenaProstorija, int idSobe, int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Soba soba = session.Load<Soba>(new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                ZajednickeProstorijeId zpID = new ZajednickeProstorijeId
                {
                    Soba = soba,
                    ZajednickaProstorija = izmenjenaProstorija.ZajednickaProstorija
                };
                ZajednickeProstorije prostorija = session.Get<ZajednickeProstorije>(zpID);
                if (prostorija != null)
                {
                    prostorija.ID = zpID;

                    session.Update(prostorija);
                    session.Flush();
                    Console.WriteLine($"Podaci za zajedničku prostoriju sa ID {zpID} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Zajednička prostorija sa ID {zpID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiZajednickuProstoriju(int idSobe, int idNekretnine, string zajednickaProstorija)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Soba soba = session.Load<Soba>(new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                ZajednickeProstorijeId zpID = new ZajednickeProstorijeId
                {
                    Soba = soba,
                    ZajednickaProstorija = zajednickaProstorija
                };
                ZajednickeProstorije prostorija = session.Get<ZajednickeProstorije>(zpID);
                if (prostorija != null)
                {
                    session.Delete(prostorija);
                    session.Flush();
                    Console.WriteLine($"Zajednička prostorija sa ID {zpID} je obrisana.");
                }
                else
                {
                    Console.WriteLine($"Zajednička prostorija sa ID {zpID} nije pronađena.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region Najam

    public static void DodajNajam(NajamBasic noviNajam, int idNekretnine, int idAgenta, int? idSpoljnogSaradnika = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                Agent agent = session.Load<Agent>(idAgenta);
                SpoljniSaradnik? spoljniSaradnik = idSpoljnogSaradnika.HasValue ? session.Load<SpoljniSaradnik>(idSpoljnogSaradnika.Value) : null;

                Najam najam = new Najam
                {
                    DatumPocetka = noviNajam.DatumPocetka,
                    DatumZavrsetka = noviNajam.DatumZavrsetka,
                    BrojDana = (noviNajam.DatumZavrsetka - noviNajam.DatumPocetka).Days,
                    CenaPoDanu = noviNajam.CenaPoDanu,
                    Popust = noviNajam.Popust,
                    CenaSaPopustom = noviNajam.CenaPoDanu * noviNajam.BrojDana * (1 - noviNajam.Popust / 100.0),
                    ZaradaOdDodatnihUsluga = noviNajam.ZaradaOdDodatnihUsluga,
                    UkupnaCena = noviNajam.CenaSaPopustom + noviNajam.ZaradaOdDodatnihUsluga,
                    ProvizijaAgencije = noviNajam.ProvizijaAgencije,
                    Nekretnina = nekretnina,
                    Agent = agent,
                    SpoljniSaradnik = spoljniSaradnik
                };

                session.Save(najam);
                session.Flush();
                Console.WriteLine("Novi najam je uspešno dodat.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static List<NajamPregled> VratiSveNajmove()
    {
        List<NajamPregled> najmovi = new List<NajamPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Najam> sviNajmovi = from n in session.Query<Najam>()
                                                select n;

                foreach (Najam n in sviNajmovi)
                {
                    najmovi.Add(new NajamPregled(
                        n.IdNajma,
                        n.DatumPocetka,
                        n.DatumZavrsetka,
                        n.CenaPoDanu,
                        n.Popust,
                        n.ZaradaOdDodatnihUsluga,
                        n.ProvizijaAgencije,
                        n.Nekretnina.Ulica + " " + n.Nekretnina.Broj,
                        n.Agent.Ime,
                        n.SpoljniSaradnik?.Ime ?? string.Empty
                    ));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return najmovi;
    }

    public static NajamPregled VratiNajam(int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Najam najam = session.Get<Najam>(idNajma);
                if (najam != null)
                {
                    return new NajamPregled(
                        najam.IdNajma,
                        najam.DatumPocetka,
                        najam.DatumZavrsetka,
                        najam.CenaPoDanu,
                        najam.Popust,
                        najam.ZaradaOdDodatnihUsluga,
                        najam.ProvizijaAgencije,
                        najam.Nekretnina.Ulica + " " + najam.Nekretnina.Broj,
                        najam.Agent.Ime,
                        najam.SpoljniSaradnik?.Ime ?? string.Empty
                    );
                }
                else
                {
                    Console.WriteLine($"Najam sa ID {idNajma} nije pronađen.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniNajam(NajamBasic izmenjenNajam)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Najam najam = session.Get<Najam>(izmenjenNajam.IdNajma);
                if (najam != null)
                {
                    najam.DatumPocetka = izmenjenNajam.DatumPocetka;
                    najam.DatumZavrsetka = izmenjenNajam.DatumZavrsetka;
                    najam.BrojDana = (izmenjenNajam.DatumZavrsetka - izmenjenNajam.DatumPocetka).Days;
                    najam.CenaPoDanu = izmenjenNajam.CenaPoDanu;
                    najam.Popust = izmenjenNajam.Popust;
                    najam.CenaSaPopustom = izmenjenNajam.CenaPoDanu * izmenjenNajam.BrojDana * (1 - izmenjenNajam.Popust / 100.0);
                    najam.ZaradaOdDodatnihUsluga = izmenjenNajam.ZaradaOdDodatnihUsluga;
                    najam.UkupnaCena = izmenjenNajam.CenaSaPopustom + izmenjenNajam.ZaradaOdDodatnihUsluga;
                    najam.ProvizijaAgencije = izmenjenNajam.ProvizijaAgencije;

                    session.Update(najam);
                    session.Flush();
                    Console.WriteLine($"Podaci za najam sa ID {izmenjenNajam.IdNajma} su izmenjeni.");
                }
                else
                {
                    Console.WriteLine($"Najam sa ID {izmenjenNajam.IdNajma} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static void ObrisiNajam(int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Najam najam = session.Get<Najam>(idNajma);
                if (najam != null)
                {
                    session.Delete(najam);
                    session.Flush();
                    Console.WriteLine($"Najam sa ID {idNajma} je obrisan.");
                }
                else
                {
                    Console.WriteLine($"Najam sa ID {idNajma} nije pronađen.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

}

﻿using NHibernate;
using StanNaDan.Entiteti;
using System;
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

    public static void DodajNekretninu(int idKvarta, int idVlasnika, KucaBasic kucaBasic = null, StanBasic stanBasic = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Kvart kvart = session.Load<Kvart>(idKvarta);
                Vlasnik vlasnik = session.Load<Vlasnik>(idVlasnika);
                if (kucaBasic != null)
                {
                    Kuca kuca = new()
                    {
                        Ulica = kucaBasic.Ulica,
                        Broj = kucaBasic.Broj,
                        BrojKupatila = kucaBasic.BrojKupatila,
                        BrojSpavacihSoba = kucaBasic.BrojSpavacihSoba,
                        BrojTerasa = kucaBasic.BrojTerasa,
                        Kvadratura = kucaBasic.Kvadratura,
                        Kvart = kvart,
                        Vlasnik = vlasnik,
                        PosedujeInternet = kucaBasic.PosedujeInternet,
                        PosedujeKuhinju = kucaBasic.PosedujeKuhinju,
                        PosedujeTV = kucaBasic.PosedujeTV,
                        Spratnos = kucaBasic.Spratnost,
                        PosedujeDvoriste = kucaBasic.PosedujeDvoriste
                    };
                    

                    vlasnik.Nekretnine.Add(kuca);
                    kvart.Nekretnine.Add(kuca);
                    session.SaveOrUpdate(kuca);
                    session.Flush();
                    MessageBox.Show($"Nova kuca na adresi {kuca.Ulica} {kuca.Broj} je uspešno dodata.");
                }
                else if (stanBasic != null)
                {
                    Stan stan = new()
                    {
                        Ulica = stanBasic.Ulica,
                        Broj = stanBasic.Broj,
                        BrojKupatila = stanBasic.BrojKupatila,
                        BrojSpavacihSoba = stanBasic.BrojSpavacihSoba,
                        BrojTerasa = stanBasic.BrojTerasa,
                        Kvadratura = stanBasic.Kvadratura,
                        Kvart = kvart,
                        Vlasnik = vlasnik,
                        PosedujeInternet = stanBasic.PosedujeInternet,
                        PosedujeKuhinju = stanBasic.PosedujeKuhinju,
                        PosedujeTV = stanBasic.PosedujeTV,
                        Sprat = stanBasic.Sprat,
                        PosedujeLift = stanBasic.PosedujeLift
                    };

                    vlasnik.Nekretnine.Add(stan);
                    kvart.Nekretnine.Add(stan);
                    session.SaveOrUpdate(stan);
                    session.Flush();
                    MessageBox.Show($"Novi stan na adresi {stan.Ulica} {stan.Broj} je uspešno dodat.");
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
                    MessageBox.Show($"Podaci za nekretninu sa ID {izmenjenaNekretnina.IdNekretnine} su izmenjeni.");
                }
                else
                {
                    // Prikaz poruke kada nekretnina nije pronađena može se prilagoditi tvojoj aplikaciji
                    MessageBox.Show($"Nekretnina sa ID {izmenjenaNekretnina.IdNekretnine} nije pronađena.");
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
                    MessageBox.Show($"Nekretnina sa ID {idNekretnine} je obrisana.");
                }
                else
                {
                    MessageBox.Show($"Nekretnina sa ID {idNekretnine} nije pronađena.");
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
                nekretnina.DodatnaOprema.Add(dodatnaOprema);

                session.Save(dodatnaOprema);
                session.Flush();
                MessageBox.Show("Nova dodatna oprema je uspešno dodata.");
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
                    MessageBox.Show($"Dodatna oprema sa ID {id} nije pronađena.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za dodatnu opremu sa ID {doID} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Dodatna oprema sa ID {doID} nije pronađena.");
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
                    MessageBox.Show($"Dodatna oprema sa ID {doID} je obrisana.");
                }
                else
                {
                    MessageBox.Show($"Dodatna oprema sa ID {doID} nije pronađena.");
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
                nekretnina.Kreveti.Add(krevet);

                session.SaveOrUpdate(krevet);
                session.Flush();
                MessageBox.Show("Novi krevet je uspešno dodan.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Krevet sa ID {idKreveta} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za krevet sa ID {izmenjeniKrevet.IdKreveta} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Krevet sa ID {izmenjeniKrevet.IdKreveta} nije pronađen.");
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
                    MessageBox.Show($"Krevet sa ID {kID} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Krevet sa ID {kID} nije pronađen.");
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
                nekretnina.Parking.Add(parking);

                session.Save(parking);
                session.Flush();
                MessageBox.Show("Novi parking je uspešno dodat.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Parking sa ID {pID} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za parking sa ID {pID} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Parking sa ID {pID} nije pronađen.");
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
                    MessageBox.Show($"Parking sa ID {pID} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Parking sa ID {pID} nije pronađen.");
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
                SajtoviNekretnine sajtIzdavanja = new()
                {
                    ID = sajtID
                };
                nekretnina.SajtoviNekretnine.Add(sajtIzdavanja);

                session.Save(sajtIzdavanja);
                session.Flush();
                MessageBox.Show("Novi sajt nekretnine je uspešno dodat.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za sajt nekretnine sa sajtom {izmenjeniSajt.Sajt} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Sajt nekretnine sa sajtom {izmenjeniSajt.Sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
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
                    MessageBox.Show($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Sajt nekretnine sa sajtom {sajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
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
                MessageBox.Show("Novi broj telefona je uspešno dodat.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Broj telefona sa brojem {brojTelefona} i JMBG-om {jmbgFizickogLica} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za broj telefona {izmenjeniBroj.BrojTelefona} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Broj telefona sa brojem {izmenjeniBroj.BrojTelefona} i JMBG-om {jmbgFizickogLica} nije pronađen.");
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
                    MessageBox.Show($"Broj telefona {brojTelefona} za fizičko lice sa JMBG-om {jmbgFizickogLica} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Broj telefona {brojTelefona} za fizičko lice sa JMBG-om {jmbgFizickogLica} nije pronađen.");
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
                MessageBox.Show("Novi telefon kontakt osobe je uspešno dodat.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Telefon kontakt osobe sa brojem {brojTelefona} i PIB-om {pibPravnogLica} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za telefon kontakt osobe {izmenjeniTelefon.BrojTelefona} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Telefon kontakt osobe sa brojem {izmenjeniTelefon.BrojTelefona} i PIB-om {pibPravnogLica} nije pronađen.");
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
                    MessageBox.Show($"Telefon kontakt osobe {brojTelefona} za pravno lice sa PIB-om {pibPravnogLica} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Telefon kontakt osobe {brojTelefona} za pravno lice sa PIB-om {pibPravnogLica} nije pronađen.");
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
                MessageBox.Show("Nova soba je uspešno dodata.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Soba sa ID {sID} nije pronađena.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za sobu sa ID {sID} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Soba sa ID {sID} nije pronađena.");
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
                    MessageBox.Show($"Soba sa ID {sID} je obrisana.");
                }
                else
                {
                    MessageBox.Show($"Soba sa ID {sID} nije pronađena.");
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
                MessageBox.Show("Nova zajednička prostorija je uspešno dodata.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Zajednička prostorija sa ID {zpID} nije pronađena.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za zajedničku prostoriju sa ID {zpID} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Zajednička prostorija sa ID {zpID} nije pronađena.");
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
                    MessageBox.Show($"Zajednička prostorija sa ID {zpID} je obrisana.");
                }
                else
                {
                    MessageBox.Show($"Zajednička prostorija sa ID {zpID} nije pronađena.");
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

    #region Najam

    public static void DodajNajam(NajamBasic noviNajam, int idNekretnine, string mbrAgenta, int? idSpoljnogSaradnika = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Nekretnina nekretnina = session.Load<Nekretnina>(idNekretnine);
                Agent agent = session.Load<Agent>(mbrAgenta);
                SpoljniSaradnik spoljni;
                if (idSpoljnogSaradnika.HasValue)
                {
                    SpoljniSaradnikId ssID = new()
                    {
                        AgentAngazovanja = agent,
                        IdSaradnika = idSpoljnogSaradnika.Value
                    };
                    spoljni = session.Load<SpoljniSaradnik>(ssID);
                }
                else
                {
                    spoljni = null;
                }
                double zaradaOdDodatnihUsluga = 0;
                foreach (var dop in nekretnina.DodatnaOprema)
                {
                    zaradaOdDodatnihUsluga += dop.CenaKoriscenja ?? 0;
                }
                foreach (var p in nekretnina.Parking)
                {
                    zaradaOdDodatnihUsluga += p.Cena ?? 0;
                }
                Najam najam = new Najam
                {
                    DatumPocetka = noviNajam.DatumPocetka,
                    DatumZavrsetka = noviNajam.DatumZavrsetka,
                    BrojDana = (noviNajam.DatumZavrsetka - noviNajam.DatumPocetka).Days,
                    CenaPoDanu = noviNajam.CenaPoDanu,
                    Popust = noviNajam.Popust > 0 ? noviNajam.Popust : null,
                    CenaSaPopustom = noviNajam.Popust > 0 ? noviNajam.CenaPoDanu - (noviNajam.CenaPoDanu / (100/noviNajam.Popust)) : null,
                    ZaradaOdDodatnihUsluga = zaradaOdDodatnihUsluga,
                    UkupnaCena = noviNajam.Popust > 0 ? noviNajam.CenaSaPopustom * noviNajam.BrojDana + zaradaOdDodatnihUsluga : noviNajam.CenaPoDanu * noviNajam.BrojDana + zaradaOdDodatnihUsluga,
                    ProvizijaAgencije = noviNajam.ProvizijaAgencije,
                    Nekretnina = nekretnina,
                    Agent = agent,
                    SpoljniSaradnik = spoljni
                };
                agent.RealizovaniNajmovi.Add(najam);
                nekretnina.Najmovi.Add(najam);
                if (spoljni != null)
                {
                    spoljni.RealizovaniNajmovi.Add(najam);
                }


                session.Save(najam);
                session.Flush();
                MessageBox.Show("Novi najam je uspešno dodat.");
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

    public static List<NajamPregled> VratiSveNajmove()
    {
        List<NajamPregled> najmovi = new List<NajamPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Najam> sviNajmovi = from n 
                                                in session.Query<Najam>()
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return najmovi;
    }

    public static List<NajamPregled> VratiSveNajmoveNekretnine(int idNekretnine)
    {
        List<NajamPregled> najmovi = new List<NajamPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<Najam> sviNajmovi = from n 
                                                in session.Query<Najam>()
                                                where n.Nekretnina.IdNekretnine == idNekretnine
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Najam sa ID {idNajma} nije pronađen.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
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
                    MessageBox.Show($"Podaci za najam sa ID {izmenjenNajam.IdNajma} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Najam sa ID {izmenjenNajam.IdNajma} nije pronađen.");
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
                    MessageBox.Show($"Najam sa ID {idNajma} je obrisan.");
                }
                else
                {
                    MessageBox.Show($"Najam sa ID {idNajma} nije pronađen.");
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

    #region IznajmljenaSoba
    public static void DodajIznajmljenuSobu(IznajmljenaSobaBasic novaSoba, int idNekretnine, int idSobe, int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Soba soba = session.Load<Soba>(new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                Najam najam = session.Load<Najam>(idNajma);

                IznajmljenaSobaId iznID = new()
                { 
                    Soba = soba.ID,
                    Najam = najam
                };

                IznajmljenaSoba iznajmljenaSoba = new()
                {
                    ID = iznID
                };

                session.Save(iznajmljenaSoba);
                session.Flush();
                MessageBox.Show("Iznajmljena soba je uspešno dodata.");
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

    public static List<IznajmljenaSobaPregled> VratiSveIznajmljeneSobe()
    {
        List<IznajmljenaSobaPregled> iznajmljeneSobe = new List<IznajmljenaSobaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<IznajmljenaSoba> sveSobe = from s 
                                                       in session.Query<IznajmljenaSoba>() 
                                                       select s;

                foreach (IznajmljenaSoba s in sveSobe)
                {
                    iznajmljeneSobe.Add(new IznajmljenaSobaPregled(
                        s.ID.Soba.IdSobe,
                        s.ID.Soba.Nekretnina.IdNekretnine,
                        new NajamPregled(
                            s.ID.Najam.IdNajma,
                            s.ID.Najam.DatumPocetka,
                            s.ID.Najam.DatumZavrsetka,
                            s.ID.Najam.CenaPoDanu,
                            s.ID.Najam.Popust,
                            s.ID.Najam.ZaradaOdDodatnihUsluga,
                            s.ID.Najam.ProvizijaAgencije,
                            s.ID.Najam.Nekretnina.Ulica + " " + s.ID.Najam.Nekretnina.Broj,
                            s.ID.Najam.Agent.Ime,
                            s.ID.Najam.SpoljniSaradnik?.Ime ?? string.Empty
                        )
                    ));
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

        return iznajmljeneSobe;
    }

    public static IznajmljenaSobaPregled VratiIznajmljenuSobu(int idSobe, int idNekretnine, int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IznajmljenaSobaId id = new IznajmljenaSobaId
                {
                    Soba = new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) },
                    Najam = session.Load<Najam>(idNajma)
                };

                IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
                if (iznajmljenaSoba != null)
                {
                    return new IznajmljenaSobaPregled(
                        iznajmljenaSoba.ID.Soba.IdSobe,
                        iznajmljenaSoba.ID.Soba.Nekretnina.IdNekretnine,
                        new NajamPregled(
                            iznajmljenaSoba.ID.Najam.IdNajma,
                            iznajmljenaSoba.ID.Najam.DatumPocetka,
                            iznajmljenaSoba.ID.Najam.DatumZavrsetka,
                            iznajmljenaSoba.ID.Najam.CenaPoDanu,
                            iznajmljenaSoba.ID.Najam.Popust,
                            iznajmljenaSoba.ID.Najam.ZaradaOdDodatnihUsluga,
                            iznajmljenaSoba.ID.Najam.ProvizijaAgencije,
                            iznajmljenaSoba.ID.Najam.Nekretnina.Ulica + " " + iznajmljenaSoba.ID.Najam.Nekretnina.Broj,
                            iznajmljenaSoba.ID.Najam.Agent.Ime,
                            iznajmljenaSoba.ID.Najam.SpoljniSaradnik?.Ime ?? string.Empty
                        )
                    );
                }
                else
                {
                    MessageBox.Show($"Iznajmljena soba nije pronađena.");
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
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static void IzmeniIznajmljenuSobu(IznajmljenaSobaBasic izmenjenaSoba, int idNekretnine, int idSobe, int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IznajmljenaSobaId id = new IznajmljenaSobaId
                {
                    Soba = new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) },
                    Najam = session.Load<Najam>(idNajma)
                };

                IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
                if (iznajmljenaSoba != null)
                {
                    iznajmljenaSoba.ID.Soba = new SobaId 
                    { 
                        IdSobe = izmenjenaSoba.Soba.IdSobe, 
                        Nekretnina = session.Load<Nekretnina>(izmenjenaSoba.Soba.Nekretnina.IdNekretnine) 
                    };
                    iznajmljenaSoba.ID.Najam = session.Load<Najam>(izmenjenaSoba.Najam.IdNajma);

                    session.Update(iznajmljenaSoba);
                    session.Flush();
                    MessageBox.Show($"Podaci za iznajmljenu sobu su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Iznajmljena soba nije pronađena.");
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

    public static void ObrisiIznajmljenuSobu(int idSobe, int idNekretnine, int idNajma)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IznajmljenaSobaId id = new()
                {
                    Soba = new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) },
                    Najam = session.Load<Najam>(idNajma)
                };

                IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
                if (iznajmljenaSoba != null)
                {
                    session.Delete(iznajmljenaSoba);
                    session.Flush();
                    MessageBox.Show($"Iznajmljena soba je obrisana.");
                }
                else
                {
                    MessageBox.Show($"Iznajmljena soba nije pronađena.");
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
}

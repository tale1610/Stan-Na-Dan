using NHibernate;

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
                Poslovnica poslovnica = session.Load<Poslovnica>(poslovnicaBasic.ID);
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
                Poslovnica poslovnica = session.Load<Poslovnica>(id);
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
                Zaposleni zaposleni = session.Load<Zaposleni>(mbr);
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
                Agent agent = session.Get<Agent>(mbr);
                if (agent != null)
                {
                    PoslovnicaBasic poslovnicaBasic = new PoslovnicaBasic(agent.Poslovnica.ID, agent.Poslovnica.Adresa, agent.Poslovnica.RadnoVreme, agent.Poslovnica.Sef);
                    agentBasic = new AgentBasic(agent.MBR, agent.Ime, agent.Prezime, agent.DatumZaposlenja, agent.StrucnaSprema, poslovnicaBasic);
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

    public static void IzmeniAgenta(AgentBasic agentBasic)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Agent agent = session.Get<Agent>(agentBasic.MBR);

                if (agent != null)
                {
                    agent.Ime = agentBasic.Ime;
                    agent.Prezime = agentBasic.Prezime;
                    agent.DatumZaposlenja = agentBasic.DatumZaposlenja;
                    agent.StrucnaSprema = agentBasic.StrucnaSprema;

                    session.Update(agent);
                    session.Flush();

                    MessageBox.Show($"Podaci za agenta sa MBR {agentBasic.MBR} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Agent sa MBR {agentBasic.MBR} nije pronađen.");
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

    public static SefBasic vratiSefa(string mbr)
    {
        SefBasic sefBasic = new SefBasic();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();

            if (session != null && session.IsOpen)
            {
                Sef sef = session.Get<Sef>(mbr);
                if (sef != null)
                {
                    PoslovnicaBasic poslovnicaBasic = new PoslovnicaBasic(
                        sef.Poslovnica.ID, 
                        sef.Poslovnica.Adresa, 
                        sef.Poslovnica.RadnoVreme, 
                        sef.Poslovnica.Sef
                        );
                    sefBasic = new SefBasic(
                        sef.MBR,
                        sef.Ime, 
                        sef.Prezime, 
                        sef.DatumZaposlenja, 
                        sef.DatumPostavljanja, 
                        poslovnicaBasic
                        );
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
        return sefBasic;
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

    public static void IzmeniSefa(SefBasic izmenjeniSef)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Sef sef = session.Get<Sef>(izmenjeniSef.MBR);
                if (sef != null)
                {
                    sef.Ime = izmenjeniSef.Ime;
                    sef.Prezime = izmenjeniSef.Prezime;
                    sef.DatumZaposlenja = izmenjeniSef.DatumZaposlenja;
                    sef.DatumPostavljanja = izmenjeniSef.DatumPostavljanja;

                    session.Update(sef);
                    session.Flush();
                    MessageBox.Show($"Podaci za šefa sa MBR {izmenjeniSef.MBR} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Šef sa MBR {izmenjeniSef.MBR} nije pronađen.");
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
                SpoljniSaradnik spoljniSaradnik = session.Load<SpoljniSaradnik>(ssID);
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

    public static FizickoLiceBasic VratiFizickoLice(string jmbg)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Get<FizickoLice>(jmbg);
                if (fizickoLice != null)
                {
                    VlasnikBasic vlasnikPregled = new VlasnikBasic(fizickoLice.Vlasnik.IdVlasnika, fizickoLice.Vlasnik.Banka, fizickoLice.Vlasnik.BrojBankovnogRacuna);
                    return new FizickoLiceBasic(fizickoLice.JMBG, fizickoLice.Ime, fizickoLice.ImeRoditelja, fizickoLice.Prezime, fizickoLice.Drzava, fizickoLice.MestoStanovanja, fizickoLice.AdresaStanovanja, fizickoLice.DatumRodjenja, fizickoLice.Email, vlasnikPregled);
                }
                else
                {
                    MessageBox.Show($"Fizicko lice sa JMBG {jmbg} nije pronađeno.");
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

    public static void IzmeniFizickoLice(FizickoLiceBasic izmenjenoFizickoLice)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Get<FizickoLice>(izmenjenoFizickoLice.JMBG);
                if (fizickoLice != null)
                {
                    fizickoLice.Ime = izmenjenoFizickoLice.Ime;
                    fizickoLice.Prezime = izmenjenoFizickoLice.Prezime;
                    fizickoLice.ImeRoditelja = izmenjenoFizickoLice.ImeRoditelja;
                    fizickoLice.MestoStanovanja = izmenjenoFizickoLice.MestoStanovanja;
                    fizickoLice.AdresaStanovanja = izmenjenoFizickoLice.AdresaStanovanja;
                    fizickoLice.DatumRodjenja = izmenjenoFizickoLice.DatumRodjenja;
                    fizickoLice.Drzava = izmenjenoFizickoLice.Drzava;
                    fizickoLice.Email = izmenjenoFizickoLice.Email;

                    fizickoLice.Vlasnik.Banka = izmenjenoFizickoLice.Vlasnik.Banka;
                    fizickoLice.Vlasnik.BrojBankovnogRacuna = izmenjenoFizickoLice.Vlasnik.BrojBankovnogRacuna;

                    session.Update(fizickoLice);
                    session.Flush();
                    MessageBox.Show($"Podaci za fizicko lice sa JMBG {izmenjenoFizickoLice.JMBG} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Fizicko lice sa JMBG {izmenjenoFizickoLice.JMBG} nije pronađeno.");
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

    public static void ObrisiFizickoLice(string jmbg)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                FizickoLice fizickoLice = session.Get<FizickoLice>(jmbg);
                if (fizickoLice != null)
                {
                    session.Delete(fizickoLice);
                    session.Flush();
                    MessageBox.Show($"Fizicko lice sa JMBG {jmbg} je obrisano.");
                }
                else
                {
                    MessageBox.Show($"Fizicko lice sa JMBG {jmbg} nije pronađeno.");
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

    public static PravnoLiceBasic vratiPravnoLice(string pib)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Get<PravnoLice>(pib);
                if (pravnoLice != null)
                {
                    VlasnikBasic vlasnikPregled = new VlasnikBasic(pravnoLice.Vlasnik.IdVlasnika, pravnoLice.Vlasnik.Banka, pravnoLice.Vlasnik.BrojBankovnogRacuna);
                    return new PravnoLiceBasic(pravnoLice.PIB, pravnoLice.Naziv, pravnoLice.AdresaSedista, pravnoLice.ImeKontaktOsobe, pravnoLice.EmailKontaktOsobe, vlasnikPregled);
                }
                else
                {
                    MessageBox.Show($"Pravno lice sa PIB {pib} nije pronađeno.");
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

    public static void izmeniPravnoLice(PravnoLiceBasic izmenjenoPravnoLice)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Get<PravnoLice>(izmenjenoPravnoLice.PIB);
                if (pravnoLice != null)
                {
                    pravnoLice.Naziv = izmenjenoPravnoLice.Naziv;
                    pravnoLice.AdresaSedista = izmenjenoPravnoLice.AdresaSedista;
                    pravnoLice.ImeKontaktOsobe = izmenjenoPravnoLice.ImeKontaktOsobe;
                    pravnoLice.EmailKontaktOsobe = izmenjenoPravnoLice.EmailKontaktOsobe;
                    pravnoLice.Vlasnik.Banka = izmenjenoPravnoLice.Vlasnik.Banka;
                    pravnoLice.Vlasnik.BrojBankovnogRacuna = izmenjenoPravnoLice.Vlasnik.BrojBankovnogRacuna;

                    session.Update(pravnoLice);
                    session.Flush();
                    MessageBox.Show($"Podaci za pravno lice sa PIB {izmenjenoPravnoLice.PIB} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Pravno lice sa PIB {izmenjenoPravnoLice.PIB} nije pronađeno.");
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

    public static void obrisiPravnoLice(string pib)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                PravnoLice pravnoLice = session.Get<PravnoLice>(pib);
                if (pravnoLice != null)
                {
                    session.Delete(pravnoLice);
                    session.Flush();
                    MessageBox.Show($"Pravno lice sa PIB {pib} je obrisano.");
                }
                else
                {
                    MessageBox.Show($"Pravno lice sa PIB {pib} nije pronađeno.");
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

    public static List<NekretninaPregled> VratiSveNekretnine()
    {
        List<NekretninaPregled> nekretnine = new List<NekretninaPregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                IEnumerable<StanNaDan.Entiteti.Stan> sviStanovi = from stan
                                                                  in session.Query<StanNaDan.Entiteti.Stan>()
                                                                  select stan;

                foreach (StanNaDan.Entiteti.Stan s in sviStanovi)
                {
                    nekretnine.Add(new StanPregled(
                        s.IdNekretnine,
                        s.Ulica,
                        s.Broj,
                        s.Kvadratura,
                        s.BrojTerasa,
                        s.BrojKupatila,
                        s.BrojSpavacihSoba,
                        s.PosedujeTV,
                        s.PosedujeInternet,
                        s.PosedujeKuhinju,
                        s.Kvart.GradskaZona,
                        s.Vlasnik.IdVlasnika,
                        s.Sprat,
                        s.PosedujeLift));
                }

                IEnumerable<StanNaDan.Entiteti.Kuca> sveKuce = from kuca
                                                                in session.Query<StanNaDan.Entiteti.Kuca>()
                                                               select kuca;

                foreach (StanNaDan.Entiteti.Kuca k in sveKuce)
                {
                    nekretnine.Add(new KucaPregled(
                        k.IdNekretnine,
                        k.Ulica,
                        k.Broj,
                        k.Kvadratura,
                        k.BrojTerasa,
                        k.BrojKupatila,
                        k.BrojSpavacihSoba,
                        k.PosedujeTV,
                        k.PosedujeInternet,
                        k.PosedujeKuhinju,
                        k.Kvart.GradskaZona,
                        k.Vlasnik.IdVlasnika,
                        k.Spratnos,
                        k.PosedujeDvoriste));
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
                IEnumerable<StanNaDan.Entiteti.Stan> sviStanovi = from stan
                                                                  in session.Query<StanNaDan.Entiteti.Stan>()
                                                                  where stan.Kvart.ID == idKvarta
                                                                  select stan;

                foreach (StanNaDan.Entiteti.Stan s in sviStanovi)
                {
                    nekretnine.Add(new StanPregled(
                        s.IdNekretnine,
                        s.Ulica,
                        s.Broj,
                        s.Kvadratura,
                        s.BrojTerasa,
                        s.BrojKupatila,
                        s.BrojSpavacihSoba,
                        s.PosedujeTV,
                        s.PosedujeInternet,
                        s.PosedujeKuhinju,
                        s.Kvart.GradskaZona,
                        s.Vlasnik.IdVlasnika,
                        s.Sprat,
                        s.PosedujeLift));
                }

                IEnumerable<StanNaDan.Entiteti.Kuca> sveKuce = from kuca
                                                               in session.Query<StanNaDan.Entiteti.Kuca>()
                                                               where kuca.Kvart.ID == idKvarta
                                                               select kuca;

                foreach (StanNaDan.Entiteti.Kuca k in sveKuce)
                {
                    nekretnine.Add(new KucaPregled(
                        k.IdNekretnine,
                        k.Ulica,
                        k.Broj,
                        k.Kvadratura,
                        k.BrojTerasa,
                        k.BrojKupatila,
                        k.BrojSpavacihSoba,
                        k.PosedujeTV,
                        k.PosedujeInternet,
                        k.PosedujeKuhinju,
                        k.Kvart.GradskaZona,
                        k.Vlasnik.IdVlasnika,
                        k.Spratnos,
                        k.PosedujeDvoriste));
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
                IEnumerable<StanNaDan.Entiteti.Stan> sviStanovi = from stan
                                                                  in session.Query<StanNaDan.Entiteti.Stan>()
                                                                  where stan.Vlasnik.IdVlasnika == idVlasnika
                                                                  select stan;

                foreach (StanNaDan.Entiteti.Stan s in sviStanovi)
                {
                    nekretnine.Add(new StanPregled(
                        s.IdNekretnine,
                        s.Ulica,
                        s.Broj,
                        s.Kvadratura,
                        s.BrojTerasa,
                        s.BrojKupatila,
                        s.BrojSpavacihSoba,
                        s.PosedujeTV,
                        s.PosedujeInternet,
                        s.PosedujeKuhinju,
                        s.Kvart.GradskaZona,
                        s.Vlasnik.IdVlasnika,
                        s.Sprat,
                        s.PosedujeLift));
                }

                IEnumerable<StanNaDan.Entiteti.Kuca> sveKuce = from kuca
                                                               in session.Query<StanNaDan.Entiteti.Kuca>()
                                                               where kuca.Vlasnik.IdVlasnika == idVlasnika
                                                               select kuca;

                foreach (StanNaDan.Entiteti.Kuca k in sveKuce)
                {
                    nekretnine.Add(new KucaPregled(
                        k.IdNekretnine,
                        k.Ulica,
                        k.Broj,
                        k.Kvadratura,
                        k.BrojTerasa,
                        k.BrojKupatila,
                        k.BrojSpavacihSoba,
                        k.PosedujeTV,
                        k.PosedujeInternet,
                        k.PosedujeKuhinju,
                        k.Kvart.GradskaZona,
                        k.Vlasnik.IdVlasnika,
                        k.Spratnos,
                        k.PosedujeDvoriste));
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

    public static NekretninaBasic VratiNekretninu(int idNekretnine)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Stan stan = session.Get<Stan>(idNekretnine);
                if (stan != null)
                {
                    KvartBasic kvartBasic = new()
                    {    
                        IdKvarta = stan.Kvart.ID,
                        GradskaZona = stan.Kvart.GradskaZona
                    };

                    VlasnikBasic vlasnikBasic = new()
                    {
                        IdVlasnika = stan.Vlasnik.IdVlasnika,
                        Banka = stan.Vlasnik.Banka,
                        BrojBankovnogRacuna = stan.Vlasnik.BrojBankovnogRacuna
                    };

                    return new StanBasic(
                        stan.IdNekretnine,
                        stan.Ulica,
                        stan.Broj,
                        stan.Kvadratura,
                        stan.BrojTerasa,
                        stan.BrojKupatila,
                        stan.BrojSpavacihSoba,
                        stan.PosedujeTV,
                        stan.PosedujeInternet,
                        stan.PosedujeKuhinju,
                        kvartBasic,
                        vlasnikBasic,
                        stan.Sprat,
                        stan.PosedujeLift
                    );
                }
                else
                {
                    Kuca kuca = session.Get<Kuca>(idNekretnine);
                    if (kuca != null)
                    {
                        KvartBasic kvartBasic = new()
                        {
                            IdKvarta = kuca.Kvart.ID,
                            GradskaZona = kuca.Kvart.GradskaZona
                        };

                        VlasnikBasic vlasnikBasic = new()
                        {
                            IdVlasnika = kuca.Vlasnik.IdVlasnika,
                            Banka = kuca.Vlasnik.Banka,
                            BrojBankovnogRacuna = kuca.Vlasnik.BrojBankovnogRacuna
                        };

                        return new KucaBasic(
                            kuca.IdNekretnine,
                            kuca.Ulica,
                            kuca.Broj,
                            kuca.Kvadratura,
                            kuca.BrojTerasa,
                            kuca.BrojKupatila,
                            kuca.BrojSpavacihSoba,
                            kuca.PosedujeTV,
                            kuca.PosedujeInternet,
                            kuca.PosedujeKuhinju,
                            kvartBasic,
                            vlasnikBasic,
                            kuca.Spratnos,
                            kuca.PosedujeDvoriste
                        );
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
        return null;
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
                    MessageBox.Show($"Podaci za nekretninu sa ID {izmenjenaNekretnina.IdNekretnine} su izmenjeni.");
                }
                else
                {
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

    public static void IzmeniStan(StanBasic izmenjenStan, int idVlasnika)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Stan stan = session.Get<Stan>(izmenjenStan.IdNekretnine);
                Vlasnik vlasnik = session.Get<Vlasnik>(idVlasnika);
                if (stan != null)
                {
                    if (vlasnik != null)
                    {
                        stan.Ulica = izmenjenStan.Ulica;
                        stan.Broj = izmenjenStan.Broj;
                        stan.Kvadratura = izmenjenStan.Kvadratura;
                        stan.BrojTerasa = izmenjenStan.BrojTerasa;
                        stan.BrojKupatila = izmenjenStan.BrojKupatila;
                        stan.BrojSpavacihSoba = izmenjenStan.BrojSpavacihSoba;
                        stan.PosedujeTV = izmenjenStan.PosedujeTV;
                        stan.PosedujeInternet = izmenjenStan.PosedujeInternet;
                        stan.PosedujeKuhinju = izmenjenStan.PosedujeKuhinju;
                        stan.Vlasnik = vlasnik;
                        stan.Sprat = izmenjenStan.Sprat;
                        stan.PosedujeLift = izmenjenStan.PosedujeLift;
                    }

                    session.Update(stan);
                    session.Flush();
                    MessageBox.Show($"Podaci za stan sa ID {izmenjenStan.IdNekretnine} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Stan sa ID {izmenjenStan.IdNekretnine} nije pronađen.");
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

    public static void IzmeniKucu(KucaBasic izmenjenaKuca, int idVlasnika)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Kuca kuca = session.Get<Kuca>(izmenjenaKuca.IdNekretnine);
                Vlasnik vlasnik = session.Get<Vlasnik>(idVlasnika);
                if (kuca != null)
                {
                    if (vlasnik != null)
                    {
                        kuca.Ulica = izmenjenaKuca.Ulica;
                        kuca.Broj = izmenjenaKuca.Broj;
                        kuca.Kvadratura = izmenjenaKuca.Kvadratura;
                        kuca.BrojTerasa = izmenjenaKuca.BrojTerasa;
                        kuca.BrojKupatila = izmenjenaKuca.BrojKupatila;
                        kuca.BrojSpavacihSoba = izmenjenaKuca.BrojSpavacihSoba;
                        kuca.PosedujeTV = izmenjenaKuca.PosedujeTV;
                        kuca.PosedujeInternet = izmenjenaKuca.PosedujeInternet;
                        kuca.PosedujeKuhinju = izmenjenaKuca.PosedujeKuhinju;
                        kuca.Vlasnik = vlasnik;
                        kuca.Spratnos = izmenjenaKuca.Spratnost;
                        kuca.PosedujeDvoriste = izmenjenaKuca.PosedujeDvoriste;
                    }

                    session.Update(kuca);
                    session.Flush();
                    MessageBox.Show($"Podaci za kuću sa ID {izmenjenaKuca.IdNekretnine} su izmenjeni.");
                }
                else
                {
                    MessageBox.Show($"Kuća sa ID {izmenjenaKuca.IdNekretnine} nije pronađena.");
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

    public static KrevetBasic VratiKrevet(int idKreveta, int idNekretnine)
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
                    return new KrevetBasic(
                        krevet.ID.IdKreveta,
                        new NekretninaBasic
                        {
                            IdNekretnine = nekretnina.IdNekretnine,
                            Ulica = nekretnina.Ulica,
                            Broj = nekretnina.Broj,
                            Kvadratura = nekretnina.Kvadratura,
                            BrojTerasa = nekretnina.BrojTerasa,
                            BrojKupatila = nekretnina.BrojKupatila,
                            BrojSpavacihSoba = nekretnina.BrojSpavacihSoba,
                            PosedujeTV = nekretnina.PosedujeTV,
                            PosedujeInternet = nekretnina.PosedujeInternet,
                            PosedujeKuhinju = nekretnina.PosedujeKuhinju
                        },
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

    public static ParkingBasic VratiParking(int idParkinga, int idNekretnine)
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
                    return new ParkingBasic(
                        parking.ID.IdParkinga,
                        new NekretninaBasic
                        {
                            IdNekretnine = nekretnina.IdNekretnine,
                            Ulica = nekretnina.Ulica,
                            Broj = nekretnina.Broj,
                            Kvadratura = nekretnina.Kvadratura,
                            BrojTerasa = nekretnina.BrojTerasa,
                            BrojKupatila = nekretnina.BrojKupatila,
                            BrojSpavacihSoba = nekretnina.BrojSpavacihSoba,
                            PosedujeTV = nekretnina.PosedujeTV,
                            PosedujeInternet = nekretnina.PosedujeInternet,
                            PosedujeKuhinju = nekretnina.PosedujeKuhinju
                        },
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

    public static SajtoviNekretnineBasic VratiSajtNekretnine(string sajt, int idNekretnine)
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
                    return new SajtoviNekretnineBasic(
                        sajtNekretnine.ID.Sajt,
                        new NekretninaBasic
                        {
                            IdNekretnine = nekretnina.IdNekretnine,
                            Ulica = nekretnina.Ulica,
                            Broj = nekretnina.Broj,
                            Kvadratura = nekretnina.Kvadratura,
                            BrojTerasa = nekretnina.BrojTerasa,
                            BrojKupatila = nekretnina.BrojKupatila,
                            BrojSpavacihSoba = nekretnina.BrojSpavacihSoba,
                            PosedujeTV = nekretnina.PosedujeTV,
                            PosedujeInternet = nekretnina.PosedujeInternet,
                            PosedujeKuhinju = nekretnina.PosedujeKuhinju
                        }
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

    public static void IzmeniSajtNekretnine(SajtoviNekretnineBasic izmenjeniSajt, string stariSajt, int idNekretnine)
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
                    Sajt = stariSajt,
                    Nekretnina = nekretnina
                };
                SajtoviNekretnine sajtNekretnine = session.Get<SajtoviNekretnine>(sID);
                SajtoviNekretnineId noviID = new()
                {
                    Sajt = izmenjeniSajt.Sajt,
                    Nekretnina = nekretnina
                };
                if (sajtNekretnine != null)
                {
                    session.Delete(sajtNekretnine);
                    session.Flush();

                    sajtNekretnine = new SajtoviNekretnine { ID = noviID };

                    nekretnina.SajtoviNekretnine.Add(sajtNekretnine);

                    session.Save(sajtNekretnine);
                    session.Flush();

                    //session.Update(sajtNekretnine);
                    //session.Flush();
                    MessageBox.Show($"Izmenjen je sajt za nekretninu: {nekretnina.IdNekretnine}.");
                }
                else
                {
                    MessageBox.Show($"Sajt nekretnine sa sajtom {stariSajt} i ID-om nekretnine {idNekretnine} nije pronađen.");
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
                nekretnina.Sobe.Add(soba);

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
    public static List<SobaPregled> VratiSveSobe()
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

    public static SobaBasic VratiSobu(int idSobe, int idNekretnine)
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
                    SobaId sID = new()
                    {
                        IdSobe = idSobe,
                        Nekretnina = nekretnina
                    };
                    Soba soba = session.Get<Soba>(sID);
                    if (soba != null)
                    {
                        NekretninaBasic nekretninaBasic = new()
                        {
                            IdNekretnine = nekretnina.IdNekretnine,
                            Ulica = nekretnina.Ulica,
                            Broj = nekretnina.Broj,
                            Kvadratura = nekretnina.Kvadratura,
                            BrojTerasa = nekretnina.BrojTerasa,
                            BrojKupatila = nekretnina.BrojKupatila,
                            BrojSpavacihSoba = nekretnina.BrojSpavacihSoba,
                            PosedujeTV = nekretnina.PosedujeTV,
                            PosedujeInternet = nekretnina.PosedujeInternet,
                            PosedujeKuhinju = nekretnina.PosedujeKuhinju
                        };
                        return new SobaBasic(
                            soba.ID.IdSobe,
                            nekretninaBasic
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
                    MessageBox.Show($"Nekretnina sa ID {idNekretnine} nije pronađena.");
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

    public static List<ZajednickeProstorijePregled> VratiSveZajednickeProstorijeSobe(int idSobe, int idNekretnine)
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

    public static List<ZajednickeProstorijePregled> VratiSveZajednickeProstorijeNajma(int idNajma)
    {
        List<ZajednickeProstorijePregled> prostorije = new List<ZajednickeProstorijePregled>();
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                var sveProstorije = session.Query<ZajednickeProstorije>()
                                    .Where(zp => session.Query<IznajmljenaSoba>()
                                         .Any(iznajmljena => iznajmljena.ID.Najam.IdNajma == idNajma &&
                                           iznajmljena.ID.Soba.ID.Nekretnina.IdNekretnine == zp.ID.Soba.ID.Nekretnina.IdNekretnine &&
                                           iznajmljena.ID.Soba.ID.IdSobe == zp.ID.Soba.ID.IdSobe))
                                     .Select(zp => new ZajednickeProstorijePregled(
                                              zp.ID.Soba.ID.Nekretnina.IdNekretnine,
                                              zp.ID.Soba.ID.IdSobe,
                                              zp.ID.ZajednickaProstorija))
                                     .Distinct().ToList();

                prostorije.AddRange(sveProstorije);
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
    public static Najam KreirajNajam(NajamBasic noviNajam, int idNekretnine, string mbrAgenta, int? idSpoljnogSaradnika = null)
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
                if (idSpoljnogSaradnika > 0)
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
                    CenaSaPopustom = noviNajam.Popust > 0 ? noviNajam.CenaPoDanu - (noviNajam.CenaPoDanu / (100 / noviNajam.Popust)) : null,
                    ZaradaOdDodatnihUsluga = zaradaOdDodatnihUsluga,
                    UkupnaCena = noviNajam.Popust > 0 ? noviNajam.CenaSaPopustom * noviNajam.BrojDana + zaradaOdDodatnihUsluga : noviNajam.CenaPoDanu * noviNajam.BrojDana + zaradaOdDodatnihUsluga,
                    ProvizijaAgencije = noviNajam.ProvizijaAgencije,
                    Nekretnina = nekretnina,
                    Agent = agent,
                    SpoljniSaradnik = spoljni
                };
                if (najam.Popust >= 99 || najam.Popust <= 1)
                {
                    throw new Exception("Los popust, mora izmedju 1 i 99");
                }
                agent.RealizovaniNajmovi.Add(najam);
                nekretnina.Najmovi.Add(najam);
                if (spoljni != null)
                {
                    spoljni.RealizovaniNajmovi.Add(najam);
                }
                
                return najam;
            }
            else return null;
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

    public static void DodajNajam(NajamBasic noviNajam, int idNekretnine, string mbrAgenta, int? idSpoljnogSaradnika = null)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Najam najam = KreirajNajam(noviNajam, idNekretnine, mbrAgenta, idSpoljnogSaradnika);
                
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

    public static NajamBasic VratiNajam(int idNajma)
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
                    return new NajamBasic
                    {  
                        IdNajma = najam.IdNajma,
                        DatumPocetka = najam.DatumPocetka,
                        DatumZavrsetka = najam.DatumZavrsetka,
                        CenaPoDanu = najam.CenaPoDanu,
                        Popust = najam.Popust ?? 0,
                        ZaradaOdDodatnihUsluga = najam.ZaradaOdDodatnihUsluga,
                        ProvizijaAgencije = najam.ProvizijaAgencije
                    };
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
    public static void DodajIznajmljenuSobu(IznajmljenaSobaBasic novaSoba, int idNekretnine, List<int> idSoba, string mbrAgenta, int? idSpoljnog)
    {
        ISession? session = null;
        try
        {
            session = DataLayer.GetSession();
            if (session != null && session.IsOpen)
            {
                Najam najam = KreirajNajam(novaSoba.Najam, idNekretnine, mbrAgenta, idSpoljnog);
                List<Soba> sobe = [];
                List<IznajmljenaSoba> iznajmljeneSobe = [];
                foreach(int idS in idSoba)
                {
                    Soba soba = session.Load<Soba>(new SobaId { IdSobe = idS, Nekretnina = session.Load<Nekretnina>(idNekretnine) });
                    sobe.Add(soba);
                    IznajmljenaSobaId iznID = new()
                    {
                        Soba = soba,
                        Najam = najam
                    };
                    iznajmljeneSobe.Add(new() { ID = iznID });
                    //if (!soba.Najmovi.Contains(najam) && !soba.IznajmljivanjaSobe.Contains(iznajmljenaSoba))
                    //{
                    //    //soba.Najmovi.Add(najam);//nije mi vise jasno sto zeza ali ne radi sa njim  
                    //    //soba.IznajmljivanjaSobe.Add(iznajmljenaSoba);
                    //}
                }
                //najam.Sobe = sobe;
                najam.IznajmljivanjaSoba = iznajmljeneSobe;

                session.SaveOrUpdate(najam);
                session.Flush();
                MessageBox.Show("Iznajmljivanje sobe je uspešno dodato.");
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
                        s.ID.Soba.ID.IdSobe,
                        s.ID.Soba.ID.Nekretnina.IdNekretnine,
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
                SobaId sID = new() { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) };
                IznajmljenaSobaId id = new IznajmljenaSobaId
                {

                    Soba = new Soba { ID = sID },
                    Najam = session.Load<Najam>(idNajma)
                };

                IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
                if (iznajmljenaSoba != null)
                {
                    return new IznajmljenaSobaPregled(
                        iznajmljenaSoba.ID.Soba.ID.IdSobe,
                        iznajmljenaSoba.ID.Soba.ID.Nekretnina.IdNekretnine,
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
                    Soba = new Soba { ID = new() {IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) }},
                    Najam = session.Load<Najam>(idNajma)
                };

                IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
                if (iznajmljenaSoba != null)
                {
                    Najam najam = iznajmljenaSoba.ID.Najam;
                    session.Delete(iznajmljenaSoba);
                    session.Flush();
                    if (najam.IznajmljivanjaSoba.Count == 0)
                    {
                        session.Delete(najam);
                        session.Flush();
                    }
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

    //public static void IzmeniIznajmljenuSobu(IznajmljenaSobaBasic izmenjenaSoba, int idNekretnine, int idSobe, int idNajma)
    //{
    //    ISession? session = null;
    //    try
    //    {
    //        session = DataLayer.GetSession();
    //        if (session != null && session.IsOpen)
    //        {
    //            IznajmljenaSobaId id = new IznajmljenaSobaId
    //            {
    //                Soba = new SobaId { IdSobe = idSobe, Nekretnina = session.Load<Nekretnina>(idNekretnine) },
    //                Najam = session.Load<Najam>(idNajma)
    //            };

    //            IznajmljenaSoba iznajmljenaSoba = session.Get<IznajmljenaSoba>(id);
    //            if (iznajmljenaSoba != null)
    //            {
    //                iznajmljenaSoba.ID.Soba = new SobaId 
    //                { 
    //                    IdSobe = izmenjenaSoba.Soba.IdSobe, 
    //                    Nekretnina = session.Load<Nekretnina>(izmenjenaSoba.Soba.Nekretnina.IdNekretnine) 
    //                };
    //                iznajmljenaSoba.ID.Najam = session.Load<Najam>(izmenjenaSoba.Najam.IdNajma);

    //                session.Update(iznajmljenaSoba);
    //                session.Flush();
    //                MessageBox.Show($"Podaci za iznajmljenu sobu su izmenjeni.");
    //            }
    //            else
    //            {
    //                MessageBox.Show($"Iznajmljena soba nije pronađena.");
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.FormatExceptionMessage());
    //    }
    //    finally
    //    {
    //        session?.Close();
    //    }
    //}
    #endregion
}

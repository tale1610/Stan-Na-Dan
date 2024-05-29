namespace StanNaDan;

#region Poslovnica
public class PoslovnicaBasic
{
    public int ID { get; set; }
    public string Adresa { get; set; }
    public string RadnoVreme { get; set; }
    public Sef Sef { get; set; }
    public virtual IList<Zaposleni> Zaposleni { get; set; } = [];

    public virtual IList<Kvart> Kvartovi { get; set; } = [];

    public PoslovnicaBasic()
    {

    }
    public PoslovnicaBasic(int id, string adresa, string radnoVreme, Sef sef)
    {
        this.ID = id;
        this.Adresa = adresa;
        this.RadnoVreme = radnoVreme;
        this.Sef = sef;
    }
}

public class PoslovnicaPregled
{
    public int ID { get; set; }
    public string Adresa { get; set; }
    public string RadnoVreme { get; set; }
    public string ImeSefa { get; set; }

    public PoslovnicaPregled()
    {

    }
    public PoslovnicaPregled(int id, string adresa, string radnoVreme, string imeSefa)
    {
        this.ID = id;
        this.Adresa = adresa;
        this.RadnoVreme = radnoVreme;
        this.ImeSefa = imeSefa;
    }
}

#endregion

#region Zaposleni
public class ZaposleniBasic
{
    public string MBR { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumZaposlenja { get; set; }
    public PoslovnicaBasic Poslovnica { get; set; }

    //dodaj za spoljnog radnika kad stignes dotle valjda samo to

    public ZaposleniBasic()
    {

    }
    public ZaposleniBasic(string MBR, string ime, string prezime, DateTime datumZaposlenja, PoslovnicaBasic poslovnica)
    {
        this.MBR = MBR;
        this.Ime = ime;
        this.Prezime = prezime;
        this.DatumZaposlenja = datumZaposlenja;
        this.Poslovnica = poslovnica;
    }
}

//sad to i za agenta sefa i ostalog
public class SefBasic : ZaposleniBasic
{
    public DateTime? DatumPostavljanja { get; set; }
    public SefBasic(string MBR, string ime, string prezime, DateTime datumZaposlenja, DateTime? datumPostavljanja, PoslovnicaBasic poslovnica) :base(MBR, ime, prezime, datumZaposlenja, poslovnica)
    {
        this.DatumPostavljanja = datumPostavljanja;
    }
    public SefBasic() 
    {
        
    }
}

public class AgentBasic: ZaposleniBasic
{
    public string StrucnaSprema { get; set; }
    public AgentBasic(string MBR, string ime, string prezime, DateTime datumZaposlenja, string strucnaSprema, PoslovnicaBasic poslovnica) : base(MBR, ime, prezime, datumZaposlenja, poslovnica)
    {
        this.StrucnaSprema = strucnaSprema;
    }
    public AgentBasic()
    {

    }
}

public class ZaposleniOstaloBasic: ZaposleniBasic
{
    public ZaposleniOstaloBasic(string MBR, string ime, string prezime, DateTime datumZaposlenja, PoslovnicaBasic poslovnica) : base(MBR, ime, prezime, datumZaposlenja, poslovnica)
    {
    }
}

public class ZaposleniPregled
{
    public string MBR { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumZaposlenja { get; set; }
    public string AdresaPoslovnice { get; set; }
    public string Pozicija { get; set; }

    public ZaposleniPregled()
    {

    }
    public ZaposleniPregled(string MBR, string ime, string preziem, DateTime datumZaposlenja, string adresaPoslovnice, string pozicija)
    {
        this.MBR = MBR;
        this.Ime = ime;
        this.Prezime = preziem;
        this.DatumZaposlenja = datumZaposlenja;
        this.AdresaPoslovnice = adresaPoslovnice;
        this.Pozicija = pozicija;
    }
}
//opet isto to i za sefa i agenta i ostalo, ali sad razmisli da l da izbacis svuda iz pregled poslovnicu mada msm da ne treba
public class SefPregled : ZaposleniPregled
{
    public DateTime? DatumPostavljanja { get; set; }
    public SefPregled(string MBR, string ime, string prezime, DateTime datumZaposlenja, string adresaPoslovnice, string pozicija, DateTime? datumPostavljanja) : base(MBR, ime, prezime, datumZaposlenja, adresaPoslovnice, pozicija)
    {
        this.DatumPostavljanja = datumPostavljanja;
    }
}

public class AgentPregled : ZaposleniPregled
{
    public string StrucnaSprema { get; set; }
    public AgentPregled(string MBR, string ime, string prezime, DateTime datumZaposlenja, string strucnaSprema, string adresaPoslovnice, string pozicija) : base(MBR, ime, prezime, datumZaposlenja, adresaPoslovnice, pozicija)
    {
        this.StrucnaSprema = strucnaSprema;
    }
}

public class ZaposleniOstaloPregled : ZaposleniPregled
{
    public ZaposleniOstaloPregled(string MBR, string ime, string prezime, DateTime datumZaposlenja, string adresaPoslovnice, string pozicija) : base(MBR, ime, prezime, datumZaposlenja, adresaPoslovnice, pozicija)
    {
    }
}

#endregion

#region SpoljniSaradnik
public class SpoljniSaradnikBasic
{
    public AgentBasic AgentAngazovanja { get; set; }
    public int IdSaradnika { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumAngazovanja { get; set; }
    public string Telefon { get; set; }
    public double ProcenatOdNajma { get; set; }
    //public IList<NajamBasic> RealizovaniNajmovi { get; set; } = []; //OBAVEZNO UKLJUCUJ POSLE KAD URADIS NAJAM

    public SpoljniSaradnikBasic()
    {
        //RealizovaniNajmovi = new List<NajamBasic>();
    }

    public SpoljniSaradnikBasic(AgentBasic agentAngazovanja, int idSaradnika, string ime, string prezime, DateTime datumAngazovanja, string telefon, double procenatOdNajma)
    {
        AgentAngazovanja = agentAngazovanja;
        IdSaradnika = idSaradnika;
        Ime = ime;
        Prezime = prezime;
        DatumAngazovanja = datumAngazovanja;
        Telefon = telefon;
        ProcenatOdNajma = procenatOdNajma;
        //RealizovaniNajmovi = new List<NajamBasic>();
    }
}

public class SpoljniSaradnikPregled
{
    public string MbrAgenta { get; set; }
    public int IdSaradnika { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumAngazovanja { get; set; }
    public string Telefon { get; set; }
    public double ProcenatOdNajma { get; set; }

    public SpoljniSaradnikPregled() { }

    public SpoljniSaradnikPregled(string mbr, int idSaradnika, string ime, string prezime, DateTime datumAngazovanja, string telefon, double procenatOdNajma)
    {
        MbrAgenta = mbr;
        IdSaradnika = idSaradnika;
        Ime = ime;
        Prezime = prezime;
        DatumAngazovanja = datumAngazovanja;
        Telefon = telefon;
        ProcenatOdNajma = procenatOdNajma;
    }
}
#endregion

#region Kvart
public class KvartBasic
{
    public int IdKvarta { get; set; }
    public string GradskaZona { get; set; }
    public PoslovnicaBasic PoslovnicaZaduzenaZaNjega { get; set; }

    public KvartBasic() { }

    public KvartBasic(int idKvarta, string gradskaZona, PoslovnicaBasic poslovnicaZaduzenaZaNjega)
    {
        IdKvarta = idKvarta;
        GradskaZona = gradskaZona;
        PoslovnicaZaduzenaZaNjega = poslovnicaZaduzenaZaNjega;
    }
}
public class KvartPregled
{
    public int IdKvarta { get; set; }
    public string GradskaZona { get; set; }
    public string AdresaPoslovnice { get; set; }

    public KvartPregled() { }

    public KvartPregled(int idKvarta, string gradskaZona, string adresaPoslovnice)
    {
        IdKvarta = idKvarta;
        GradskaZona = gradskaZona;
        AdresaPoslovnice = adresaPoslovnice;
    }
}

#endregion

#region Vlasnik
public class VlasnikBasic
{
    public int IdVlasnika { get; set; }
    public string Banka { get; set; }
    public string BrojBankovnogRacuna { get; set; }

    public VlasnikBasic() { }

    public VlasnikBasic(int idVlasnika, string banka, string brojBankovnogRacuna)
    {
        IdVlasnika = idVlasnika;
        Banka = banka;
        BrojBankovnogRacuna = brojBankovnogRacuna;
    }
}

public class VlasnikPregled
{
    public int IdVlasnika { get; set; }
    public string Banka { get; set; }
    public string BrojBankovnogRacuna { get; set; }

    public VlasnikPregled() { }

    public VlasnikPregled(int idVlasnika, string banka, string brojBankovnogRacuna)
    {
        IdVlasnika = idVlasnika;
        Banka = banka;
        BrojBankovnogRacuna = brojBankovnogRacuna;
    }
}

//FizickoLice
public class FizickoLiceBasic
{
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string ImeRoditelja { get; set; }
    public string Prezime { get; set; }
    public string Drzava { get; set; }
    public string MestoStanovanja { get; set; }
    public string AdresaStanovanja { get; set; }
    public DateTime DatumRodjenja { get; set; }
    public string Email { get; set; }
    public VlasnikBasic Vlasnik { get; set; }

    public FizickoLiceBasic() { }

    public FizickoLiceBasic(string jmbg, string ime, string imeRoditelja, string prezime, string drzava, string mestoStanovanja, string adresaStanovanja, DateTime datumRodjenja, string email, VlasnikBasic vlasnik)
    {
        JMBG = jmbg;
        Ime = ime;
        ImeRoditelja = imeRoditelja;
        Prezime = prezime;
        Drzava = drzava;
        MestoStanovanja = mestoStanovanja;
        AdresaStanovanja = adresaStanovanja;
        DatumRodjenja = datumRodjenja;
        Email = email;
        Vlasnik = vlasnik;
    }
}
public class FizickoLicePregled
{
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string ImeRoditelja { get; set; }
    public string Prezime { get; set; }
    public string Drzava { get; set; }
    public string MestoStanovanja { get; set; }
    public string AdresaStanovanja { get; set; }
    public DateTime DatumRodjenja { get; set; }
    public string Email { get; set; }
    public VlasnikPregled Vlasnik { get; set; }

    public FizickoLicePregled() { }

    public FizickoLicePregled(string jmbg, string ime, string imeRoditelja, string prezime, string drzava, string mestoStanovanja, string adresaStanovanja, DateTime datumRodjenja, string email, VlasnikPregled vlasnik)
    {
        JMBG = jmbg;
        Ime = ime;
        ImeRoditelja = imeRoditelja;
        Prezime = prezime;
        Drzava = drzava;
        MestoStanovanja = mestoStanovanja;
        AdresaStanovanja = adresaStanovanja;
        DatumRodjenja = datumRodjenja;
        Email = email;
        Vlasnik = vlasnik;
    }
}

//Pravno lice
public class PravnoLiceBasic
{
    public string PIB { get; set; }
    public string Naziv { get; set; }
    public string AdresaSedista { get; set; }
    public string ImeKontaktOsobe { get; set; }
    public string EmailKontaktOsobe { get; set; }
    public VlasnikBasic Vlasnik { get; set; }

    public PravnoLiceBasic() { }

    public PravnoLiceBasic(string pib, string naziv, string adresaSedista, string imeKontaktOsobe, string emailKontaktOsobe, VlasnikBasic vlasnik)
    {
        PIB = pib;
        Naziv = naziv;
        AdresaSedista = adresaSedista;
        ImeKontaktOsobe = imeKontaktOsobe;
        EmailKontaktOsobe = emailKontaktOsobe;
        Vlasnik = vlasnik;
    }
}
public class PravnoLicePregled
{
    public string PIB { get; set; }
    public string Naziv { get; set; }
    public string AdresaSedista { get; set; }
    public string ImeKontaktOsobe { get; set; }
    public string EmailKontaktOsobe { get; set; }
    public VlasnikPregled Vlasnik { get; set; }

    public PravnoLicePregled() { }

    public PravnoLicePregled(string pib, string naziv, string adresaSedista, string imeKontaktOsobe, string emailKontaktOsobe, VlasnikPregled vlasnik)
    {
        PIB = pib;
        Naziv = naziv;
        AdresaSedista = adresaSedista;
        ImeKontaktOsobe = imeKontaktOsobe;
        EmailKontaktOsobe = emailKontaktOsobe;
        Vlasnik = vlasnik;
    }
}

#endregion

#region Nekretnina
public class NekretninaBasic
{
    public int IdNekretnine { get; set; }

    public string Tip { get; set; }

    public string Ulica { get; set; }
    public string Broj { get; set; }
    public double Kvadratura { get; set; }
    public int BrojTerasa { get; set; }
    public int BrojKupatila { get; set; }
    public int BrojSpavacihSoba { get; set; }
    public bool PosedujeTV { get; set; }
    public bool PosedujeInternet { get; set; }
    public bool PosedujeKuhinju { get; set; }
    //public PoslovnicaBasic Poslovnica { get; set; } // Ovo dodaj ako je neophodno, ako ne, možeš izostaviti
    //veze
    virtual public KvartBasic Kvart { get; set; }
    virtual public VlasnikBasic Vlasnik { get; set; }
    virtual public IList<DodatnaOprema> DodatnaOprema { get; set; } = [];
    virtual public IList<Parking> Parking { get; set; } = [];
    virtual public IList<Krevet> Kreveti { get; set; } = [];
    virtual public IList<Soba> Sobe { get; set; } = [];
    virtual public IList<SajtoviNekretnine> SajtoviNekretnine { get; set; } = [];
    virtual public IList<Najam> Najmovi { get; set; } = [];

    public NekretninaBasic() { }

    public NekretninaBasic(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, KvartBasic kvart, VlasnikBasic vlasnik, string tip)
    {
        IdNekretnine = idNekretnine;
        Ulica = ulica;
        Broj = broj;
        Kvadratura = kvadratura;
        BrojTerasa = brojTerasa;
        BrojKupatila = brojKupatila;
        BrojSpavacihSoba = brojSpavacihSoba;
        PosedujeTV = posedujeTV;
        PosedujeInternet = posedujeInternet;
        PosedujeKuhinju = posedujeKuhinju;
        Kvart = kvart;
        Vlasnik = vlasnik;

        Tip = tip;
    }
}

public class NekretninaPregled
{
    public int IdNekretnine { get; set; }

    public string Tip { get; set; }

    public string Ulica { get; set; }
    public string Broj { get; set; }
    public double Kvadratura { get; set; }
    public int BrojTerasa { get; set; }
    public int BrojKupatila { get; set; }
    public int BrojSpavacihSoba { get; set; }
    public bool PosedujeTV { get; set; }
    public bool PosedujeInternet { get; set; }
    public bool PosedujeKuhinju { get; set; }
    //public string AdresaPoslovnice { get; set; } // Dodaj ako je neophodno
    public string GradskaZona { get; set; }
    public int IdVlasnika { get; set; }

    public NekretninaPregled() { }

    public NekretninaPregled(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, string gradskaZona, int idVlasnika, string tip)
    {
        IdNekretnine = idNekretnine;
        Ulica = ulica;
        Broj = broj;
        Kvadratura = kvadratura;
        BrojTerasa = brojTerasa;
        BrojKupatila = brojKupatila;
        BrojSpavacihSoba = brojSpavacihSoba;
        PosedujeTV = posedujeTV;
        PosedujeInternet = posedujeInternet;
        PosedujeKuhinju = posedujeKuhinju;
        GradskaZona = gradskaZona;
        IdVlasnika = idVlasnika;

        Tip = tip;
    }
}

// Implementacija klasa Stan i Kuca

public class StanBasic : NekretninaBasic
{
    public int Sprat { get; set; }
    public bool PosedujeLift { get; set; }

    public StanBasic() { }

    public StanBasic(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, KvartBasic kvart, VlasnikBasic vlasnik, int sprat, bool posedujeLift)
        : base(idNekretnine, ulica, broj, kvadratura, brojTerasa, brojKupatila, brojSpavacihSoba, posedujeTV, posedujeInternet, posedujeKuhinju, kvart, vlasnik, "Stan")
    {
        Sprat = sprat;
        PosedujeLift = posedujeLift;
    }
}

public class StanPregled : NekretninaPregled
{
    public int Sprat { get; set; }
    public bool PosedujeLift { get; set; }

    public StanPregled() { }

    public StanPregled(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, string gradskaZona, int idVlasnika, int sprat, bool posedujeLift)
        : base(idNekretnine, ulica, broj, kvadratura, brojTerasa, brojKupatila, brojSpavacihSoba, posedujeTV, posedujeInternet, posedujeKuhinju, gradskaZona, idVlasnika, "Stan")
    {
        Sprat = sprat;
        PosedujeLift = posedujeLift;
    }
}

public class KucaBasic : NekretninaBasic
{
    public int Spratnost { get; set; }
    public bool PosedujeDvoriste { get; set; }

    public KucaBasic() { }

    public KucaBasic(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, KvartBasic kvart, VlasnikBasic vlasnik, int spratnost, bool posedujeDvoriste)
        : base(idNekretnine, ulica, broj, kvadratura, brojTerasa, brojKupatila, brojSpavacihSoba, posedujeTV, posedujeInternet, posedujeKuhinju, kvart, vlasnik, "Kuca")
    {
        Spratnost = spratnost;
        PosedujeDvoriste = posedujeDvoriste;
    }
}

public class KucaPregled : NekretninaPregled
{
    public int Spratnost { get; set; }
    public bool PosedujeDvoriste { get; set; }

    public KucaPregled() { }

    public KucaPregled(int idNekretnine, string ulica, string broj, double kvadratura, int brojTerasa, int brojKupatila, int brojSpavacihSoba, bool posedujeTV, bool posedujeInternet, bool posedujeKuhinju, string gradskaZona, int idVlasnika, int spratnost, bool posedujeDvoriste)
        : base(idNekretnine, ulica, broj, kvadratura, brojTerasa, brojKupatila, brojSpavacihSoba, posedujeTV, posedujeInternet, posedujeKuhinju, gradskaZona, idVlasnika, "Kuca")
    {
        Spratnost = spratnost;
        PosedujeDvoriste = posedujeDvoriste;
    }
}
#endregion

#region BrojeviTelefona
public class BrojeviTelefonaBasic
{
    public string BrojTelefona { get; set; }
    public FizickoLiceBasic FizickoLice { get; set; }

    public BrojeviTelefonaBasic() { }

    public BrojeviTelefonaBasic(string brojTelefona, FizickoLiceBasic fizickoLice)
    {
        BrojTelefona = brojTelefona;
        FizickoLice = fizickoLice;
    }
}

public class BrojeviTelefonaPregled
{
    public string BrojTelefona { get; set; }
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }

    public BrojeviTelefonaPregled() { }

    public BrojeviTelefonaPregled(string brojTelefona, string jmbg, string ime, string prezime)
    {
        BrojTelefona = brojTelefona;
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
    }
}
#endregion

#region DodatnaOprema

public class DodatnaOpremaBasic
{
    public int IdOpreme { get; set; }
    public NekretninaBasic Nekretnina { get; set; }
    public string TipOpreme { get; set; }
    public bool BesplatnoKoriscenje { get; set; }
    public double? CenaKoriscenja { get; set; }

    public DodatnaOpremaBasic() { }

    public DodatnaOpremaBasic(int id, NekretninaBasic nBasic, string tipOpreme, bool besplatnoKoriscenje, double? cenaKoriscenja)
    {
        IdOpreme = id;
        Nekretnina = nBasic;
        TipOpreme = tipOpreme;
        BesplatnoKoriscenje = besplatnoKoriscenje;
        CenaKoriscenja = cenaKoriscenja;
    }
}

public class DodatnaOpremaPregled
{
    public int IdOpreme { get; set; }
    public int IdNekretnine { get; set; }
    public string TipOpreme { get; set; }
    public bool BesplatnoKoriscenje { get; set; }
    public double? CenaKoriscenja { get; set; }

    public DodatnaOpremaPregled() { }

    public DodatnaOpremaPregled(int id, int idNekretnine, string tipOpreme, bool besplatnoKoriscenje, double? cenaKoriscenja)
    {
        IdOpreme = id;
        IdNekretnine = idNekretnine;
        TipOpreme = tipOpreme;
        BesplatnoKoriscenje = besplatnoKoriscenje;
        CenaKoriscenja = cenaKoriscenja;
    }
}

#endregion

#region IznajmljenaSoba

public class IznajmljenaSobaBasic
{
    public SobaBasic Soba { get; set; }
    public NajamBasic Najam { get; set; }

    public IznajmljenaSobaBasic() { }

    public IznajmljenaSobaBasic(SobaBasic soba, NajamBasic najam)
    {
        Soba = soba;
        Najam = najam;
    }
}

public class IznajmljenaSobaPregled
{
    public int IdSobe { get; set; }
    public int IdNekretnine { get; set; }
    public NajamPregled Najam { get; set; }

    public IznajmljenaSobaPregled() { }

    public IznajmljenaSobaPregled(int idSobe, int idNekretnine, NajamPregled najam)
    {
        IdSobe = idSobe;
        IdNekretnine = idNekretnine;
        Najam = najam;
    }
}

#endregion

#region Krevet

public class KrevetBasic
{
    public int IdKreveta { get; set; }
    public NekretninaBasic Nekretnina { get; set; }
    public string Tip { get; set; }
    public string Dimenzije { get; set; }

    public KrevetBasic() { }

    public KrevetBasic(int id, NekretninaBasic nekretnina, string tip, string dimenzije)
    {
        IdKreveta = id;
        Nekretnina = nekretnina;
        Tip = tip;
        Dimenzije = dimenzije;
    }
}

public class KrevetPregled
{
    public int IdKreveta { get; set; }
    public int IdNekretnine { get; set; }
    public string Tip { get; set; }
    public string Dimenzije { get; set; }

    public KrevetPregled() { }

    public KrevetPregled(int idKreveta, int idNekretnine, string tip, string dimenzije)
    {
        IdKreveta = idKreveta;
        IdNekretnine = idNekretnine;
        Tip = tip;
        Dimenzije = dimenzije;
    }
}

#endregion

#region Najam

public class NajamBasic
{
    public int IdNajma { get; set; }
    public DateTime DatumPocetka { get; set; }
    public DateTime DatumZavrsetka { get; set; }
    public int BrojDana { get; set; }
    public double CenaPoDanu { get; set; }
    public int Popust { get; set; } // Popust u procentima
    public double CenaSaPopustom { get; set; } //dnevno
    public double ZaradaOdDodatnihUsluga { get; set; }
    public double UkupnaCena { get; set; }
    public double ProvizijaAgencije { get; set; }

    // veze:
    public NekretninaBasic Nekretnina { get; set; }
    public AgentBasic Agent { get; set; }
    public SpoljniSaradnikBasic? SpoljniSaradnik { get; set; }
    //public IList<IznajmljenaSobaBasic>? Sobe { get; set; }

    public NajamBasic() { }

    public NajamBasic(int idNajma, DateTime datumPocetka, DateTime datumZavrsetka, double cenaPoDanu, int popust, double zaradaOdDodatnihUsluga, double provizijaAgencije, NekretninaBasic nekretnina, AgentBasic agent, SpoljniSaradnikBasic? spoljniSaradnik/*, IList<IznajmljenaSobaBasic>? sobe*/)
    {
        IdNajma = idNajma;
        DatumPocetka = datumPocetka;
        DatumZavrsetka = datumZavrsetka;
        BrojDana = (DatumZavrsetka - DatumPocetka).Days;
        CenaPoDanu = cenaPoDanu;
        Popust = popust;
        CenaSaPopustom = popust > 0 ? CenaPoDanu - (CenaPoDanu / (100 / Popust)) : 0;
        ZaradaOdDodatnihUsluga = zaradaOdDodatnihUsluga;
        UkupnaCena = popust > 0 ? CenaSaPopustom * BrojDana + ZaradaOdDodatnihUsluga : cenaPoDanu * BrojDana + ZaradaOdDodatnihUsluga;
        ProvizijaAgencije = provizijaAgencije;
        Nekretnina = nekretnina;
        Agent = agent;
        SpoljniSaradnik = spoljniSaradnik;
        //Sobe = sobe;
    }
}

public class NajamPregled
{
    public int IdNajma { get; set; }
    public DateTime DatumPocetka { get; set; }
    public DateTime DatumZavrsetka { get; set; }
    public int BrojDana { get; set; }
    public double CenaPoDanu { get; set; }
    public int? Popust { get; set; } // Popust u procentima
    public double? CenaSaPopustom { get; set; }
    public double ZaradaOdDodatnihUsluga { get; set; }
    public double? UkupnaCena { get; set; }
    public double ProvizijaAgencije { get; set; }

    // veze:
    public string AdresaNekretnine { get; set; }
    public string ImeAgenta { get; set; }
    public string ImeSpoljnogSaradnika { get; set; }
    //public IList<int>? IdSoba { get; set; }

    public NajamPregled() { }

    public NajamPregled(int idNajma, DateTime datumPocetka, DateTime datumZavrsetka, double cenaPoDanu, int? popust, double zaradaOdDodatnihUsluga, double provizijaAgencije, string adresaNekretnine, string imeAgenta, string imeSpoljnogSaradnika/*, IList<int>? idSoba*/)
    {
        IdNajma = idNajma;
        DatumPocetka = datumPocetka;
        DatumZavrsetka = datumZavrsetka;
        BrojDana = (DatumZavrsetka - DatumPocetka).Days;
        CenaPoDanu = cenaPoDanu;
        Popust = popust;
        CenaSaPopustom = Popust > 0 ? CenaPoDanu - (CenaPoDanu / (100 / Popust)) : 0;
        ZaradaOdDodatnihUsluga = zaradaOdDodatnihUsluga;
        UkupnaCena = Popust > 0 ? CenaSaPopustom * BrojDana + ZaradaOdDodatnihUsluga : cenaPoDanu * BrojDana + ZaradaOdDodatnihUsluga;
        ProvizijaAgencije = provizijaAgencije;
        AdresaNekretnine = adresaNekretnine;
        ImeAgenta = imeAgenta;
        ImeSpoljnogSaradnika = imeSpoljnogSaradnika;
        //IdSoba = idSoba;
    }
}

#endregion

#region Parking

public class ParkingBasic
{
    public int IdParkinga { get; set; }
    public NekretninaBasic Nekretnina { get; set; }
    public bool Besplatan { get; set; }
    public double? Cena { get; set; }
    public bool USastavuNekretnine { get; set; }
    public bool USastavuJavnogParkinga { get; set; }

    public ParkingBasic() { }

    public ParkingBasic(int id, NekretninaBasic nekretnina, bool besplatan, double? cena, bool uSastavuNekretnine, bool uSastavuJavnogParkinga)
    {
        IdParkinga = id;
        Nekretnina = nekretnina;
        Besplatan = besplatan;
        Cena = cena;
        USastavuNekretnine = uSastavuNekretnine;
        USastavuJavnogParkinga = uSastavuJavnogParkinga;
    }
}

public class ParkingPregled
{
    public int IdParkinga { get; set; }
    public int IdNekretnine { get; set; }
    public bool Besplatan { get; set; }
    public double? Cena { get; set; }
    public bool USastavuNekretnine { get; set; }
    public bool USastavuJavnogParkinga { get; set; }

    public ParkingPregled() { }

    public ParkingPregled(int idParkinga, int idNekretnine, bool besplatan, double? cena, bool uSastavuNekretnine, bool uSastavuJavnogParkinga)
    {
        IdParkinga = idParkinga;
        IdNekretnine = idNekretnine;
        Besplatan = besplatan;
        Cena = cena;
        USastavuNekretnine = uSastavuNekretnine;
        USastavuJavnogParkinga = uSastavuJavnogParkinga;
    }
}

#endregion

#region SajtoviNekretnine

public class SajtoviNekretnineBasic
{
    public string Sajt { get; set; }
    public NekretninaBasic Nekretnina { get; set; }

    public SajtoviNekretnineBasic() { }

    public SajtoviNekretnineBasic(string sajt, NekretninaBasic nekretnina)
    {
        Sajt = sajt;
        Nekretnina = nekretnina;
    }
}

public class SajtoviNekretninePregled
{
    public string Sajt { get; set; }
    public int IdNekretnine { get; set; }
    public string AdresaNekretnine { get; set; }

    public SajtoviNekretninePregled() { }

    public SajtoviNekretninePregled(string sajt, int idNekretnine, string adresaNekretnine)
    {
        Sajt = sajt;
        IdNekretnine = idNekretnine;
        AdresaNekretnine = adresaNekretnine;
    }
}

#endregion

#region Soba

public class SobaBasic
{
    public int IdSobe { get; set; }
    public NekretninaBasic Nekretnina { get; set; }
    //public IList<IznajmljenaSoba> Najmovi { get; set; } = new List<IznajmljenaSoba>();
    //public IList<ZajednickeProstorije> ZajednickeProstorije { get; set; } = new List<ZajednickeProstorije>();

    public SobaBasic() { }

    public SobaBasic(int idSobe, NekretninaBasic nekretnina)
    {
        IdSobe = idSobe;
        Nekretnina = nekretnina;
    }
}

public class SobaPregled
{
    public int IdSobe { get; set; }
    public int IdNekretnine { get; set; }

    public SobaPregled() { }

    public SobaPregled(int idSobe, int idNekretnine)
    {
        IdSobe = idSobe;
        IdNekretnine = idNekretnine;
    }
}

#endregion

#region TelefoniKontaktOsobe

public class TelefoniKontaktOsobeBasic
{
    public string BrojTelefona { get; set; }
    public PravnoLiceBasic PravnoLice { get; set; }

    public TelefoniKontaktOsobeBasic() { }

    public TelefoniKontaktOsobeBasic(string brojTelefona, PravnoLiceBasic pravnoLice)
    {
        BrojTelefona = brojTelefona;
        PravnoLice = pravnoLice;
    }
}

public class TelefoniKontaktOsobePregled
{
    public string BrojTelefona { get; set; }
    public string PIB { get; set; }
    public string Naziv { get; set; }
    public string ImeKontaktOsobe { get; set; }
    // Dodaj ovde ostale atribute koje želiš koristiti iz klase PravnoLice

    public TelefoniKontaktOsobePregled() { }

    public TelefoniKontaktOsobePregled(string brojTelefona, string pib, string naziv, string imeKontaktOsobe)
    {
        BrojTelefona = brojTelefona;
        PIB = pib;
        Naziv = naziv;
        ImeKontaktOsobe = imeKontaktOsobe;
    }
}

#endregion

#region ZajednickeProstorije

public class ZajednickeProstorijeBasic
{
    public Soba Soba { get; set; }
    public string ZajednickaProstorija { get; set; }

    public ZajednickeProstorijeBasic() { }

    public ZajednickeProstorijeBasic(Soba soba, string zajednickaProstorija)
    {
        Soba = soba;
        ZajednickaProstorija = zajednickaProstorija;
    }
}

public class ZajednickeProstorijePregled
{
    public int IdNekretnine { get; set; }
    public int IdSobe { get; set; }
    public string ZajednickaProstorija { get; set; }

    public ZajednickeProstorijePregled() { }

    public ZajednickeProstorijePregled(int idNekretnine, int idSobe, string zajednicka)
    {
        IdNekretnine = idNekretnine;
        IdSobe = idSobe;
        ZajednickaProstorija = zajednicka;
    }
}

#endregion
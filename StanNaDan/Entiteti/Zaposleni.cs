namespace StanNaDan.Entiteti
{
    public class Zaposleni
    {
        virtual public required string MBR { get; set; }
        virtual public required string  Ime { get; set; }
        virtual public required string Prezime { get; set; }
        virtual public required DateTime DatumZaposlenja { get; set; }
        virtual public Poslovnica? Poslovnica { get; set; }
    }

    public class Sef : Zaposleni
    {
        virtual public required DateTime? DatumPostavljanja { get; set; }
    }

    public class Agent : Zaposleni
    {
        virtual public string? StrucnaSprema { get; set; }
        //veze
        virtual public IList<SpoljniSaradnik> AngazovaniSaradnici { get; set; } = [];
        virtual public IList<Najam> RealizovaniNajmovi { get; set; } = [];
    }

    public class Radnik : Zaposleni
    {

    }
}


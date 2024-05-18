namespace StanNaDan.Entiteti
{
    public class Nekretnina
    {
        virtual public required int IdNekretnine { get; set; }
        virtual public required string Ulica { get; set; }
        virtual public required string Broj { get; set; }
        virtual public required double Kvadratura { get; set; }
        virtual public required int BrojTerasa { get; set; }
        virtual public required int BrojKupatila { get; set; }
        virtual public required int BrojSpavacihSoba { get; set; }
        virtual public required bool PosedujeTV { get; set; }
        virtual public required bool PosedujeInternet { get; set; }
        virtual public required bool PosedujeKuhinju { get; set; }
        virtual public required string TipNekretnine { get; set; }

        //veze
        virtual public required Kvart Kvart { get; set; }
        virtual public required Vlasnik Vlasnik { get; set; }
        virtual public IList<DodatnaOprema> DodatnaOprema { get; set; } = [];
        virtual public IList<Parking> Parking { get; set; } = [];
        virtual public IList<Krevet> Kreveti { get; set; } = [];
        virtual public IList<Soba> Sobe {  get; set; } = [];
        virtual public IList<SajtoviNekretnine> SajtoviNekretnine { get; set; } = [];
        virtual public IList<Najam> Najmovi { get; set; } = [];
    }
}

public class Stan: Nekretnina
{
    public int Sprat { get; set; }
    public bool PosedujeLift { get; set; }
}

public class Kuca: Nekretnina
{
    public int Spratnos { get; set; }
    public bool PosedujeDvoriste { get; set; }
}
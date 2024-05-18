namespace StanNaDan.Entiteti
{
    public class Soba
    {
        //surogat kljuc
        virtual public int ID { get; protected set; }
        virtual public required int IdSobe { get; set; }
        //veza
        virtual public required Nekretnina Nekretnina { get; set; }
        virtual public IList<IznajmljenaSoba> IznajmljivanjaSobe { get; set; } = [];
        virtual public IList<ZajednickeProstorije> ZajednickeProstorije { get; set; } = [];
    }
}

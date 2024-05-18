namespace StanNaDan.Entiteti
{
    public class Soba
    {
        //surogat kljuc
        virtual public required int ID { get; protected set; }
        virtual public required int IdSobe { get; set; }
        //veza
        virtual public required Nekretnina Nekretnina { get; set; }
    }
}

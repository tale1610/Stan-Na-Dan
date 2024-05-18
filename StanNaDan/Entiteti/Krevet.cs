namespace StanNaDan.Entiteti
{
    public class Krevet
    {
        //surogat kljuc
        virtual public int ID { get; protected set; }
        virtual public required Nekretnina Nekretnina { get; set;}
        virtual public required int IdKreveta { get; set;}
        virtual public required string Tip { get; set;}
        virtual public required string Dimenzije { get; set;}
    }
}

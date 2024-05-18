namespace StanNaDan.Entiteti
{
    public class Parking
    {
        //surogat kljuc
        virtual public int ID { get; protected set; }
        virtual public required Nekretnina Nekretnina { get; set; }
        virtual public required int IdParkinga { get; set; }
        virtual public required bool Besplatan { get; set; }
        virtual public double Cena { get; set; }
        virtual public required bool USastavuNekretnine { get; set; }
        virtual public required bool USastavuJavnogParkinga { get; set; }

    }
}

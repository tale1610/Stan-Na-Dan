namespace StanNaDan.Entiteti
{
    public class SajtoviNekretnine
    {
        virtual public int ID { get; protected set; }
        virtual public required string Sajt { get; set; }
        virtual public required Nekretnina Nekretnina { get; set; }
    }
}

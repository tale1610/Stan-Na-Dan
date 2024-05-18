namespace StanNaDan.Entiteti
{
    public class IznajmljenaSoba
    {
        public int ID { get; protected set; }
        public required Soba Soba { get; set; }
        public required Nekretnina Nekretnina { get; set; }
        //dodaj vezu za najam kad kreiras tu klasu
    }
}

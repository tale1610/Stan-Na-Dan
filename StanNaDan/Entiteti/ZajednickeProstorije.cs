namespace StanNaDan.Entiteti
{
    public class ZajednickeProstorije
    {
        virtual public int ID { get; protected set; }
        virtual public required Soba Soba { get; set; }
        virtual public required string ZajednickaProstorija { get; set; }
    }
}

namespace StanNaDan.Entiteti
{
    public class SpoljniSaradnik
    {
        virtual public required SpoljniSaradnikId ID { get; set; }
        virtual public required string Ime { get; set; }
        virtual public required string Prezime { get; set; }
        virtual public required DateTime DatumAngazovanja { get; set; }
        virtual public required string Telefon { get; set; }
        virtual public required double ProcenatOdNajma { get; set; }

        //veza
        virtual public IList<Najam> RealizovaniNajmovi { get; set; } = [];
    }
}

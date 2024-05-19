namespace StanNaDan.Entiteti
{
    public class DodatnaOprema
    {
        virtual public required int IdOpreme { get; set; }
        virtual public required Nekretnina Nekretnina { get; set; }

        virtual public required string TipOpreme { get; set; }
        virtual public required bool BesplatnoKoriscenje { get; set; }
        virtual public double CenaKoriscenja { get; set; }
    }
}

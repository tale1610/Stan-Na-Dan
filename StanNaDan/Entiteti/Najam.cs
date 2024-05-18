namespace StanNaDan.Entiteti
{
    public class Najam
    {
        public required int IdNajma { get; set; }
        public required DateTime DatumPocetka { get; set; }
        public required DateTime DatumZavrsetka { get; set; }
        public required int BrojDana { get; set; }
        public required double CenaPoDanu { get; set; }
        public int Popust { get; set; }
        public double CenaSaPopustom { get; set; }
        public double ZaradaOdDodatnihUsluga { get; set; }
        public double UkupnaCena { get; set; }
        public double ProvizijaAgencije { get; set; }

        //veze:
        public required Nekretnina Nekretnina { get; set; }//trenutno smo odradili da i kad se iznajmi samo soba pamti se u najmu nekretnina iz koje je soba izdata,
                                                           //a upisuju se podaci i u tabelu izdata soba, tu ce opet proverimo logiku
        public required Zaposleni Agent { get; set; }
        public SpoljniSaradnik? SpoljniSaradnik { get; set; }
    }
}

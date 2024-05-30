namespace StanNaDan.Entiteti;

public class Najam
{
    virtual public int IdNajma { get; protected set; }
    virtual public required DateTime DatumPocetka { get; set; }
    virtual public required DateTime DatumZavrsetka { get; set; }
    virtual public required int BrojDana { get; set; }
    virtual public required double CenaPoDanu { get; set; }
    virtual public int? Popust { get; set; }
    virtual public double? CenaSaPopustom { get; set; }
    virtual public double ZaradaOdDodatnihUsluga { get; set; }
    virtual public double UkupnaCena { get; set; }
    virtual public double ProvizijaAgencije { get; set; }

    //veze:
    virtual public required Nekretnina Nekretnina { get; set; }
    virtual public required Agent Agent { get; set; }
    virtual public SpoljniSaradnik? SpoljniSaradnik { get; set; }
    virtual public IList<IznajmljenaSoba>? IznajmljivanjaSoba { get; set; } = [];
    virtual public IList<Soba>? Sobe { get; set; } = [];
        
}

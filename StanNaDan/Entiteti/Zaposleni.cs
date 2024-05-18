namespace StanNaDan.Entiteti
{
    //RAZMISLI DA L DA IZVUCES POSLOVNICU DA BUDE ZAJEDNICKI ATRIBUT ZA SVE I DA SE SAMO GLEDA ZA SEFOVE KAO ID POSLOVNICE SEFOVANJA A ZA AGENTE KAO ID POSLOVNICE
    public class Zaposleni
    {
        virtual public required string MBR { get; set; }
        virtual public required string  Ime { get; set; }
        virtual public required string Prezime { get; set; }
        virtual public required DateTime DatumZaposlenja { get; set; }

        //[DozvoljeniTipoviPosla(new string[] {"sef", "agent", "ostalo"}, ErrorMessage ="Tip posla moze biti samo 'agent', 'sef' ili 'ostalo'")]
        //public required string TipPosla { get; set; }        
    }

    //public class DozvoljeniTipoviPosla : ValidationAttribute
    //{
    //    private readonly string[] _dozvoljeniTipovi;

    //    public DozvoljeniTipoviPosla(string[] dozvoljeniTipovi)
    //    {
    //        _dozvoljeniTipovi = dozvoljeniTipovi;
    //    }

    //    public override bool IsValid(object value)
    //    {
    //        string valueAsString = value as string;
    //        if (valueAsString == null)
    //        {
    //            return true;
    //        }
    //        return _dozvoljeniTipovi.Contains(valueAsString.ToLower());
    //    }
    //}
}

public class Sef: Zaposleni
{
    virtual public required DateTime? DatumPostavljanja { get; set; }
    virtual public Poslovnica? PoslovnicaSefovanja { get; set; }
}

public class Agent: Zaposleni
{
    virtual public string? StrucnaSprema { get; set; }
    //veze
    virtual public IList<SpoljniSaradnik> AngazovaniSaradnici { get; set; } = [];
    virtual public Poslovnica? Poslovnica { get; set; }
    virtual public IList<Najam> RealizovaniNajmovi { get; set; } = [];
}

public class Radnik : Zaposleni
{
    virtual public Poslovnica? Poslovnica { get; set; }

}
namespace StanNaDan.Entiteti;

public class Soba
{
    virtual public required SobaId ID { get; set; }
    virtual public IList<Najam> Najmovi { get; set; } = [];
    virtual public IList<IznajmljenaSoba> IznajmljivanjaSobe { get; set; } = [];
    virtual public IList<ZajednickeProstorije> ZajednickeProstorije { get; set; } = [];
}

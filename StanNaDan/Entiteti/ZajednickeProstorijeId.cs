namespace StanNaDan.Entiteti;

public class ZajednickeProstorijeId
{
    virtual public required Soba Soba { get; set; }
    virtual public required string ZajednickaProstorija { get; set; }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(ZajednickeProstorijeId))
        {
            return false;
        }

        ZajednickeProstorijeId compare = (ZajednickeProstorijeId)obj;

        return Soba.ID == compare.Soba.ID && ZajednickaProstorija == compare.ZajednickaProstorija;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

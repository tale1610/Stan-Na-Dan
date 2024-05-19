namespace StanNaDan.Entiteti;

public class SobaId
{
    virtual public required int IdSobe { get; set; }
    virtual public required Nekretnina Nekretnina { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(SobaId))
        {
            return false;
        }

        SobaId compare = (SobaId)obj;

        return IdSobe == compare.IdSobe && Nekretnina?.IdNekretnine == compare.Nekretnina?.IdNekretnine;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
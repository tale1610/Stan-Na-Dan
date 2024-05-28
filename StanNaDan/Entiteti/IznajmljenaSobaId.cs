namespace StanNaDan.Entiteti;

public class IznajmljenaSobaId
{
    virtual public required SobaId Soba { get; set; } //ovaj se sadrzi od ova tri dole
    virtual public required Najam Najam { get; set; }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(IznajmljenaSobaId))
        {
            return false;
        }

        IznajmljenaSobaId compare = (IznajmljenaSobaId)obj;

        return Soba.Nekretnina == compare.Soba.Nekretnina && Soba.IdSobe == Soba.IdSobe && Najam?.IdNajma == compare.Najam?.IdNajma;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
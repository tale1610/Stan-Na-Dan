namespace StanNaDan.Entiteti;

public class IznajmljenaSobaId
{
    virtual public required Soba Soba { get; set; }
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

        return Soba.ID == compare.Soba.ID && Najam?.IdNajma == compare.Najam?.IdNajma;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
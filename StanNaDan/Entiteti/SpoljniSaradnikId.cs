namespace StanNaDan.Entiteti;

public class SpoljniSaradnikId
{
    virtual public required int IdSaradnika { get; set; }
    virtual public required Agent AgentAngazovanja { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj?.GetType() != typeof(SpoljniSaradnikId))
        {
            return false;
        }

        SpoljniSaradnikId compare = (SpoljniSaradnikId)obj;

        return IdSaradnika == compare.IdSaradnika && AgentAngazovanja?.MBR == compare.AgentAngazovanja?.MBR;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

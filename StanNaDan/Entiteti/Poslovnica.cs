namespace StanNaDan.Entiteti
{
    public class Poslovnica
    {
        public virtual int ID { get; protected set; }
        public virtual required string Adresa { get; set; }
        public virtual required string RadnoVreme { get; set; }
        public virtual Sef? Sef { get; set; }
        public virtual IList<Zaposleni>? Zaposleni { get; set; } = [];
        public virtual IList<Kvart>? Kvartovi { get; set; } = [];
    }
}

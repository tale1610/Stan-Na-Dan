namespace StanNaDan.Entiteti
{
    public class Vlasnik
    {
        public virtual required int IdVlasnika { get; set; }
        public virtual required string Banka { get; set; }
        public virtual required string BrojBankovnogRacuna { get; set; }
        public virtual IList<Nekretnina>? Nekretnine { get; set; } = [];
        public virtual FizickoLice? FizickoLice { get; set; }
        public virtual PravnoLice? PravnoLice { get; set; }


        //on moze da ima vise nekretnina posle odradi vezu kad napravis nekretnina klasu
    }
}

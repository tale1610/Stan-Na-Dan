namespace StanNaDan.Entiteti
{
    public class Vlasnik
    {
        public virtual required int IdVlasnika { get; set; }
        public virtual required string Banka { get; set; }
        public virtual required string BrojBankovnogRacuna { get; set; }

        //on moze da ima vise nekretnina posle odradi vezu kad napravis nekretnina klasu
    }
}

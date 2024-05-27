namespace StanNaDan.Mapiranja
{
    class KrevetMapiranja : ClassMap<Krevet>
    {
        public KrevetMapiranja() {
            Table("KREVET");

            CompositeId(p => p.ID)
            .KeyProperty(p => p.IdKreveta, "ID_KREVETA")
            .KeyReference(p => p.Nekretnina, "ID_NEKRETNINE");

            Map(p => p.Tip, "TIP");
            Map(p => p.Dimenzije, "DIMENZIJE");

            //References(p => p.Nekretnina).Column("ID_NEKRETNINE").LazyLoad();//ako se  buni mora i u entitet da se doda ovo

        }
    }
}

namespace StanNaDan.Mapiranja;

class SobaMapiranja : ClassMap<Soba>
{
    public SobaMapiranja() {
        Table("SOBA");

        CompositeId(p => p.ID)
            .KeyProperty(p => p.IdSobe, "ID_SOBE")// ako ne valja kompozitni kljuc mozda treba da se izbaci ova linija
            .KeyReference(p => p.Nekretnina, "ID_NEKRENTINE");

        //Id(p => p.ID, "ID").GeneratedBy.Assigned();

        //Map(p => p.IdSobe, "ID_SOBE_U_NEKRETNINI");

        //References(p => p.Nekretnina).Column("ID_NEKRENTINE").LazyLoad();

        HasManyToMany(p => p.Najmovi)
            .Table("IZNAJMLJENA_SOBA")
            .ParentKeyColumn("ID_SOBE")
            .ChildKeyColumn("ID_NAJMA"); 

        HasMany(p => p.ZajednickeProstorije).KeyColumn("ID_SOBE").Cascade.All().Inverse();
    }
}

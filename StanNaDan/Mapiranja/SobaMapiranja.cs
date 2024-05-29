namespace StanNaDan.Mapiranja;

class SobaMapiranja : ClassMap<Soba>
{
    public SobaMapiranja() 
    {
        Table("SOBA");

        CompositeId(p => p.ID)
            .KeyReference(p => p.Nekretnina, "ID_NEKRETNINE")
            .KeyProperty(p => p.IdSobe, "ID_SOBE");

        HasMany(x => x.ZajednickeProstorije)
                .KeyColumns.Add("ID_NEKRETNINE", "ID_SOBE")
                .Cascade.All()
                .Inverse();

        //HasManyToMany(p => p.Najmovi)
        //    .Table("IZNAJMLJENA_SOBA")
        //    .ParentKeyColumns.Add("ID_SOBE", "ID_NEKRETNINE")
        //    .ChildKeyColumn("ID_NAJMA");

        //HasMany(p => p.ZajednickeProstorije).KeyColumn("ID_SOBE").Cascade.All().Inverse();
    }
}

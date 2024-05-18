namespace StanNaDan.Entiteti
{
    public class ZajednickeProstorije
    {
        //slicna prica kao u iznajmljenu sobu, u bazi se soba odredjuje sa PK kombinaciju nekretnine i sobe, a ovde bi logicnije bilo da ima surogat kljuc neki za sobu pa
        //na osnovu toga da se povezuje samo sa njom
        public IList<string>? ZajednickeSobe { get; set; }//i ovo takodje, u bazi je to kao zaseban unos vec si imao ovu situaciju u nekoj klasi treba da se smisli
                                                          //da li da se ide ovako sa listom ili da svaki objekat predstavlja poseban red u bazi, cas mi jedno zvuci 
                                                          //smisleno a cas drugo
    }
}

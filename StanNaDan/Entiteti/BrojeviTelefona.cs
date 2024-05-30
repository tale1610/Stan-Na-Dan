namespace StanNaDan.Entiteti
{
    public class BrojeviTelefona
    {
        virtual public required string BrojTelefona { get; set; }
        //veza
        virtual public required FizickoLice FizickoLice { get; set; }
    }
}

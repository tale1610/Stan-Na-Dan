namespace StanNaDan;
//ovo kreiramo nasu fju za bolje citanje errora koji ce da nam se desavaju

public static class Extensions
{
    public static string FormatExceptionMessage(this Exception ex)
    {
        //parametar je objekat nad kojim se metoda zove!
        StringBuilder sb = new();
        //Koristimo stringBuilter zato sto je bolji za konkatenaciju stringova i zgodniji je

        int indent = 0; //KOLIKO CEMO DA UVUCEMO SVAKI SLEDECI INNER EXCEPTION
        Exception temp = ex;

        while (temp != null)
        {
            if (indent > 0)
            {
                sb.Append($"{new string('-', indent)}>");//ovo ce da ponovi crticu onoliko puta koliki je indent odnosno uvlacenje
            }
            sb.AppendLine(temp.Message);
            indent += 2;
            temp = temp.InnerException;//svaki put kad se jedna iteracija zavrsi smestamo u temp ovaj inner ex
        }
        return sb.ToString();
    }
}


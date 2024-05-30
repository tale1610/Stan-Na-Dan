namespace StanNaDan;

public static class Extensions
{
    public static string FormatExceptionMessage(this Exception ex)
    {
        StringBuilder sb = new();

        int indent = 0; 
        Exception temp = ex;

        while (temp != null)
        {
            if (indent > 0)
            {
                sb.Append($"{new string('-', indent)}>");
            }
            sb.AppendLine(temp.Message);
            indent += 2;
            temp = temp.InnerException;
        }
        return sb.ToString();
    }
}


using System.Text.Json;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries() //constructor
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    } 
}
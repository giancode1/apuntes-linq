using System.Text.Json;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries() //constructor
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesDel2000()
    {
        //*Extension Method
        //return librosCollection.Where(p => p.PublishedDate.Year>2000);

        //*Query expression
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosMasde250PagsTituloContieneinAction()
    {
        //*Extension Method
        return librosCollection.Where(p => p.PageCount>250 && p.Title.Contains("in Action"));

        //*Query expression
        //return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }
}
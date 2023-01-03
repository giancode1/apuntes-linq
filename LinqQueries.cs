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

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool HayAlgunLibroPublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosdePython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosJavaOrdenadosNombreAscendente()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosMasDe450PagsOrdenadosNumPagsDescendente()
    {
        return librosCollection.Where(p => p.PageCount>450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> Primeros3LibrosJavaPublicacionReciente()
    {
        return librosCollection
            .Where(p => p.Categories.Contains("Java"))
            .OrderByDescending(p => p.PublishedDate)
            .Take(3);
            //TakeLast toma los ultimos
            //TakeWhile, recibe una condición y toma los elementos q cumplan, da los elementos hasta encontrar uno q no cumple

            //otra forma:
            //.OrderBy(p => p.PublishedDate)
            //.TakeLat(3);
    }
    public IEnumerable<Book> TercerYCuartoLibroMas400Pags()
    {
        return librosCollection
            .Where(p => p.PageCount>400)
            .Take(4)
            .Skip(2);
            //SkipLast
            //SkipWhile
    }



}
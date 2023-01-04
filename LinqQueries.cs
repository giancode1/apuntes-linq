using System.Text.Json;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries() //constructor
    {
        try
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("No se ha encontrado el archivo: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al leer o procesar el archivo: " + ex.Message);
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
        return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

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
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
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
            .Where(p => p.PageCount > 400)
            .Take(4)
            .Skip(2);
        //SkipLast
        //SkipWhile
    }

    public IEnumerable<Item> TresPrimerosLibrosSelect()
    {
        return librosCollection.Take(3)
            .Select(p => new Item()
            {
                Title = p.Title,
                PageCount = p.PageCount
            });
    }

    public long CantidadLibrosEntre200a500Pags()
    {
        return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
        //return librosCollection.Where(p => p.PageCount >=200 && p.PageCount<=500).LongCount(); // sirve pero no es buena practica, ya que la condicion puede ir en el LongCount y asi ahorrar ese where
        // return librosCollection.Count(p => p.PageCount >=200 && p.PageCount<=500);  //cambia el int a long
    }

    public DateTime FechaPublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int MaxCantidadPagsEnColeccion()
    {
        return librosCollection.Max(p => p.PageCount);
    }
    public Book LibroConMenorPags() //devolvemos todo el objeto, el libro como tal
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book LibroMasReciente() //devolvemos todo el objeto, el libro como tal
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumaDeTodasLasPagsLibrosEntre0y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500)
        .Sum(p => p.PageCount);
    }

    public string TitulosLibrosDespues2015Concatenados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015)
        .Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;

            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulosLibros()
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public double PromedioNumeroPagsLibros()
    {
        return librosCollection.Where(p => p.PageCount > 0).Average(p => p.PageCount);
        // hay libros cuyo PageCount = 0, no significa que sean 0 sino que no se sabe cuantas paginas tiene
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAnio()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 200).GroupBy(p => p.PublishedDate.Year);
        // agrupa por anio
    }

    public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
    { // Diccionario tipo ILookup, devuelve char, Book
        return librosCollection.ToLookup(p => p.Title[0], p => p); // (obtenga la primera letra , agrupa libro como tal sin filtro)
    }
    public IEnumerable<Book> LibrosDespuesdel2005conmasde500Pags()
    {
        var LibrosDespuesdel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);
        
        var LibrosConMasde500Pags = librosCollection.Where(p => p.PageCount > 500);

        // estamos comparando por titulos
        // e1: elementos de coleccion1 = LibrosDespuesdel2005
        // e2: elementos de coleccion2 = LibrosConMasde500Pags
        // retorna e1, es indiferente aca puede ser e1 o e2 porq son los q coindicen y son exactamente iguales
        return LibrosDespuesdel2005.Join(LibrosConMasde500Pags, e1 => e1.Title, e2=> e2.Title, (e1, e2) => e1); 

    }

}
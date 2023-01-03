LinqQueries queries = new LinqQueries();

// ImprimirValores(queries.TodaLaColeccion());

// Libros después del 2000
// ImprimirValores(queries.LibrosDespuesDel2000());

// libros que tengan mas de 250 pags, y titulo contenga "in Action"
ImprimirValores(queries.LibrosMasde250PagsTituloContieneinAction());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }   
}

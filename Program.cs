LinqQueries queries = new LinqQueries();
ImprimirValores(queries.TodaLaColeccion());


void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }   
}

LinqQueries queries = new LinqQueries();

// ImprimirValores(queries.TodaLaColeccion());

//*Libros después del 2000
// ImprimirValores(queries.LibrosDespuesDel2000());

//*libros que tengan mas de 250 pags, y titulo contenga "in Action"
//ImprimirValores(queries.LibrosMasde250PagsTituloContieneinAction());

//*Usando el operador All, verifica que todos los elementos de la coleccion
//*tengan un valor en el campo Status
//Console.WriteLine(queries.TodosLosLibrosTienenStatus()); // True, todos los libros tienen status

//*Usando el operador Any verifica si alguno de los libros fue publicado en 2005
//Console.WriteLine(queries.HayAlgunLibroPublicado2005()); // True

//*Libros con categoria Python
// ImprimirValores(queries.LibrosdePython());

//*Libros de Java ordenados por nombre ascendente
ImprimirValores(queries.LibrosJavaOrdenadosNombreAscendente());

//*Libros con mas de 450 pags, ordenados por numero de pag descendente
ImprimirValores(queries.LibrosMasDe450PagsOrdenadosNumPagsDescendente());


void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }   
}

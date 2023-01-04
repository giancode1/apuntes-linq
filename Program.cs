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
//ImprimirValores(queries.LibrosJavaOrdenadosNombreAscendente());

//*Libros con mas de 450 pags, ordenados por numero de pag descendente
//ImprimirValores(queries.LibrosMasDe450PagsOrdenadosNumPagsDescendente());

//*Con Take selecciona los primeros 3 libros con fecha de publicación mas reciente
//*que esten categorizados en Java
//ImprimirValores(queries.Primeros3LibrosJavaPublicacionReciente());

//*Con Skip selecciona el 3er y 4to libro con mas de 400 pags
//ImprimirValores(queries.TercerYCuartoLibroMas400Pags());

//*Retornar cietos datos en especifico
//*Con Select, selecciona el titulo y el Num de pags de los 3 primeros libros de la coleccion
//ImprimirValoresItem(queries.TresPrimerosLibrosSelect());

//*Usando Count, retornar #libros que tengan entre 200-500 pags
//Console.WriteLine("Cantidad de libros que tienen entre 200 y 500 pags: " + queries.CantidadLibrosEntre200a500Pags());

//*Con Min, retorna la menor fecha de publicación de la lista de libros
//Console.WriteLine("Menor fecha de publicación: " + queries.FechaPublicacionMenor());

//*Con Max, retorna la cantidad de pags de libro con mayor num de pags en la coleccion
//Console.WriteLine("Max cantidad de páginas: " + queries.MaxCantidadPagsEnColeccion());

//*Retornar el libro que tenga la menor cantidad de pags diferente de 0
// var libroMenorPags = queries.LibroConMenorPags();
// Console.WriteLine($"{libroMenorPags.Title} - {libroMenorPags.PageCount}");

//*Retornar libro con fecha de publicacion mas reciente
// var libroMasReciente = queries.LibroMasReciente();
// Console.WriteLine($"{libroMasReciente.Title} - {libroMasReciente.PublishedDate.ToShortDateString()}");

//*Retorna la suma de la cantidad de pags, de todos los libros que
//*tengan entre 0 a 500
Console.WriteLine("Suma total de pags: "+queries.SumaDeTodasLasPagsLibrosEntre0y500());

//*Con Aggregate, retorna el titulo de los libros que tienen
//*fecha de publicacion posterior a 2015
Console.WriteLine(queries.TitulosLibrosDespues2015Concatenados());



void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }   
}

void ImprimirValoresItem(IEnumerable<Item> listaLibros)
{
    Console.WriteLine("{0, -60} {1, 15}\n", "Titulo", "N. Páginas");
    foreach(var item in listaLibros)
    {
        Console.WriteLine("{0, -60} {1, 15}", item.Title, item.PageCount);
    }   
}

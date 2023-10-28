
using (var contextdb = new Context())
{
    foreach (var item in contextdb.evaluaciones)
    {
        Console.WriteLine($"Datos: Id: {item.id}, Nombre: {item.nombre}, Porcentaje: {item.porcentaje}, Fecha: {item.fecha}, Lugar: {item.lugar}");

    }
}
bool agregarMasRegistros = true; while (agregarMasRegistros)
{
    Console.WriteLine("Ingrese los datos del estudiante:");

    Console.Write("Nombre: ");
    string nombre = Console.ReadLine();

    Console.Write("Porcentaje: ");
    double porcentaje = Convert.ToSingle(Console.ReadLine());

    Console.Write("Fecha: ");
    string fecha = Console.ReadLine();

    Console.Write("Lugar: ");
    string lugar = Console.ReadLine();

    using (var contextdb = new Context())
    {
        contextdb.Database.EnsureCreated();

        var nuevoEvaluaciones = new evaluaciones()
        {
            nombre = nombre,
            porcentaje = porcentaje,
            fecha = fecha,
            lugar = lugar
        };

        contextdb.Add(nuevoEvaluaciones);
        contextdb.SaveChanges();
    }

    Console.WriteLine("¿Desea agregar más registros? (Sí/No)");
    string respuesta = Console.ReadLine();
    agregarMasRegistros = respuesta.StartsWith("S", StringComparison.OrdinalIgnoreCase);
}
bool modificarNombre = true;

while (modificarNombre)
{
    Console.WriteLine("¿Desea modificar alguno de la tabla Evaluaciones (Sí/No)");
    string respuestaModificarNombre = Console.ReadLine();

    if (respuestaModificarNombre.StartsWith("S", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Ingrese el nombre de la persona que desea modificar:");
        string nombreModificar = Console.ReadLine();

        using (var contextdb = new Context())
        {
            var evaluacionExistente = contextdb.evaluaciones.FirstOrDefault(e => e.nombre == nombreModificar);

            if (evaluacionExistente != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre:");
                string nuevoNombre = Console.ReadLine();

                evaluacionExistente.nombre = nuevoNombre;
                contextdb.SaveChanges();
                Console.WriteLine("Nombre modificado con éxito.");
            }
            else
            {
                Console.WriteLine("La persona no se encontró en la base de datos.");
            }
        }
    }
    else
    {
        modificarNombre = false;
    }
}
using (var contextdb = new Context())
{
    foreach (var evaluaciones in contextdb.evaluaciones)
    {
        Console.WriteLine($"evaluaciones Id: {evaluaciones.id}, Nombre: {evaluaciones.nombre}, Porcentaje: {evaluaciones.porcentaje}, Fecha: {evaluaciones.fecha}, Lugar: {evaluaciones.lugar}");
    }
}
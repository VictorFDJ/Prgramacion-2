using System;
using System.Collections.Generic;


namespace Tarea1 { 
public class MiebroDeLaComunidad
{
    static int contador = 0;
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public int Edad { get; set; }

    public MiebroDeLaComunidad(string nombre, string apellido, string email, string telefono, int edad)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
        Edad = edad;
        contador++;
    }
}
public class Program
{
    static List<MiebroDeLaComunidad> comunidad = new List<MiebroDeLaComunidad>();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine(@"
1- Agregar miembro
2- Ver miembros
3- Actualizar miembro
4- Eliminar miembro
5- Salir
");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarMiembro();
                    break;
                case "2":
                    VerMiembros();
                    break;
                case "3":
                    ActualizarMiembro();
                    break;
                case "4":
                    EliminarMiembro();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static void AgregarMiembro()
    {
        Console.Write("Tipo de miembro (Empleado, Estudiante, ExAlumno, Docente, Administrativo, Administrador, Maestro): ");
        string tipo = Console.ReadLine();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine());

        if (tipo.Equals("Empleado", StringComparison.OrdinalIgnoreCase) ||
            tipo.Equals("Docente", StringComparison.OrdinalIgnoreCase) ||
            tipo.Equals("Administrativo", StringComparison.OrdinalIgnoreCase) ||
            tipo.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ||
            tipo.Equals("Maestro", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Salario: ");
            decimal salario = decimal.Parse(Console.ReadLine());

            switch (tipo.ToLower())
            {
                case "empleado":
                    comunidad.Add(new Empleado(nombre, apellido, email, telefono, edad, salario));
                    break;
                case "docente":
                    comunidad.Add(new Docente(nombre, apellido, email, telefono, edad, salario));
                    break;
                case "administrativo":
                    comunidad.Add(new Administrativo(nombre, apellido, email, telefono, edad, salario));
                    break;
                case "administrador":
                    comunidad.Add(new Administrador(nombre, apellido, email, telefono, edad, salario));
                    break;
                case "maestro":
                    comunidad.Add(new Maestro(nombre, apellido, email, telefono, edad, salario));
                    break;
            }
        }
        else if (tipo.Equals("Estudiante", StringComparison.OrdinalIgnoreCase))
        {
            comunidad.Add(new Estudiante(nombre, apellido, email, telefono, edad));
        }
        else if (tipo.Equals("ExAlumno", StringComparison.OrdinalIgnoreCase))
        {
            comunidad.Add(new ExAlumno(nombre, apellido, email, telefono, edad));
        }
        else
        {
            Console.WriteLine("Tipo de miembro no válido.");
        }
    }

    static void VerMiembros()
    {
        if (comunidad.Count == 0)
        {
            Console.WriteLine("No hay miembros registrados.");
            return;
        }

        foreach (var miembro in comunidad)
        {
            Console.WriteLine($"Nombre: {miembro.Nombre}, Apellido: {miembro.Apellido}, Email: {miembro.Email}, Teléfono: {miembro.Telefono}, Edad: {miembro.Edad}");
        }
    }

    static void ActualizarMiembro()
    {
        Console.Write("Email del miembro a actualizar: ");
        string email = Console.ReadLine();
        var miembro = comunidad.Find(m => m.Email == email);

        if (miembro == null)
        {
            Console.WriteLine("Miembro no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre (deja en blanco para no cambiar): ");
        string nuevoNombre = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoNombre)) miembro.Nombre = nuevoNombre;

        Console.Write("Nuevo apellido (deja en blanco para no cambiar): ");
        string nuevoApellido = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoApellido)) miembro.Apellido = nuevoApellido;

        Console.Write("Nuevo teléfono (deja en blanco para no cambiar): ");
        string nuevoTelefono = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoTelefono)) miembro.Telefono = nuevoTelefono;

        Console.Write("Nueva edad (deja en blanco para no cambiar): ");
        string nuevaEdad = Console.ReadLine();
        if (int.TryParse(nuevaEdad, out int edad)) miembro.Edad = edad;
    }

    static void EliminarMiembro()
    {
        Console.Write("Email del miembro a eliminar: ");
        string email = Console.ReadLine();
        var miembro = comunidad.Find(m => m.Email == email);

        if (miembro == null)
        {
            Console.WriteLine("Miembro no encontrado.");
            return;
        }

        comunidad.Remove(miembro);
        Console.WriteLine("Miembro eliminado correctamente.");
    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    public class Maestro : Docente
    {
        public Maestro(string nombre, string apellido, string email, string telefono, int edad, decimal salario)
            : base(nombre, apellido, email, telefono, edad, salario) { }
    }

}

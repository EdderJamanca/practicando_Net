using SuperHeroe.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroe.Models
{
    internal class ImprimirInfo
    {
        public void ImprimirSuperHeroe(ISuperPoder superHeroe)
        {
            Console.WriteLine($"Id; {superHeroe.Id}");
            Console.WriteLine($"Nombre: {superHeroe.Nambre}");
            Console.WriteLine($"Identidad secreta:{superHeroe.IdentidadSecreta}");
        }
    }
}

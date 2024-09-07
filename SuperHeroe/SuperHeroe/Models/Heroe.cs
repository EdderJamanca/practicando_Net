using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroe.Models
{
    internal abstract class Heroe
    {
        public abstract string Nombre { get; set; }
        public abstract string SalvarElMundo();

        //el virtual se usa para utilizar polimorfismo.
        public virtual string SalvarTierra()
        { return $"{Nombre} ha salvado"; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroe.Models
{
    internal class AntiHeroe : SuperHeroes
    {
        public string RealizarAccionDeAntiheroe(string accion)
        {
            return $"El Antiheroe {NombreEIdentidadSecreta} ha realizado: {accion}";
        }
    }
}

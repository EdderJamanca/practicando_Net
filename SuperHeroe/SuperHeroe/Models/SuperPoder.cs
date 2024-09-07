using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroe.Models
{
    class SuperPoder
    {
        public string Nombre;
        public string Description;
        public NivelPoder Nivel;

        public SuperPoder()
        {
            Nivel = NivelPoder.NivelUno;
        }
    }

    enum NivelPoder
    {
        NivelUno,
        NivelDos,
        NivelTrees,
        NivelCuatro
    }

}

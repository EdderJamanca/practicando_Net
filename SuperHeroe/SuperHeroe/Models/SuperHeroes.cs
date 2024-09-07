using SuperHeroe.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroe.Models
{
    class SuperHeroes: Heroe, ISuperPoder
    {
        private string _nombre;
        public int Id {  get; set; }
        public override string Nombre {
            get { return _nombre; }
            set { _nombre = value.Trim(); }
        }

        public string NombreEIdentidadSecreta
        {
            get
            {
                return $"{Nombre} ({IdentidadSecreta})";
            }
        }
        public string IdentidadSecreta { get; set; }
        public string Nambre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Ciudad;

        public List<SuperPoder> SuperPoderes;

        public bool PuedeVolar;

        public SuperHeroes()
        {
            Id = 1;
            SuperPoderes = new List<SuperPoder>();
            PuedeVolar = true;

        }

        public string UsarSuperPoderes()
        {
            //StringBuilder permite concatenar string
            StringBuilder sb = new StringBuilder();

            foreach (var item in SuperPoderes)
            {
                //Console.WriteLine($"{Nombre} esta usando el super poder {item.Nombre}!!");
                sb.AppendLine($"{NombreEIdentidadSecreta} esta usando el super poder {item.Nombre}!!");
            }

            return sb.ToString();
        }

        public override string SalvarElMundo()
        {
            return $"{NombreEIdentidadSecreta} ha salvado el mundo.";
        }

        public override string SalvarTierra()
        {
            //return base.SalvarTierra();
            return $"{NombreEIdentidadSecreta} has salvado la tierra";
        }
    }

}

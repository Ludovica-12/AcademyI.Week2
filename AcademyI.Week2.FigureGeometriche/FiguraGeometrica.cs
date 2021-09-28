using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.FigureGeometriche
{
    public abstract class FiguraGeometrica
    {
        public string Nome { get; set; }
        public double Area { get; set; }

        public string PrintNome()
        {
            return $"{Nome}";
        }
        public abstract string PrintPerimetro();
        public abstract void CalcolaArea();
        public string PrintArea()
        {
            return $"{Area}";
        }
    }
}

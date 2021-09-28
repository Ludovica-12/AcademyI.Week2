using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.FigureGeometriche
{
    public abstract class Poligono : FiguraGeometrica
    {
        public double Base { get; set; }
        public double Altezza { get; set; }
    }
}

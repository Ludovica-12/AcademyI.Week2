using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.FigureGeometriche
{
    public class Cerchio : FiguraGeometrica
    {
        public double Raggio { get; set; }
        public Centro Coordinate { get; set; }


        public override void CalcolaArea()
        {
            var area = Raggio * Raggio * Math.PI;
            Area = area;
        }

        public override string PrintPerimetro()
        {
            var perimetro = Raggio * 2 + Math.PI;

            return $"La ciroferenza è {perimetro}";
        }
    }
    public struct Centro
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
}

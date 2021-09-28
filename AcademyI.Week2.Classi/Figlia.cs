using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.Classi
{
    public class Figlia : Padre
    {
        public string Cognome { get; set; }

        public override void CalcolaEta()
        {
            throw new NotImplementedException();
        }

        public string Stampa()
        {
            return $"{base.Stampa()} - {Cognome}";
        }

        public override string Saluta()
        {
            return "Buonasera a tutti";
        }
    }
}

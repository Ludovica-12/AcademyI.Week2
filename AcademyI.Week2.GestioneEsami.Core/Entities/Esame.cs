using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestioneEsami.Core.Entities
{
    public class Esame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Passato { get; set; }
        public int IdStudente { get; set; }
}
}

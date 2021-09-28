using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestioneEsami.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestionEsami.Mock
{
    public class RepositoryCorsi : IRepositoryCorsi
    {
        public static List<Corso> corso = new List<Corso>()
        {
            new Corso {Id = 1, Nome = "Analisi Matematica", CreditiFormativi = 30, IdCorsoLaurea= 1},
            new Corso {Id = 2, Nome = "Geometria", CreditiFormativi = 40, IdCorsoLaurea= 1},
            new Corso {Id = 3, Nome = "Logica", CreditiFormativi = 25, IdCorsoLaurea= 1},

            new Corso {Id = 4, Nome = "Fisica Teorica", CreditiFormativi = 45, IdCorsoLaurea= 2},
            new Corso {Id = 5, Nome = "Logica dei vettori", CreditiFormativi = 20, IdCorsoLaurea= 2},
            new Corso {Id = 6, Nome = "Meccanica", CreditiFormativi = 40, IdCorsoLaurea= 2},

            new Corso {Id = 7, Nome = "Database", CreditiFormativi = 20, IdCorsoLaurea= 3},
            new Corso {Id = 8, Nome = "Programmazione Proceduarale", CreditiFormativi = 35, IdCorsoLaurea= 3},
            new Corso {Id = 9, Nome = "Sistemi", CreditiFormativi = 25, IdCorsoLaurea= 3},

            new Corso {Id = 10, Nome = "Automatica", CreditiFormativi = 25, IdCorsoLaurea= 4},
            new Corso {Id = 11, Nome = "Geometria Piana", CreditiFormativi = 30, IdCorsoLaurea= 4},
            new Corso {Id = 12, Nome = "Analisi del Software", CreditiFormativi = 40, IdCorsoLaurea= 4},

            new Corso {Id = 13, Nome = "Letteratura Greca", CreditiFormativi = 45, IdCorsoLaurea= 5},
            new Corso {Id = 14, Nome = "Letteratura Latina", CreditiFormativi = 35, IdCorsoLaurea= 5},
            new Corso {Id = 15, Nome = "Grammatica", CreditiFormativi = 30, IdCorsoLaurea= 5 },
        };

        public List<Corso> Fetch()
        {
            return corso;
        }

        public List<Corso> GetCorsiByCorsoDiLaurea(CorsoDiLaurea cdl)
        {
            return corso.Where(c => c.IdCorsoLaurea == cdl.Id).ToList();
        }

        public void Insert(Corso item)
        {
            throw new NotImplementedException();
        }
    }
}

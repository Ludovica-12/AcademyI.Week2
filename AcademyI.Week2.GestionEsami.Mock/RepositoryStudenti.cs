using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestioneEsami.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestionEsami.Mock
{
    public class RepositoryStudenti : IRepositoryStudenti
    {
        public static List<Studente> studenti = new List<Studente>();
        public List<Studente> Fetch()
        {
            throw new NotImplementedException();
        }

        public int Insert(Studente item)
        {
            if (studenti.Count() == 0)
                item.Id = 1;
            else
                item.Id = studenti.Max(s => s.Id) + 1;

            studenti.Add(item);

            return item.Id;
        }

        void IRepository<Studente>.Insert(Studente item)
        {
            throw new NotImplementedException();
        }
    }
}

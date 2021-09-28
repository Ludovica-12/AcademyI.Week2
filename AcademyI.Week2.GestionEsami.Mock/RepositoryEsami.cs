using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestioneEsami.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestionEsami.Mock
{
    public class RepositoryEsami : IRepositoryEsami
    {
        public static List<Esame> esami = new List<Esame>();

        public void AddEsami(Esame esameDaSostenere)
        {
            esami.Add(esameDaSostenere);
        }

        public List<Esame> Fetch()
        {
            throw new NotImplementedException();
        }

        public void Insert(Esame item)
        {
            throw new NotImplementedException();
        }
    }
}

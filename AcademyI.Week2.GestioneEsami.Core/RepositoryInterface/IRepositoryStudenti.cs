using AcademyI.Week2.GestioneEsami.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestioneEsami.Core.RepositoryInterface
{
    public interface IRepositoryStudenti : IRepository<Studente>
    {
        public new int Insert(Studente item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestioneEsami.Core.RepositoryInterface
{
    public interface IRepository<T>
    {
        public List<T> Fetch();

        public void Insert(T item);
    }
}

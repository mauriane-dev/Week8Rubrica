using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Rubrica.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        public List<T> GetAll(); 
        public T Add(T item); //serve sia a Contatti che a Indirizzi quindi può rimanere qui!

        //public bool Delete(T item); //serve solo a Contatti
        //public T GetByID(int id); //serve solo a Contatti
    }
}

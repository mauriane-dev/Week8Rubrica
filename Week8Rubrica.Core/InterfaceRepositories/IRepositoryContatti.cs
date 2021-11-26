using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Rubrica.Core.Entities;

namespace Week8Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryContatti: IRepository<Contatto>
    {
        public bool Delete(Contatto item);
        public Contatto GetById(int id);
    }
}

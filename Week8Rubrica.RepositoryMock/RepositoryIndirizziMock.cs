using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.InterfaceRepositories;

namespace Week8Rubrica.RepositoryMock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>();

        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var i in Indirizzi)
                {
                    if (i.ID > maxId)
                    {
                        maxId = i.ID;
                    }
                }
                item.ID = maxId + 1;
            }

            Indirizzi.Add(item);
            return item;
        }

        public List<Indirizzo> GetAll()
        {
           return Indirizzi;
        }
    }
}

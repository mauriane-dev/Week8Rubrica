using System;
using System.Collections.Generic;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.InterfaceRepositories;

namespace Week8Rubrica.RepositoryMock
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
             new Contatto {ID=1, Nome = "Renata", Cognome = "Carriero"},
             new Contatto {ID=2, Nome = "Alessandra", Cognome = "Degan Di Dieco"},
             new Contatto {ID=3, Nome = "Tizio", Cognome = "Tizi"},
        };

        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var c in Contatti)
                {
                    if (c.ID > maxId)
                    {
                        maxId = c.ID;
                    }
                }
                item.ID = maxId + 1;
            }
            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            Contatti.Remove(item);
            return true;
        }

        public List<Contatto> GetAll()
        {
            return Contatti;
        }

        public Contatto GetById(int id)
        {
            foreach (var item in Contatti)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

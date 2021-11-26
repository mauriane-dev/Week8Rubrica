using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.Core.InterfaceRepositories;

namespace Week8Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer: IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzi indirizziRepo;


        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public Esito EliminaContatto(int idContattoDaEliminare)
        {
            //controllo su input
            var contattoEsistente = contattiRepo.GetById(idContattoDaEliminare);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "Id non valido. Impossibile eliminare.", isOK = false };
            }
            var indirizzoAssociato = indirizziRepo.GetAll().FirstOrDefault(i => i.ContattoID == idContattoDaEliminare);
            if (indirizzoAssociato != null)
            {
                return new Esito { Messaggio = "Impossibile cancellare il contatto perchè risulta associato ad almeno un indirizzo", isOK = false };
            }
            contattiRepo.Delete(contattoEsistente);
            return new Esito { Messaggio = "Contatto eliminato con successo", isOK = true };
        }

        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll();
        }

        public Esito InserisciNuovoContatto(Contatto nuovoContatto)
        {
            contattiRepo.Add(nuovoContatto);
            return new Esito { Messaggio = "Contatto Aggiunto con successo", isOK = true };
        }

        public Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo)
        {
            //controllo input
            //controllo se esiste quel contatto id
            var contattoEsistente = contattiRepo.GetById(nuovoIndirizzo.ContattoID);
            if (contattoEsistente == null)
            {
                return new Esito { Messaggio = "Contatto id errato", isOK = false };
            }
            indirizziRepo.Add(nuovoIndirizzo);
            return new Esito { Messaggio = "Indirizzo inserito correttamente", isOK = true };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Rubrica.Core.Entities;

namespace Week8Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Contatto> GetAllContatti();
        Esito InserisciNuovoContatto(Contatto nuovoContatto);
        Esito InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo);
        Esito EliminaContatto(int idContattoDaEliminare);
    }
}

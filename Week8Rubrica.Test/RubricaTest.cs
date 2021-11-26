using System;
using Week8Rubrica.Core.BusinessLayer;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.RepositoryMock;
using Xunit;

namespace Week8Rubrica.Test
{
    public class RubricaTest
    {
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());

        [Fact]
        public void DovrebbeAggiungereUnContatto()
        {
            //ARRANGE: predisposizione del test

            Contatto newContatto = new Contatto()
            {
                Nome = "NomeProva",
                Cognome = "NomeProva"
            };
            int numeroContattiPresenti = bl.GetAllContatti().Count;

            //ACT: chiamata alla funzionalita da testare
            bl.InserisciNuovoContatto(newContatto);

            //ASSERT: valutazione del risultato atteso vs restituito
            Assert.Equal(bl.GetAllContatti().Count, numeroContattiPresenti + 1);
        }
    }
}

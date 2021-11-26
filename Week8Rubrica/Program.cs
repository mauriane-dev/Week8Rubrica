using System;
using Week8Rubrica.Core.BusinessLayer;
using Week8Rubrica.Core.Entities;
using Week8Rubrica.RepositoryADO;
using Week8Rubrica.RepositoryMock;

namespace Week8Rubrica
{
    class Program
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        private static readonly IBusinessLayer bl= new MainBusinessLayer(new RepositoryContattiADO(), new RepositoryIndirizziADO());
        static void Main(string[] args)
        {

            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("*******************MENU*********************");
            Console.WriteLine("1. Visualizza Contatti");
            Console.WriteLine("2. Inserisci nuovo contatto");
            Console.WriteLine("3. Inserisci nuovo Indirizzo");
            Console.WriteLine("4. Elimina Contatto");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");
            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 4)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;
        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciNuovoContatto();
                    break;
                case 3:
                    InserisciNuovoIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void EliminaContatto()
        {
            Console.WriteLine("Ecco l'elenco dei contatti:\n");
            VisualizzaContatti();
            Console.WriteLine("Quale Contatto vuoi eliminare? Inserisci l'id");
            int idContattoDaEliminare;
            while (!int.TryParse(Console.ReadLine(), out idContattoDaEliminare))
            {
                Console.WriteLine("Inserisci un id numerico");
            }
            Esito esito = bl.EliminaContatto(idContattoDaEliminare);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoIndirizzo()
        {
            //chiedo all'utente i dati per "creare" il nuovo indirizzo;
            Console.Write("Ecco i Contatti disponibili:\n");
            VisualizzaContatti();
            Console.Write("\nInserisci l'id del contatto a cui vuoi associare il nuovo indirizzo: ");
            //int idContatto = int.Parse(Console.ReadLine());
            int idContatto;
            while (!int.TryParse(Console.ReadLine(), out idContatto))
            {
                Console.WriteLine("Inserisci un numero");
            }
            Console.WriteLine("Inserisci la tipologia");
            string tipologia = Console.ReadLine();
            Console.WriteLine("Inserisci la via");
            string via = Console.ReadLine();
            Console.WriteLine("Inserisci la città");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci il CAP");
            string cap = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione");
            string nazione = Console.ReadLine();

            //lo creo
            Indirizzo nuovoIndirizzo = new Indirizzo();
            nuovoIndirizzo.Tipologia = tipologia;
            nuovoIndirizzo.Provincia = provincia;
            nuovoIndirizzo.Nazione = nazione;
            nuovoIndirizzo.Citta = citta;
            nuovoIndirizzo.Via = via;
            nuovoIndirizzo.CAP = cap;
            nuovoIndirizzo.ContattoID = idContatto;

            //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB".
            Esito esito = bl.InserisciNuovoIndirizzo(nuovoIndirizzo);
            //Stampo il "risultato/messaggio"
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoContatto()
        {
            //chiedo all'utente i dati per "creare" il nuovo Contatto;            
            Console.WriteLine("Inserisci il nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome");
            string cognome = Console.ReadLine();


            //lo creo
            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;


            //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB".
            Esito esito = bl.InserisciNuovoContatto(nuovoContatto);
            //Stampo il "risultato/messaggio"
            Console.WriteLine(esito);
        }

        private static void VisualizzaContatti()
        {
            var contatti = bl.GetAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessuno Studente presente");
            }
            else
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

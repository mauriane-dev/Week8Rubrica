using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Rubrica.Core.Entities
{
    public class Contatto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Indirizzo> Indirizzi { get; set; } = new List<Indirizzo>();


        public override string ToString()
        {
            return $"{ID} - {Nome} {Cognome}"; 
        }
    }
}

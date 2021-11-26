using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8Rubrica.Core.Entities
{
    public class Esito
    {
        public string Messaggio { get; set; }
        public bool isOK { get; set; }

        public override string ToString()
        {
            return $"{Messaggio}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOFacture
    {        
        public int Identifiant { get; set; }
        public TOClient toClient { get; set; }
        public string Nom { get; set; }
        public Nullable<decimal> Montant { get; set; }
    }
}

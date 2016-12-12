using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOClient
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DateInscription { get; set; }
        //public Nullable<int> TypeInscription { get; set; }
        public TOTypeSouscription toTypeSouscription { get; set; }
    }
}

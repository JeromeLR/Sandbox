using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOArticle
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public Nullable<int> Prix { get; set; }
        public Nullable<int> Stock { get; set; }
        public TOCategorie toCategorie { get; set; }
        public string affichageNomPrix { get; set; }
    }
}

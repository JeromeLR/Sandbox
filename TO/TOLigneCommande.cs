using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO
{
    public class TOLigneCommande
    {
        public int Identifiant { get; set; }
        public TOArticle toArticle { get; set; }
        public Nullable<decimal> Prix { get; set; }
        
        public Nullable<int> Quantite { get; set; }
        public Nullable<int> IdFacture { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Models
{

    public class LigneCommandesClient
    {
        public TOClient Client { get; set; }
        public IEnumerable<TOLigneCommande> ListCommande { get; set; }
        public int IdFacture { get; set; }
    }
    
}

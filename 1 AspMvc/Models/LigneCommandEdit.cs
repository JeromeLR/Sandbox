using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Models
{

    public class LigneCommandEdit
    {
        public TOLigneCommande lc { get; set; }

        public List<TOArticle> listArticle { get; set; }
        
        public int idFacture { get; set; }

        public int idClient { get; set; }

    }
    
}

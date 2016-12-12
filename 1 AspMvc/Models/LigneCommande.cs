using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Models
{

    public class LigneCommande
    {
        public int Identifiant { get; set; }
        public int IdClient { get; set; }
        public int IdArticle { get; set; }
        public decimal Prix { get; set; }
        public int Quantite { get; set; }
    }
}

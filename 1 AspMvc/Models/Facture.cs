using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Models
{

    public class Facture
    {
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public int IdClient { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Models
{

    public class FactureEdit
    {
        public TOFacture f { get; set; }
        public List<TOClient> listClient { get; set; }
        
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;
using BS;

namespace ntier
{
    class Program
    {
        

        static void Main(string[] args)
        {
            
            var bs = BusinessService.Instance;

            var c1 = bs.Client.GetClientById(2);

            var c2 = bs.Client.GetClientByNom("Bar");

            Console.WriteLine("client Id 2 : {0}",c1.Nom);
            Console.WriteLine("Id client nom 'bar' : {0}",c2.Identifiant);


            var liste = bs.Client.GetAllClients();
            
            foreach(var c in liste)
            {
                Console.WriteLine("{0} : {1} {2} {3} {4}", c.Identifiant, c.Prenom, c.Nom, c.Age,c.DateInscription);
            }


            Console.ReadLine();
        }
    }
}

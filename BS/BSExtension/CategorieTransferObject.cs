using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class CatergorieTransferObject
    {
        /// <summary>
        /// Transforme un Article en ToArticle
        /// </summary>
        /// <param name="typeProjet"></param>
        /// <returns></returns>
        public static TOCategorie ToTransferObject(this Categorie categ)
        {
            if (categ == null)
            {
                return null;
            }

            TOCategorie toCategorie = new TOCategorie
            {
                Identifiant = categ.Id,
                Nom=categ.Nom
            };
            return toCategorie;
        }

        public static List<TOCategorie> ToTransferObject(this List<Categorie> listCategorie)
        {
            //List<TOClient> toClient = new List<TOClient>();
            //foreach (var client in listClient)
            //{
            //    listClient.Add(client.ToTransferObject());
            //};

            //return toClient;

            return listCategorie.Select(c => c.ToTransferObject()).ToList();
        }
    }
}

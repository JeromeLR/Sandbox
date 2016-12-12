using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class TOTypeSouscriptionT
    {
        /// <summary>
        /// Transforme un Article en ToArticle
        /// </summary>
        /// <param name="typeProjet"></param>
        /// <returns></returns>
        public static TOTypeSouscription ToTransferObject(this TypeSouscription type)
        {
            if (type == null)
            {
                return null;
            }

            TOTypeSouscription toTypeSouscription = new TOTypeSouscription
            {
                Identifiant = type.Id,
                Nom = type.Nom,
                Promo = (int)type.Promo           
            };
            return toTypeSouscription;
        }

        public static List<TOTypeSouscription> ToTransferObject(this List<TypeSouscription> lt)
        {
            //List<TOClient> toClient = new List<TOClient>();
            //foreach (var client in listClient)
            //{
            //    listClient.Add(client.ToTransferObject());
            //};

            //return toClient;

            return lt.Select(c => c.ToTransferObject()).ToList();
        }
    }
}

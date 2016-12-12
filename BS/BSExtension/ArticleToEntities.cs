﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BS.BSExtension
{
    public static class ArticleToEntities
    {
        /// <summary>
        /// Transforme le TO en Entity
        /// </summary>
        /// <param name="listeToCommande">Tranfert Object</param>
        /// <returns>The Entity</returns>
        public static Article ToEntity(this TOArticle toArticle)
        {
            if (toArticle == null)
            {
                return null;
            }

            Article entity = new Article
            {
                Id = toArticle.Identifiant,
                Nom = toArticle.Nom,
                IdCategorie = toArticle.toCategorie.Identifiant,
                Prix=toArticle.Prix,
                Stock=toArticle.Stock
                    
            };
            return entity;
        }
    }
}

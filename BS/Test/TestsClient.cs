using BS.BusinessServices;
using DAL.Domaine;
using DAL.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TO;

namespace BS.Test
{
    // probleme test BS car librairie

    //using NUnit.Framework;
    [TestFixture]
    public class NUnitArticleController
    {

        //[Test]
        //public void testMoq()
        //{
        //    var moqArticleRepo = new Mock<IDomaineArticle>();
        //    var moqBS = new Mock<BSArticle>();

        //    //init moq
        //    var listArticles = new List<Article>();
        //    listArticles.Add(new Article { Nom = "foo" });
        //    listArticles.Add(new Article { Nom = "bar" });
        //    listArticles.Add(new Article { Nom = "doe" });
        //    moqArticleRepo.Setup(x => x.GetAllArticles()).Returns(() => listArticles);

        //    //BusinessService.Instance.Article.GetAllArticles();

        //}

        //[Test]
        //public void testGetAllClient()
        //{
        //    var bs = BusinessService.Instance;

        //    int nb;

        //    nb = bs.Article.GetAllArticles().Count;

        //    Assert.IsTrue(nb > 0);
        //}

    }
}

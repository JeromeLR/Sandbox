using BS.BusinessServices;
using DAL.Domaine;
using DAL.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TO;

namespace BS.Test
{
    [TestFixture]
    public class SuccessTests
    {
        //private BusinnessServiceCRM bs;

        [SetUp]
        public void Setup()
        {
           
        }

       

        [Test]
        public void CreateArticle()
        {
            var bs = BusinessService.Instance;

            var a = bs.Article.GetArticleById(1);

            Assert.AreEqual(a.Nom,"Lunettes");
        }

        [Test]
        public void CreateArticle_MOQ()
        {
            // moq domainearticle
            var MockDomaineArticle = new Mock<IDomaineArticle>();
            //initmoq
            MockDomaineArticle.Setup(x => x.GetArticleById(It.IsAny<int>())).Returns(new Article
            {
                Nom = "poisson en plastique",
                Prix = 10,
                Stock = 10
            });


            // comment le BS peut il utiliser ce mock ???
            var bs = BusinessService.Instance;
            bs.DomaineArticle = MockDomaineArticle.Object;

            var a = bs.Article.GetArticleById(1);

            Assert.AreEqual(a.Nom, "poisson en plastique");
        }

        [Test]
        public void CreateArticletest_MOQ()
        {
            // moq domainearticle
            var MockDomaineArticle = new Mock<IDomaineArticle>();
            //initmoq
            MockDomaineArticle.Setup(x => x.GetArticleById(It.IsAny<int>())).Returns(new Article
            {
                Nom = "poisson en plastique",
                Prix = 10,
                Stock = 10
            });


            // comment le BS peut il utiliser ce mock ???
            var bs = BusinessService.Instance;
            bs.DomaineArticle = MockDomaineArticle.Object;

            var a = bs.Article.GetArticleById_testMoq(1);

            Assert.AreEqual(a.Nom, "nouveau nom!");
        }
    }
    
}

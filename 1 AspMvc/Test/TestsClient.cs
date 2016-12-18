using BS;
using BS.BusinessServices;
using Moq;
using mvctest.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using TO;

namespace _1_AspMvc.Test
{


    // [SetUpFixture]
    //public class before_tests_run
    //{
    //    [SetUp]
    //    public void ControllerASetup()
    //    {
    //        _fakeRepository = FakeRepository.Create();

    //        _controllerA = new ControllerA(_fakeRepository);
    //    }
    //}


    //using NUnit.Framework;
    [TestFixture]
    public class NUnitArticleController
    {

        [Test]
        public void testArticleController()
        {
            // moq BS
            var BSarticleMoq = new Mock<IBSArticle>();

            //init moq
            BSarticleMoq.Setup(x => x.GetArticleById(It.IsAny<int>())).Returns(new TOArticle
            {
                Nom = "poisson en plastique",
                Prix = 10,
                Stock = 10,

            });

            // instanciation controller Article
            var controller = new ArticleController(BSarticleMoq.Object);
            
            // Execution methode Index
            ActionResult result = controller.Edit(5);


            Assert.IsNotNull(result);

        }

        [Test]
        public void testArticleController2()
        {
            // moq BS
            var BSarticleMoq = new Mock<IBSArticle>();           

            //init moq
            var listArticles = new List<TOArticle>();
            listArticles.Add(new TOArticle { Nom = "foo" });
            listArticles.Add(new TOArticle { Nom = "bar" });
            listArticles.Add(new TOArticle { Nom = "doe" });

            BSarticleMoq.Setup(x => x.GetAllArticles()).Returns(() => listArticles);


            // instanciation controller Article
            var controller = new ArticleController(BSarticleMoq.Object);


            // Execution methode Index
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<TOArticle>;


            Assert.AreEqual(3, model.Count);

        }
    }
}

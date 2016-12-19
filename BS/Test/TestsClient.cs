using DAL.Entities;
using Effort.Provider;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BS.Test
{
    [TestFixture]
    public class SuccessTests
    {

        [SetUp]
        public void Setup()
        {
            EffortProviderConfiguration.RegisterProvider();
        }

        private modelEntities1 CreateContext()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            //var connection = Effort.EntityConnectionFactory.CreateTransient(connectionString);
            //return new Entities(connection as DbConnection);

            var connection = Effort.EntityConnectionFactory.CreatePersistent("name=modelEntities1");
            var context = new modelEntities1(connection);
            return context;
        }

        [Test]
        public void Testing_Entity_Effort()
        {
            using (var context = CreateContext())
            {
                var article = context.Article.First();
                Assert.IsNotNull(article);
            }
            
        }
    }
    
}

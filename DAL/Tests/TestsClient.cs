

using NUnit.Framework;

namespace DAL.Domaine
{

    //using NUnit.Framework;
    [TestFixture]
    public class NUnitClient
    {
      
        [Test]
        public void testGetAllClient()
        {
            int nb;

            var x = new DomaineClient();

            nb = x.GetAllClients().Count;

            Assert.IsTrue(nb > 0);
        }

        [Test]
        public void testGetClientById()
        {

            var x = new DomaineClient();

            var c = x.GetClientById(1);

            Assert.IsNotNull(c.Nom);
        }

        [Test]
        public void testGetAllligneCommande()
        {
            int nb;

            var x = new DomaineLigneCommande();

            nb = x.GetAllLigneCommande().Count;

            Assert.IsTrue(nb > 0);
        }
    }
}

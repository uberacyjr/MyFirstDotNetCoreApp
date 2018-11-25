using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyFirstApp.Service.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void When_Search_Return_Persons()
        {
            //https://stackoverflow.com/questions/40876507/net-core-unit-testing-mock-ioptionst
            //Como testar classes que usam IOptions
            IOptions<ConnectionStrings> someOptions = Options.Create<ConnectionStrings>(new ConnectionStrings { DefaultConnection = "Server=.;Database=MyFirstApp;Trusted_Connection=True;MultipleActiveResultSets=true" });
            var teste = new PersonListService(someOptions);
            var persons = teste.GetAllPersons();
            Assert.IsNotNull(persons);
        }
    }
}

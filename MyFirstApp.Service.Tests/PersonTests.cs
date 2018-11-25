using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstApp.Domain;
using MyFirstApp.Infrastructure;

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
            IOptions<ConnectionHelper> someOptions = Options.Create<ConnectionHelper>(new ConnectionHelper { DefaultConnection = "Server=.;Database=MyFirstApp;Trusted_Connection=True;MultipleActiveResultSets=true" });
            var personsFromInfrastructure = new SqlQuery<Person>(someOptions);
            var personsFromService= new PersonListService(personsFromInfrastructure);
            var persons = personsFromService.GetAllPersons();
            Assert.IsNotNull(persons);
        }
    }
}

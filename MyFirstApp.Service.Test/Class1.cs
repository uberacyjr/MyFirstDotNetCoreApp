using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MyFirstApp.Service.Test
{
    public class PersonTests
    {
        //https://stackoverflow.com/questions/40876507/net-core-unit-testing-mock-ioptionst
        //Como testar classes que usam IOptions
        [Fact]
        public void Return_All_Persons_From_DB()
        {
            IOptions<ConnectionStrings> someOptions = Options.Create<ConnectionStrings>(new ConnectionStrings { DefaultConnection = "Server=.;Database=MyFirstApp;Trusted_Connection=True;MultipleActiveResultSets=true" });
            var teste = new PersonListService(someOptions);
            var persons = teste.GetAllPersons();
            Assert.NotNull(persons);
        }
    }

}

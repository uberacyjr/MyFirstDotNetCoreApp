using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFirstApp.Domain;
using MyFirstApp.Service;

namespace MyFirstApp.Web.Pages
{
    public class TesteModel : PageModel
    {
        public PersonListService _person { get; set; }
        public TesteModel(PersonListService person)
        {
            _person = person;
        }
        public string Description { get; set; }
        public string Title { get; set; }
        public List<Person> Persons { get; set; }
        public void OnGet()
        {
            Persons = _person.GetAllPersons();
            Title = "Razor Pages";
            Description = "Razor Pages is the recommended way to build UI for web apps in ASP.NET Core.";
        }
    }
}
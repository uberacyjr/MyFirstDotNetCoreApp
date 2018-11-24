using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstApp.Web.Pages
{
    public class TesteModel : PageModel
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public void OnGet()
        {
            Title = "Razor Pages";
            Description = "Razor Pages is the recommended way to build UI for web apps in ASP.NET Core.";
        }
    }
}
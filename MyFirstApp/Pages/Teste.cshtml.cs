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
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public void OnGet()
        {
            Titulo = "Razor Pages";
            Descricao = "This tutorial teaches the basics of building an ASP.NET Core Razor Pages web app.";
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;  

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        //GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        //GET: /HelloWorld/Welcome/
        public IActionResult Welcome(string name, int NumTimes)
        {
            //return HtmlEncoder.Default.Encode($"Hello {name}, ID is {ID}");
            ViewData["Message"] = $"{name} IS FUCKINGGG COOOOOLLLLL";
            ViewData["NumTimes"] = NumTimes;
            return View();
        }
    }
}

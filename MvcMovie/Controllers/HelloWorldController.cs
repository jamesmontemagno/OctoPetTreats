using DequeNet;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        private static readonly ConcurrentDeque<string> _userMessages = new();

        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            _userMessages.PushRight($"Index: {DateTime.Now} Message:{"Welcome"}");
            ViewBag.TotalVisits = _userMessages.Count;
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        public string Welcome(string name, int ID = 1)
        {
            var totalVisits = _userMessages.Count;
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}, you have visited: {totalVisits} times");
        }
    }
}
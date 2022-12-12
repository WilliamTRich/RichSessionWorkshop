using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RichSessionWorkshop.Models;

namespace RichSessionWorkshop.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("view")]
    public IActionResult ViewResDefault()
    {
        int count = HttpContext.Session.GetInt32("Count") ?? 0;
        Console.WriteLine("I'm working");

        var user = new RichSessionWorkshop.Models.NameInput
        {
            Username = HttpContext.Session.GetString("Name"),
            Count = count
        };

        return View("View", user);
    }

    [HttpPost("process/count")]
    public ActionResult ViewRes(string operation)
    {
        Console.WriteLine("I'm working");
        int count = HttpContext.Session.GetInt32("Count") ?? 0;
        Console.WriteLine(operation);

        if (operation == "random")
        {
            Random rand = new Random();
            switch (rand.Next(1, 4))
            {
                case 1:
                    operation = "increment";
                    break;
                case 2:
                    operation = "decrement";
                    break;
                case 3:
                    operation = "multiply";
                    break;
            }
        }

        if (operation == "increment")
        {
            count++;
        }
        else if (operation == "decrement")
        {
            count--;
        }
        else if (operation == "multiply")
        {
            count *= 2;
        }
        else if (operation == "logout")
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        HttpContext.Session.SetInt32("Count", count);

        var user = new RichSessionWorkshop.Models.NameInput
        {
            Username = HttpContext.Session.GetString("Name"),
            Count = count
        };

        return View("View", user);
    }

    [HttpPost("process")]
    public IActionResult Process(NameInput input)
    {
        HttpContext.Session.SetString("Name", input.Username);
        HttpContext.Session.SetInt32("Count", 22);
        return RedirectToAction("ViewResDefault");
    }
}

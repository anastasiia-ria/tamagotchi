using Microsoft.AspNetCore.Mvc;
using Game.Models;
using System.Collections.Generic;

namespace Game.Controllers
{
  public class GameController : Controller
  {
    [HttpGet("/Game")]
    public ActionResult Index()
    {
      List<Tamagotchi> allGame = Tamagotchi.GetAll();
      return View(allGame);
    }

    [HttpGet("/Game/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/Game/{id}")]
    public ActionResult Show(int id)
    {
      Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
      return View(foundTamagotchi);
    }

    [HttpPost("/Game")]
    public ActionResult Create(string name, string length, string companion, string journal)
    {
      Tamagotchi myTamagotchi = new Tamagotchi(name, length, companion, journal);
      return RedirectToAction("Index");
    }

    [HttpPost("/Game/delete")]
    public ActionResult DeleteAll()
    {
      Tamagotchi.ClearAll();
      return View();
    }
  }
}
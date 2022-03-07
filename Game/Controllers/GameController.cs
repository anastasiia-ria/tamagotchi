using Microsoft.AspNetCore.Mvc;
using Game.Models;
using System.Collections.Generic;

namespace Game.Controllers
{
  public class GameController : Controller
  {
    [HttpGet("/game")]
    public ActionResult Index()
    {
      List<Tamagotchi> allGame = Tamagotchi.GetAll();
      return View(allGame);
    }

    [HttpGet("/game/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/game/{id}")]
    public ActionResult Show(int id)
    {
      Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
      return View(foundTamagotchi);
    }
    [HttpPost("/game")]
    public ActionResult Create(string name)
    {
      Tamagotchi myTamagotchi = new Tamagotchi(name);
      myTamagotchi.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/game/{id}/{care}")]
    public ActionResult Show(int id, string care)
    {
      Tamagotchi foundTamagotchi = Tamagotchi.Find(id);
      foundTamagotchi.Care(care);
      return View(foundTamagotchi);
    }

    [HttpPost("/game/delete")]
    public ActionResult DeleteAll()
    {
      Tamagotchi.ClearAll();
      return View();
    }
  }
}
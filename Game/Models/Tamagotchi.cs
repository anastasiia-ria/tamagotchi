using System.Collections.Generic;
using System.Timers;
namespace Game.Models
{
  public class Tamagotchi
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Attention { get; set; }
    public int Rest { get; set; }
    public bool Life { get; set; }
    public int Id { get; }
    private static List<Tamagotchi> _instances = new List<Tamagotchi> { };

    public Tamagotchi(string name)
    {
      Name = name;
      Food = 50;
      Attention = 50;
      Rest = 50;
      Life = true;
      _instances.Add(this);
      Id = _instances.Count;

      Timer timer = new Timer(10000);
      timer.AutoReset = true;
      timer.Elapsed += new System.Timers.ElapsedEventHandler(Decline);
      timer.Start();
    }

    private void Decline(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (Food > 0)
      {
        Food -= 5;
      }
      if (Attention > 0)
      {
        Attention -= 5;
      }
      if (Rest > 0)
      {
        Rest -= 5;
      }
      if (Food == 0 && Attention == 0 && Rest == 0)
      {
        Life = false;
      }
    }
    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void Care(string care)
    {
      switch (care)
      {
        case "food":
          if (Food <= 95)
          {
            Food += 5;
          }
          break;
        case "attention":
          if (Attention <= 95)
          {
            Attention += 5;
          }
          break;
        case "rest":
          if (Rest <= 95)
          {
            Rest += 5;
          }
          break;
        default:
          break;
      }
    }
  }
}
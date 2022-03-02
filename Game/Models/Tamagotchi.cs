using System.Collections.Generic;

namespace Game.Models
{
  public class Tamagotchi
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Attention { get; set; }
    public int Rest { get; set; }
    public int Id { get; }
    private static List<Tamagotchi> _instances = new List<Tamagotchi> { };

    public Tamagotchi(string name)
    {
      Name = name;
      Food = 100;
      Attention = 100;
      Rest = 100;
      _instances.Add(this);
      Id = _instances.Count;
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
  }
}
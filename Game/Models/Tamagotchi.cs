using System.Collections.Generic;
using System.Timers;
using MySql.Data.MySqlClient;
namespace Game.Models
{
  public class Tamagotchi
  {
    public string Name { get; set; }
    public int Food { get; set; }
    public int Attention { get; set; }
    public int Rest { get; set; }
    public bool Life { get; set; }
    public int Id { get; set; }

    public Tamagotchi(string name)
    {
      Name = name;
      Food = 50;
      Attention = 50;
      Rest = 50;
      Life = true;

      Timer timer = new Timer(60000);
      timer.AutoReset = true;
      timer.Elapsed += new System.Timers.ElapsedEventHandler(Decline);
      timer.Start();
    }
    public Tamagotchi(string name, int id)
    {
      Name = name;
      Id = id;
      Food = 50;
      Attention = 50;
      Rest = 50;
      Life = true;

      Timer timer = new Timer(60000);
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
      List<Tamagotchi> allTamagotchis = new List<Tamagotchi> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM tamagotchis;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int tamagotchiId = rdr.GetInt32(0);
        string tamagotchiName = rdr.GetString(1);
        Tamagotchi newTamagotchi = new Tamagotchi(tamagotchiName, tamagotchiId);
        allTamagotchis.Add(newTamagotchi);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allTamagotchis;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM tamagotchis;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Tamagotchi Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM `tamagotchis` WHERE id = @ThisId;";

      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int tamagotchiId = 0;
      string tamagotchiName = "";
      while (rdr.Read())
      {
        tamagotchiId = rdr.GetInt32(0);
        tamagotchiName = rdr.GetString(1);
      }
      Tamagotchi foundTamagotchi = new Tamagotchi(tamagotchiName, tamagotchiId);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundTamagotchi;
    }

    public override bool Equals(System.Object otherTamagotchi)
    {
      if (!(otherTamagotchi is Tamagotchi))
      {
        return false;
      }
      else
      {
        Tamagotchi newTamagotchi = (Tamagotchi)otherTamagotchi;
        bool idEquality = (this.Id == newTamagotchi.Id);
        bool nameEquality = (this.Name == newTamagotchi.Name);
        return (idEquality && nameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = "INSERT INTO tamagotchis (name, food, attention, rest, life) VALUES (@TamagotchiName, @TamagotchiFood, @TamagotchiAttention, @TamagotchiRest, @TamagotchiLife);";
      MySqlParameter paramName = new MySqlParameter();
      paramName.ParameterName = "@TamagotchiName";
      paramName.Value = this.Name;
      cmd.Parameters.Add(paramName);
      MySqlParameter paramFood = new MySqlParameter();
      paramFood.ParameterName = "@TamagotchiFood";
      paramFood.Value = this.Food;
      cmd.Parameters.Add(paramFood);
      MySqlParameter paramAttention = new MySqlParameter();
      paramAttention.ParameterName = "@TamagotchiAttention";
      paramAttention.Value = this.Attention;
      cmd.Parameters.Add(paramAttention);
      MySqlParameter paramRest = new MySqlParameter();
      paramRest.ParameterName = "@TamagotchiRest";
      paramRest.Value = this.Rest;
      cmd.Parameters.Add(paramRest);
      MySqlParameter paramLife = new MySqlParameter();
      paramLife.ParameterName = "@TamagotchiLife";
      paramLife.Value = this.Life;
      cmd.Parameters.Add(paramLife);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
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
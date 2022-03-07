using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Models;
using System.Collections.Generic;

namespace Game.Tests
{
  [TestClass]
  public class TamagotchiTests : IDisposable
  {
    public void Dispose()
    {
      Tamagotchi.ClearAll();
    }
    public TamagotchiTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=tamagotchi.test;";
    }
    // [TestMethod]
    // public void TamagotchiConstructor_CreatesInstanceOfTamagotchi_Tamagotchi()
    // {
    //   Tamagotchi newTamagotchi = new Tamagotchi("test");
    //   Assert.AreEqual(typeof(Tamagotchi), newTamagotchi.GetType());
    // }
    // [TestMethod]
    // public void GetName_Returns_Name_String()
    // {
    //   string name = "Walk the dog.";
    //   Tamagotchi newTamagotchi = new Tamagotchi(name);
    //   string result = newTamagotchi.Name;
    //   Assert.AreEqual(name, result);
    // }

    // [TestMethod]
    // public void SetName_SetName_String()
    // {
    //   string name = "Walk the dog.";
    //   Tamagotchi newTamagotchi = new Tamagotchi(name);
    //   string updatedName = "Do the dishes.";
    //   newTamagotchi.Name = updatedName;
    //   string result = newTamagotchi.Name;
    //   Assert.AreEqual(updatedName, result);
    // }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_TamagotchiList()
    {
      List<Tamagotchi> newList = new List<Tamagotchi> { };
      List<Tamagotchi> result = Tamagotchi.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsGame_TamagotchiList()
    {
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Tamagotchi newTamagotchi1 = new Tamagotchi(name01);
      newTamagotchi1.Save();
      Tamagotchi newTamagotchi2 = new Tamagotchi(name02);
      newTamagotchi2.Save();
      List<Tamagotchi> newList = new List<Tamagotchi>{
        newTamagotchi1, newTamagotchi2
      };

      List<Tamagotchi> result = Tamagotchi.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      // Arrange, Act
      Tamagotchi firstTamagotchi = new Tamagotchi("Mow the lawn");
      Tamagotchi secondTamagotchi = new Tamagotchi("Mow the lawn");

      // Assert
      Assert.AreEqual(firstTamagotchi, secondTamagotchi);
    }

    [TestMethod]
    public void Find_ReturnsCorrectTamagotchi_Tamagotchi()
    {
      //Arrange
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Tamagotchi newTamagotchi1 = new Tamagotchi(name01);
      newTamagotchi1.Save();
      Tamagotchi newTamagotchi2 = new Tamagotchi(name02);
      newTamagotchi2.Save();

      //Act
      Tamagotchi result = Tamagotchi.Find(newTamagotchi2.Id);

      //Assert
      Assert.AreEqual(newTamagotchi2, result);
    }
    [TestMethod]
    public void Save_SavesToDatabase_TamagotchiList()
    {
      //Arrange
      Tamagotchi testTamagotchi = new Tamagotchi("Mow the lawn");

      //Act
      testTamagotchi.Save();
      List<Tamagotchi> result = Tamagotchi.GetAll();
      List<Tamagotchi> testList = new List<Tamagotchi> { testTamagotchi };

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }


  }
}
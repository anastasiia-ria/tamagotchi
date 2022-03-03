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
    [TestMethod]
    public void TamagotchiConstructor_CreatesInstanceOfTamagotchi_Tamagotchi()
    {
      Tamagotchi newTamagotchi = new Tamagotchi("test");
      Assert.AreEqual(typeof(Tamagotchi), newTamagotchi.GetType());
    }
    [TestMethod]
    public void GetName_Returns_Name_String()
    {
      string name = "Walk the dog.";
      Tamagotchi newTamagotchi = new Tamagotchi(name);
      string result = newTamagotchi.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetName_String()
    {
      string name = "Walk the dog.";
      Tamagotchi newTamagotchi = new Tamagotchi(name);
      string updatedName = "Do the dishes.";
      newTamagotchi.Name = updatedName;
      string result = newTamagotchi.Name;
      Assert.AreEqual(updatedName, result);
    }
    [TestMethod]
    public void GetAll_ReturnsEmptyList_TamagotchiList()
    {
      List<Tamagotchi> newList = new List<Tamagotchi> { };
      List<Tamagotchi> result = Tamagotchi.GetAll();
      foreach (Tamagotchi thisTamagotchi in result)
      {
        Console.WriteLine("Output from empty list GetAll test: " + thisTamagotchi.Name);
      }
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void GetAll_ReturnsGame_TamagotchiList()
    {
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Tamagotchi newTamagotchi1 = new Tamagotchi(name01);
      Tamagotchi newTamagotchi2 = new Tamagotchi(name02);
      List<Tamagotchi> newList = new List<Tamagotchi>{
        newTamagotchi1, newTamagotchi2
      };

      List<Tamagotchi> result = Tamagotchi.GetAll();
      foreach (Tamagotchi thisTamagotchi in result)
      {
        Console.WriteLine("Output from second GetAll test: " + thisTamagotchi.Name);
      }
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_GameInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string name = "Walk the dog.";
      Tamagotchi newTamagotchi = new Tamagotchi(name);

      //Act
      int result = newTamagotchi.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectTamagotchi_Tamagotchi()
    {
      //Arrange
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Tamagotchi newTamagotchi1 = new Tamagotchi(name01);
      Tamagotchi newTamagotchi2 = new Tamagotchi(name02);

      //Act
      Tamagotchi result = Tamagotchi.Find(2);

      //Assert
      Assert.AreEqual(newTamagotchi2, result);
    }
  }
}
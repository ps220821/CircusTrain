using CircrusTrain.Interfaces;
using CircrusTrain.Wagons;
using CircusTrainTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CircrusTrain.Models.Animal;

namespace CircusTrainTests
{
    [TestClass]
    public class WagonTests
    {
        private IWagon CreateWagon() => new Wagon();

        [TestMethod]
        public void CanAddAnimal_WhenPointsExceedMax_ReturnsFalse()
        {
            var wagon = CreateWagon();
            wagon.AddAnimal(TestHelper.CreateAnimal("Elephant", AnimalSize.Large, AnimalDiet.Herbivore)); // 5
            wagon.AddAnimal(TestHelper.CreateAnimal("Elephant", AnimalSize.Large, AnimalDiet.Herbivore)); // 5
            var result = wagon.CanAddAnimal(TestHelper.CreateAnimal("Rhino", AnimalSize.Large, AnimalDiet.Herbivore)); // 5
            Assert.IsFalse(result); // Line 30
        }

        [TestMethod]
        public void CanAddAnimal_CarnivoreWithSmallerPrey_ReturnsFalse()
        {
            // Arrange
            var wagon = CreateWagon();
            wagon.AddAnimal(TestHelper.CreateAnimal("Rabbit", AnimalSize.Small, AnimalDiet.Herbivore));

            // Act
            var result = wagon.CanAddAnimal(TestHelper.CreateAnimal("Lion", AnimalSize.Large, AnimalDiet.Carnivore));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddAnimal_ValidAddition_UpdatesState()
        {
            // Arrange
            var wagon = CreateWagon();
            var animal = TestHelper.CreateAnimal("Zebra", AnimalSize.Medium, AnimalDiet.Herbivore);

            // Act
            wagon.AddAnimal(animal);

            // Assert
            Assert.AreEqual(1, wagon.Animals.Count);
            Assert.AreEqual(3, wagon.CurrentPoints);
            Assert.AreEqual(animal, wagon.Animals[0]);
        }
    }
}
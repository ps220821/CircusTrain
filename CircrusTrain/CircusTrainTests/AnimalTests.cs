using CircrusTrain.Models;
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
    public class AnimalTests
    {
        [TestMethod]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var animal = TestHelper.CreateAnimal("Lion", AnimalSize.Large, AnimalDiet.Carnivore);

            // Assert
            Assert.AreEqual("Lion", animal.Name);
            Assert.AreEqual(AnimalSize.Large, animal.Size);
            Assert.AreEqual(AnimalDiet.Carnivore, animal.Diet);
        }

        [TestMethod]
        public void Properties_AreImmutable()
        {
            // Arrange
            var animal = TestHelper.CreateAnimal("Tiger", AnimalSize.Medium, AnimalDiet.Herbivore);

            // Assert (Reflection ensures no setters)
            Assert.IsFalse(typeof(Animal).GetProperty("Name")?.CanWrite ?? true);
            Assert.IsFalse(typeof(Animal).GetProperty("Size")?.CanWrite ?? true);
            Assert.IsFalse(typeof(Animal).GetProperty("Diet")?.CanWrite ?? true);
        }
    }
}
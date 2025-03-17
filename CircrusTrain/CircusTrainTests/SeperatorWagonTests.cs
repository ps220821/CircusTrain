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
    public class SeparatorWagonTests
    {
        private IWagon CreateSeparatorWagon() => new SeparatorWagon();

        [TestMethod]
        public void CanAddAnimal_LargeAnimal_ReturnsFalse()
        {
            // Arrange
            var wagon = CreateSeparatorWagon();

            // Act
            var result = wagon.CanAddAnimal(TestHelper.CreateAnimal("Lion", AnimalSize.Large, AnimalDiet.Carnivore));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddAnimal_ThirdAnimal_ReturnsFalse()
        {
            // Arrange
            var wagon = TestHelper.CreateFilledSeparatorWagon(
                TestHelper.CreateAnimal("Penguin1", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin2", AnimalSize.Medium, AnimalDiet.Carnivore));

            // Act
            var result = wagon.CanAddAnimal(TestHelper.CreateAnimal("Penguin3", AnimalSize.Medium, AnimalDiet.Carnivore));

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanAddAnimal_CompatiblePair_ReturnsTrue()
        {
            // Arrange
            var wagon = CreateSeparatorWagon();
            wagon.AddAnimal(TestHelper.CreateAnimal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore));

            // Act
            var result = wagon.CanAddAnimal(TestHelper.CreateAnimal("Ape", AnimalSize.Medium, AnimalDiet.Herbivore));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAnimal_ExceedsCapacity_ThrowsException()
        {
            // Arrange
            var wagon = TestHelper.CreateFilledSeparatorWagon(
                TestHelper.CreateAnimal("Penguin1", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin2", AnimalSize.Medium, AnimalDiet.Carnivore));

            // Act
            wagon.AddAnimal(TestHelper.CreateAnimal("Penguin3", AnimalSize.Medium, AnimalDiet.Carnivore));
        }
    }
}

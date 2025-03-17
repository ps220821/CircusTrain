using CircrusTrain.Interfaces;
using CircrusTrain.Models;
using CircrusTrain.Train;
using CircrusTrain.Wagons;
using CircusTrainTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using static CircrusTrain.Models.Animal;

namespace CircusTrainTests
{
    [TestClass]
    public class TrainTests
    {
        private Wagon CreateWagon() => new Wagon();
        private Train CreateTrain(List<Animal> animals)
        {
            var printer = new Mock<IWagonPrinter>().Object;
            return new Train(animals, printer);
        }


        [TestMethod]
        public void DistributeAnimals_CarnivoreSafety_MaintainsSeparation()
        {
            // Arrange
            var animals = new List<Animal>
            {
                TestHelper.CreateAnimal("Lion", AnimalSize.Large, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Rabbit", AnimalSize.Small, AnimalDiet.Herbivore)
            };
            var train = CreateTrain(animals);

            // Act
            train.fillWagons();

            // Assert
            foreach (var wagon in train.Wagons)
            {
                var carnivores = wagon.Animals.Where(a => a.Diet == AnimalDiet.Carnivore).ToList();
                if (carnivores.Any())
                {
                    var maxSize = carnivores.Max(a => a.Size);
                    Assert.IsFalse(wagon.Animals.Any(a => a.Diet == AnimalDiet.Herbivore && a.Size <= maxSize));
                }
            }
        }

        [TestMethod]
        public void DistributeAnimals_MaxFourSeparatorWagons_RespectsLimit()
        {
            // Arrange
            var animals = new List<Animal>
            {
                TestHelper.CreateAnimal("Penguin1", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin2", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin3", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin4", AnimalSize.Medium, AnimalDiet.Carnivore),
                TestHelper.CreateAnimal("Penguin5", AnimalSize.Medium, AnimalDiet.Carnivore)
            };
            var train = CreateTrain(animals);

            // Act
            train.fillWagons();

            // Assert
            var separatorCount = train.Wagons.Count(w => w is SeparatorWagon);
            Assert.IsTrue(separatorCount <= 4);
        }

        [TestMethod]
        public void CanAddAnimal_WhenPointsExceedMax_ReturnsFalse()
        {
            var wagon = CreateWagon();
            wagon.AddAnimal(new Animal("Elephant", AnimalSize.Large, AnimalDiet.Herbivore)); // 5 points
            wagon.AddAnimal(new Animal("Zebra", AnimalSize.Medium, AnimalDiet.Herbivore));  // 3 points, total 8
            var result = wagon.CanAddAnimal(new Animal("Giraffe", AnimalSize.Large, AnimalDiet.Herbivore)); // 5 points, total 13
            Assert.IsFalse(result); // Should pass now
        }
    }
}
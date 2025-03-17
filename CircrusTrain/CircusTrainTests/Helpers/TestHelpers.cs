using CircrusTrain.Models;
using CircrusTrain.Wagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CircrusTrain.Models.Animal;

namespace CircusTrainTests.Helpers
{
    public static class TestHelper
    {
        public static Animal CreateAnimal(string name, AnimalSize size, AnimalDiet diet)
        {
            return new Animal(name, size, diet);
        }

        public static Wagon CreateFilledWagon(params Animal[] animals)
        {
            var wagon = new Wagon();
            foreach (var animal in animals)
            {
                wagon.AddAnimal(animal);
            }
            return wagon;
        }

        public static SeparatorWagon CreateFilledSeparatorWagon(params Animal[] animals)
        {
            var wagon = new SeparatorWagon();
            foreach (var animal in animals)
            {
                wagon.AddAnimal(animal);
            }
            return wagon;
        }

        public static List<Animal> GetSampleAnimals()
        {
            return new List<Animal>
            {
                CreateAnimal("Lion", AnimalSize.Large, AnimalDiet.Carnivore),
                CreateAnimal("Rabbit", AnimalSize.Small, AnimalDiet.Herbivore),
                CreateAnimal("Zebra", AnimalSize.Medium, AnimalDiet.Herbivore),
                CreateAnimal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore)
            };
        }
    }
}

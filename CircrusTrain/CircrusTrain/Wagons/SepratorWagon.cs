using CircrusTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Wagons
{
    public class SeparatorWagon : Wagon
    {
        private const int MaxAnimals = 2;

        public override bool CanAddAnimal(Animal animal)
        {
            if (Animals.Count >= MaxAnimals || animal.Size == Animal.AnimalSize.Large)
                return false;

            if (Animals.Count == 0)
                return true;

            var existingAnimal = Animals[0];
            return (existingAnimal.Diet == Animal.AnimalDiet.Carnivore && animal.Diet == Animal.AnimalDiet.Carnivore) ||
                   (existingAnimal.Diet != animal.Diet);
        }
    }
}

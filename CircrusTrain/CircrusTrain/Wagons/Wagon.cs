using CircrusTrain.Interfaces;
using CircrusTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Wagons
{
    public class Wagon : IWagon
    {
        private const int MaxPoints = 10;
        private readonly List<Animal> _animals = new();

        public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();
        public int CurrentPoints { get; private set; }

        public virtual bool CanAddAnimal(Animal animal)
        {
            if (CurrentPoints + (int)animal.Size > MaxPoints)
                return false;

            if (animal.Diet == Animal.AnimalDiet.Carnivore)
            {
                if (Animals.Any(a => (int)a.Size <= (int)animal.Size))
                {
                    return false;
                }
            }

            if (CurrentPoints + (int)animal.Size > MaxPoints)
            {
                return false;
            }

            return true;
        }

        public void AddAnimal(Animal animal)
        {
            if (!CanAddAnimal(animal))
                throw new InvalidOperationException("Cannot add animal to wagon.");
            _animals.Add(animal);
            CurrentPoints += (int)animal.Size;
        }
    }
}
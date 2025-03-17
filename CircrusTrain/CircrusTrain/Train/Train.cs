using CircrusTrain.Interfaces;
using CircrusTrain.Models;
using CircrusTrain.Wagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Train
{
    public class Train : ITrain
    {
        private readonly List<Wagon> _wagons = new();
        private readonly List<Animal> _animals;
        private readonly IWagonPrinter _printer;
        private const int MaxSeparatorWagons = 4;
        private int _separatorWagonCount = 0;

        public IReadOnlyList<Wagon> Wagons => _wagons.AsReadOnly();

        public Train(List<Animal> animals, IWagonPrinter printer)
        {
            _animals = new List<Animal>(animals);
            _printer = printer;
        }

        public void DistributeAnimals()
        {
            SortAnimals();
            foreach (var animal in _animals)
            {
                if (!TryAddToExistingWagon(animal))
                {
                    AddToNewWagon(animal);
                }
            }
            _printer.PrintTrain(Wagons);
        }

        private void SortAnimals()
        {
            _animals.Sort((a, b) =>
            {
                int dietCompare = b.Diet.CompareTo(a.Diet); // Carnivores first
                return dietCompare != 0 ? dietCompare : b.Size.CompareTo(a.Size); // Larger first
            });
        }

        private bool TryAddToExistingWagon(Animal animal)
        {
            foreach (var wagon in _wagons)
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    return true;
                }
            }
            return false;
        }

        private void AddToNewWagon(Animal animal)
        {
            if (animal.Size != Animal.AnimalSize.Large && _separatorWagonCount < MaxSeparatorWagons)
            {
                var separatorWagon = new SeparatorWagon();
                separatorWagon.AddAnimal(animal);
                _wagons.Add(separatorWagon);
                _separatorWagonCount++;
            }
            else
            {
                var wagon = new Wagon();
                wagon.AddAnimal(animal);
                _wagons.Add(wagon);
            }
        }
    }
}
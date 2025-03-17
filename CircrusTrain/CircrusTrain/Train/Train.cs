using CircrusTrain.Interfaces;
using CircrusTrain.Models;
using CircrusTrain.Wagons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Train
{
    public class Train : ITrain
    {
        private readonly List<Wagon> _wagons = new();
        private  List<Animal> _animals;
        private readonly IWagonPrinter _printer;
        private const int MaxSeparatorWagons = 4;
        private int _separatorWagonCount = 0;

        public ReadOnlyCollection<Wagon> Wagons => _wagons.AsReadOnly();

        public Train(List<Animal> animals, IWagonPrinter printer)
        {
            _animals = new List<Animal>(animals);
            _printer = printer ?? throw new ArgumentNullException(nameof(printer));
        }

        public void fillWagons()
        {
            SortAnimals();
            foreach (var animal in _animals)
            {
                bool added = false;
                foreach (var wagon in _wagons)
                {
                    if (wagon.CanAddAnimal(animal))
                    {
                        wagon.AddAnimal(animal);
                        added = true;
                        break;
                    }
                }

                if (!added)
                {
                    if (animal.Size != Animal.AnimalSize.Large)
                    {
                        if (_separatorWagonCount != MaxSeparatorWagons)
                        {
                            SeparatorWagon separatorWagon = new SeparatorWagon();
                            separatorWagon.AddAnimal(animal);
                            _wagons.Add(separatorWagon);
                        }
                    }
                    else
                    {
                        Wagon newWagon = new Wagon();
                        newWagon.AddAnimal(animal);
                        _wagons.Add(newWagon);
                    }
                }
            }
            PrintTrain();
        }

        private void SortAnimals()
        {
            _animals = _animals
            .OrderByDescending(a => a.Diet == Animal.AnimalDiet.Herbivore)  // Carnivoren eerst (False < True)
            .ThenByDescending(a => a.Size)  // Grootste dieren eerst
            .ToList();
        }

        public void PrintTrain()
        {
            _printer.PrintTrain(Wagons);
        }
    }
}
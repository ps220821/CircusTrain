using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Models
{
    public class Animal
    {
        public enum AnimalSize
        {
            Small = 1,
            Medium = 3,
            Large = 5
        }

        public enum AnimalDiet
        {
            Carnivore,
            Herbivore
        }

        public string Name { get; }
        public AnimalSize Size { get; }
        public AnimalDiet Diet { get; }

        public Animal(string name, AnimalSize size, AnimalDiet diet)
        {
            Name = name;
            Size = size;
            Diet = diet;
        }
    }
}

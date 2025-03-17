using CircrusTrain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Interfaces
{
    public interface IWagon
    {
        IReadOnlyList<Animal> Animals { get; }
        int CurrentPoints { get; }
        bool CanAddAnimal(Animal animal);
        void AddAnimal(Animal animal);
    }
}

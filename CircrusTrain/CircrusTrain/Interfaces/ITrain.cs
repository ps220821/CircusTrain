using CircrusTrain.Wagons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Interfaces
{
    public interface ITrain
    {
        ReadOnlyCollection<Wagon> Wagons { get; }
        void fillWagons();
        void PrintTrain();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Interfaces
{
    public interface IWagonPrinter
    {
        void PrintWagon(IWagon wagon);
        void PrintTrain(IReadOnlyList<IWagon> wagons);
    }
}

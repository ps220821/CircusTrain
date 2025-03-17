using CircrusTrain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircrusTrain.Wagons
{
    public class WagonPrinter : IWagonPrinter
    {
        public void PrintWagon(IWagon wagon)
        {
            string wagonType = wagon is SeparatorWagon ? "Separator Wagon" : "Wagon";
            Console.WriteLine($"{wagonType} with {wagon.Animals.Count} animals (Points: {wagon.CurrentPoints}/10)");
            foreach (var animal in wagon.Animals)
            {
                Console.WriteLine($" - {animal.Name} ({animal.Size}, {animal.Diet})");
            }
            Console.WriteLine();
        }

        public void PrintTrain(IReadOnlyList<IWagon> wagons)
        {
            Console.WriteLine($"Train with {wagons.Count} wagons:");
            foreach (var wagon in wagons)
            {
                PrintWagon(wagon);
            }
        }
    }
}

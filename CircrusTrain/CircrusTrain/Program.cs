using CircrusTrain.Models;
using CircrusTrain.Train;
using CircrusTrain.Wagons;
using static CircrusTrain.Models.Animal;

var animals = new List<Animal>
{
    new Animal("Lion", AnimalSize.Large, AnimalDiet.Carnivore),
    new Animal("Tiger", AnimalSize.Large, AnimalDiet.Carnivore),
    new Animal("Polar Bear", AnimalSize.Large, AnimalDiet.Carnivore),

    // Medium Carnivore
    new Animal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore),
    new Animal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore),
    new Animal("Penguin", AnimalSize.Small, AnimalDiet.Carnivore),
    new Animal("Penguin", AnimalSize.Small, AnimalDiet.Carnivore),

    // Large Herbivores
    new Animal("Elephant", AnimalSize.Large, AnimalDiet.Herbivore),
    new Animal("Rhino", AnimalSize.Large, AnimalDiet.Herbivore),
    new Animal("Giraffe", AnimalSize.Large, AnimalDiet.Herbivore),
    
    // Medium Herbivores
    new Animal("Ape", AnimalSize.Medium, AnimalDiet.Herbivore),
    new Animal("Ape", AnimalSize.Medium, AnimalDiet.Herbivore),
    new Animal("Zebra", AnimalSize.Medium, AnimalDiet.Herbivore),
    new Animal("Panda", AnimalSize.Medium, AnimalDiet.Herbivore),

    // Small Herbivores
    new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),
    new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),
    new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),

    // Large Carnivore
    new Animal("Grizzly Bear", AnimalSize.Large, AnimalDiet.Carnivore)
};

var printer = new WagonPrinter();
var train = new Train(animals, printer);
train.fillWagons();
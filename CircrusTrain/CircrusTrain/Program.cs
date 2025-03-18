using CircrusTrain.Models;
using CircrusTrain.Train;
using CircrusTrain.Wagons;
using static CircrusTrain.Models.Animal;

List<Animal> animals = new List<Animal>();
while (true)
{
    Console.WriteLine("Make a choice:");
    Console.WriteLine("1. Add animals");
    Console.WriteLine("2. Use Default list");
    Console.WriteLine("3. Fill wagons and show");
    Console.WriteLine("4. Stop");

    string choice = Console.ReadLine().Trim();
    if (choice == "1")
    {
        animals.AddRange(GetUserAnimals());
    }
    else if (choice == "2")
    {
        animals = GetDefaultAnimals();
        var printer = new WagonPrinter();
        var train = new Train(animals, printer);
        train.fillWagons();
    }
    else if (choice == "3")
    {
        var printer = new WagonPrinter();
        var train = new Train(animals, printer);
        train.fillWagons();
    }
    else if (choice == "4")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice make a new one.");
    }
}

static List<Animal> GetUserAnimals()
{
    List<Animal> animals = new List<Animal>();
    while (true)
    {
        Console.WriteLine("Add an animal (enter name only) or type 'done' to stop:");
        string name = Console.ReadLine().Trim();
        if (name.ToLower() == "done") break;

        Console.WriteLine("Choose the animal's diet:");
        Console.WriteLine("1. Herbivoor");
        Console.WriteLine("2. Carnivoor");

        AnimalDiet diet;
        string dietInput = Console.ReadLine().Trim();
        if (dietInput == "1")
        {
            diet = AnimalDiet.Herbivore;
        }
        else if (dietInput == "2")
        {
            diet = AnimalDiet.Carnivore;
        }
        else
        {
            Console.WriteLine("Invalid choice, Herbivore chosen by default.");
            diet = AnimalDiet.Herbivore;
        }

        Console.WriteLine("Choose the size of the animal:");
        Console.WriteLine("1. Small");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Large");

        AnimalSize size;
        string sizeInput = Console.ReadLine().Trim();
        if (sizeInput == "1")
        {
            size = AnimalSize.Small;
        }
        else if (sizeInput == "2")
        {
            size = AnimalSize.Medium;
        }
        else if (sizeInput == "3")
        {
            size = AnimalSize.Large;
        }
        else
        {
            Console.WriteLine("Invalid selection, default Medium selected.");
            size = AnimalSize.Medium;
        }

        animals.Add(new Animal(name, size, diet));
        Console.WriteLine($"{name} added as {size} {diet}.");
    }
    return animals;
}

static List<Animal> GetDefaultAnimals()
{
    return new List<Animal>
        {
            new Animal("Lion", AnimalSize.Large, AnimalDiet.Carnivore),
            new Animal("Tiger", AnimalSize.Large, AnimalDiet.Carnivore),
            new Animal("Polar Bear", AnimalSize.Large, AnimalDiet.Carnivore),
            new Animal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore),
            new Animal("Penguin", AnimalSize.Medium, AnimalDiet.Carnivore),
            new Animal("Penguin", AnimalSize.Small, AnimalDiet.Carnivore),
            new Animal("Penguin", AnimalSize.Small, AnimalDiet.Carnivore),
            new Animal("Elephant", AnimalSize.Large, AnimalDiet.Herbivore),
            new Animal("Rhino", AnimalSize.Large, AnimalDiet.Herbivore),
            new Animal("Giraffe", AnimalSize.Large, AnimalDiet.Herbivore),
            new Animal("Ape", AnimalSize.Medium, AnimalDiet.Herbivore),
            new Animal("Ape", AnimalSize.Medium, AnimalDiet.Herbivore),
            new Animal("Zebra", AnimalSize.Medium, AnimalDiet.Herbivore),
            new Animal("Panda", AnimalSize.Medium, AnimalDiet.Herbivore),
            new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),
            new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),
            new Animal("Koala", AnimalSize.Small, AnimalDiet.Herbivore),
            new Animal("Grizzly Bear", AnimalSize.Large, AnimalDiet.Carnivore)
        };
}


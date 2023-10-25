using System;
using System.Collections.Generic;

public class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public LivingOrganism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}

public class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public Animal(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Reproduce()
    {
        Console.WriteLine($"The {Species} is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine($"The {Species} is hunting.");
        
        prey.Energy -= 10;
        Energy += 10;
    }
}

public class Plant : LivingOrganism, IReproducible
{
    public string Species { get; set; }

    public Plant(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Reproduce()
    {
        Console.WriteLine($"The {Species} is reproducing.");
    }
}

public class Microorganism : LivingOrganism, IReproducible
{
    public string Species { get; set; }

    public Microorganism(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Reproduce()
    {
        Console.WriteLine($"The {Species} is reproducing.");
    }
}

public interface IReproducible
{
    void Reproduce();
}

public interface IPredator
{
    void Hunt(LivingOrganism prey);
}

public class Ecosystem
{
    public List<LivingOrganism> Organisms { get; set; }

    public Ecosystem()
    {
        Organisms = new List<LivingOrganism>();
    }

    public void SimulateEcosystem()
    {
        foreach (var organism in Organisms)
        {
            if (organism is Animal animal)
            {
                // Логіка для тварин
                animal.Hunt(Organisms.Find(possiblePrey => possiblePrey != organism && possiblePrey is Plant));
                animal.Reproduce();
            }
            else if (organism is Plant plant)
            {
                // Логіка для рослин
                plant.Reproduce();
            }
            else if (organism is Microorganism microorganism)
            {
                // Логіка для мікроорганізмів
                microorganism.Reproduce();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal(100, 5, 2, "Lion");
        Animal deer = new Animal(50, 3, 1.5, "Deer");
        Plant grass = new Plant(30, 1, 0.5, "Grass");
        Microorganism bacteria = new Microorganism(10, 1, 0.01, "Bacteria");

        ecosystem.Organisms.Add(lion);
        ecosystem.Organisms.Add(deer);
        ecosystem.Organisms.Add(grass);
        ecosystem.Organisms.Add(bacteria);

        ecosystem.SimulateEcosystem();
    }
}

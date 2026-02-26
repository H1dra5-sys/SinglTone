/******************************************
*  Создал Коновалов К.М.                  *
*  Вариант: нету                          *
*  Язык программирования: C#              *
*******************************************/

using System;
using System.Collections.Generic;

namespace AnimalWorld {

  // ==================== BASE CLASS ====================
  abstract class Animal {
    protected string nickname;
    protected int age;
    protected string livingEnvironment;
    protected string foodType;

    public Animal(string nickname, int age, string livingEnvironment, string foodType) {
      this.nickname = nickname;
      this.age = age;
      this.livingEnvironment = livingEnvironment;
      this.foodType = foodType;
    }

    public virtual string GetInfo() { 
      return $"Name: {nickname}, Age: {age}, Environment: {livingEnvironment}, Food: {foodType}";
    }
  }

  // ==================== SUBCLASSES ====================
  class Mammal : Animal {
    private bool hasFur;

    public Mammal(string nickname, int age, string livingEnvironment, string foodType, bool hasFur)
        : base(nickname, age, livingEnvironment, foodType) {
      this.hasFur = hasFur;
    }

    public override string GetInfo() {
      string furStatus = hasFur ? "yes" : "no";
      return base.GetInfo() + $", Type: Mammal, Fur: {furStatus}";
    }
  }

  class Bird : Animal {
    private double wingSpan;

    public Bird(string nickname, int age, string livingEnvironment, string foodType, double wingSpan)
        : base(nickname, age, livingEnvironment, foodType) {
      this.wingSpan = wingSpan;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Bird, Wingspan: {wingSpan} m";
    }
  }

  class Fish : Animal {
    private string waterType;

    public Fish(string nickname, int age, string livingEnvironment, string foodType, string waterType)
        : base(nickname, age, livingEnvironment, foodType) {
      this.waterType = waterType;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Fish, Water: {waterType}";
    }
  }

  // ==================== SINGLETON MANAGER ====================
  class AnimalManager {
    private static AnimalManager instance;
    private List<Animal> animals = new List<Animal>();

    private AnimalManager() { }

    public static AnimalManager Instance {
      get { 
        if (instance == null)
          instance = new AnimalManager();
        return instance;
      }
    }

    public void AddAnimal(Animal animal) { 
      animals.Add(animal);
      Console.WriteLine("Animal added!");
    }

    public void ShowAllAnimals() {
      
      if (animals.Count == 0) {
        Console.WriteLine("No animals in the list.");
        return;
      }

      Console.WriteLine("\n--- ANIMAL LIST ---");

      for (int numberOfAnimals = 0; numberOfAnimals < animals.Count; numberOfAnimals++) {
        Console.WriteLine($"{numberOfAnimals + 1}. {animals[numberOfAnimals].GetInfo()}");
      }
    }
  }

  // ==================== MAIN PROGRAM ====================
  class Program {

    static void Main() { 

      AnimalManager manager = AnimalManager.Instance;

      manager.AddAnimal(new Mammal("Fluffy", 5, "forest", "carnivore", true));
      manager.AddAnimal(new Bird("Tweety", 2, "tropics", "omnivore", 0.5));
      manager.AddAnimal(new Fish("Nemo", 1, "ocean", "carnivore", "salt"));

      bool exit = false;
      while (!exit) {
        Console.WriteLine("\n=== MENU ===");
        Console.WriteLine("1. Show all animals");
        Console.WriteLine("2. Add an animal");
        Console.WriteLine("3. Exit");
        Console.Write("Choose action (1-3): ");

        string choice = Console.ReadLine();
        switch (choice) {
          case "1":
            manager.ShowAllAnimals();
            break;

          case "2":
            AddSimpleAnimal(manager);
            break;

          case "3":
            exit = true;
            Console.WriteLine("Goodbye!");
            break;

          default:
            Console.WriteLine("❌ Invalid choice! Enter 1, 2 or 3.");
            break;
        }
      }
    }

    static void AddSimpleAnimal(AnimalManager manager) {
      Console.WriteLine("\n--- ADD AN ANIMAL ---");
      Console.WriteLine("1. Add a dog (mammal)");
      Console.WriteLine("2. Add a parrot (bird)");
      Console.WriteLine("3. Add a goldfish");
      Console.Write("Choose (1-3): ");

      string animalChoice = Console.ReadLine();

      switch (animalChoice) {
        case "1":
          manager.AddAnimal(new Mammal("Buddy", 3, "house", "omnivore", true));
          break;
        case "2":
          manager.AddAnimal(new Bird("Tweety", 2, "cage", "seeds", 0.3));
          break;
        case "3":
          manager.AddAnimal(new Fish("Goldie", 1, "aquarium", "flakes", "fresh"));
          break;
        default:
          Console.WriteLine("❌ Invalid choice!");
          break;
      }
    }
  }
}
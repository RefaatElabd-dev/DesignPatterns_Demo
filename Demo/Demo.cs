﻿using Builder;
using Builder.FluentBuilderInhertanceRecursiveGenerics;
using Builder.FunctionalBuilder;
using Builder.StepWiseBuilder;
using Coding.Exercise;
using DotNetDesignPatternDemos.Creational.Factories;
using Factory.AbstractFactory;
using OSP;
using Singlton;
using SRP;
using System.Diagnostics;
using System.Net;
using static OSP.Specifications;
using static System.Console;

namespace DesignPattern_Demo
{
    public class Demo
    {
        static void Main(string[] args)
        {

            //SRP
            //var j = new Journal();
            //j.AddEntry("I cried today.");
            //j.AddEntry("I need hellllp.");
            //WriteLine(j);

            //var p = new Persistence();
            //var filename = @"D:\DesignPatterns\DesignPatterns_Demo\Demo\Downloads\Journal.txt";
            //p.SaveToFile(j, filename, true);
            //var process = new Process();

            //process.StartInfo = new ProcessStartInfo(filename)
            //{
            //    UseShellExecute = true
            //};
            //process.Start();


            //OCP
            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);

            //Product[] products = { apple, tree, house };


            //WriteLine("Green products (old):");
            //foreach (var p in ProductFilter.FilterByColor(products, Color.Green))
            //    WriteLine($" - {p.Name} is green");

            //// ^^ BEFORE

            //// ^^ after
            //BetterFilter bf = new BetterFilter();
            //ISpecification<Product> colorSpecification = new ColorSpecification(Color.Green); 
            //ISpecification<Product> sizeSpecification = new SizeSpecification(Size.Small);
            //foreach (var p in bf.Filter(products, colorSpecification))
            //{
            //    WriteLine($" - {p.Name} is green");
            //}

            //foreach (var p in bf.Filter(products, sizeSpecification))
            //{
            //    WriteLine($" - {p.Name} is small");
            //}

            //foreach (var p in bf.Filter(products, new AndSpecification(colorSpecification, sizeSpecification)))
            //{
            //    WriteLine($" - {p.Name} is small and green");
            //}

            //Builder
            //BeforeBuilder.BuildHTMlTag();

            //Builder
            //var builder = new HTMLBuilder("ul");
            //builder.AddFluentChild("li", "Hello");
            //builder.AddChild("li", "World");
            //WriteLine(builder.ToString());

            //FluentBuilderInhertance
            //var me = Person.New.Called("Refaat").WorkAsA("Software Engineer").Build();
            //Console.WriteLine(me.ToString());

            //StepWise Builder
            //var carBuilder = CarBuilder.Create()
            //    .OfType(CarType.Crossover)
            //    .withWheelSize(16)
            //    .Build();

            //Functional Builder
            //var personBuilder = new Builder.FunctionalBuilder.PersonBuilder();
            //var person = personBuilder.Called("Refaat")
            //             .WorkAsA("Developer")
            //             .Build();
            //Console.WriteLine(person);

            //Faceted Builder
            //var pb = new Builder.FasetedBuilder.PersonBuilder();
            //Builder.FasetedBuilder.Person person = pb
            //  .Lives
            //    .At("123 London Road")
            //    .In("London")
            //    .WithPostcode("SW12BC")
            //  .Works
            //    .At("Fabrikam")
            //    .AsA("Engineer")
            //    .Earning(123000);

            //WriteLine(person);

            //Factory
            //var p1 = new Point(2, 3, Point.CoordinateSystem.Cartesian);
            //var origin = Point.Origin;

            //var p2 = Point.Factory.NewCartesianPoint(1, 2);

            //AbstractFactory
            //HotDrinkMachine hotDrinkMachine = new HotDrinkMachine();
            //IHotDrink hotDrink = hotDrinkMachine.MakeADrink(HotDrinkMachine.AvailableDrinks.Tea, 100, 3, false);
            //hotDrink.Consume();

            //HotDrinkMachineOCP hotDrinkMachineOCP = new HotDrinkMachineOCP();
            //IHotDrink hotDrink2 = hotDrinkMachineOCP.MakeDrink();
            //hotDrink2.Consume();

            //test PersonFactory
            //PersonFactory personFactory = new PersonFactory();
            //Console.WriteLine(personFactory.CreatePerson("Refaat").ToString());
            //var john = new Person(new[] { "John", "Smith" }, new IClonableAddress("London Road", 123));

            //var db = SingletonDB.Instance;
            //
            //// works just fine while you're working with a real database.
            //var city = "Tokyo";
            //WriteLine($"{city} has population {db.GetPopulation(city)}");

            //per Thread Singleton
            var t1 = Task.Factory.StartNew(() =>
            {
                WriteLine($"t1: " + PerThreadSingleton.Instance.Id);
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                WriteLine($"t2: " + PerThreadSingleton.Instance.Id);
                WriteLine($"t2 again: " + PerThreadSingleton.Instance.Id);
            });
            Task.WaitAll(t1, t2);
        }
    }
}

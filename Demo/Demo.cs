using Builder;
using Builder.FluentBuilderInhertanceRecursiveGenerics;
using Builder.FunctionalBuilder;
using Builder.StepWiseBuilder;
using OSP;
using SRP;
using System.Diagnostics;
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
            var pb = new Builder.FasetedBuilder.PersonBuilder();
            Builder.FasetedBuilder.Person person = pb
              .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
              .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);

            WriteLine(person);

        }
    }
}

using Decorator;
using Decorator.DynamicDecoratorComposition;
using System.Text;

//var cb = new CodeBuilder();
//cb.AppendLine("class Foo")
//  .AppendLine("{")
//  .AppendLine("}");
//Console.WriteLine(cb);


//CodeBuilder s = "hello ";
//s += "world"; // will work even without op+ in CodeBuilder
//              // why? you figure it out!
//Console.WriteLine(s);

//Dragon dragon = new Dragon();
//dragon.Weight = 100;
//dragon.Fly();
//dragon.Crawl();

var square = new Square(2.34f);
Console.WriteLine(square.AsString());

var redSquare = new ColoredShape(square, "Red");
Console.WriteLine(redSquare.AsString());

var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
Console.WriteLine(redHalfTransparentSquare.AsString());
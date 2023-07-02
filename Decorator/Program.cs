using Decorator;
using System.Text;

//var cb = new CodeBuilder();
//cb.AppendLine("class Foo")
//  .AppendLine("{")
//  .AppendLine("}");
//Console.WriteLine(cb);


CodeBuilder s = "hello ";
s += "world"; // will work even without op+ in CodeBuilder
              // why? you figure it out!
Console.WriteLine(s);

Dragon dragon = new Dragon();
dragon.Weight = 100;
dragon.Fly();
dragon.Crawl();
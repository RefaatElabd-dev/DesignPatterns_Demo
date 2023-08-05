using Extras;
using Mixins;
//Duck Typing
using Foo foo = new Foo();

//Mixins

MyClass mc = new MyClass();

foreach (var x in mc)
{
    Console.WriteLine(x);
}


Human h = new Human("Jim");
h.SetBirthDate(new DateTime(1980, 1, 1));
Console.WriteLine("Name {0}, Age = {1}", h.Name, h.GetAge());
Human h2 = new Human("Fred");
h2.SetBirthDate(new DateTime(1960, 6, 1));
Console.WriteLine("Name {0}, Age = {1}", h2.Name, h2.GetAge());


Employee em = new Employee("Refaat");
em.SetFirstJopDate(new DateTime(2021, 5, 1));
Console.WriteLine("Name {0}, Years Of Experiance = {1}", em.Name, em.GetYearsOfExperience());

Employee em2 = new Employee("Esraa");
em2.SetFirstJopDate(new DateTime(2021, 6, 17));
Console.WriteLine("Name {0}, Years Of Experiance = {1}", em2.Name, em2.GetYearsOfExperience());


var e = new Employee("Esraa");
e.SetFirstJopDate(new DateTime(2021, 6, 17));
Console.WriteLine($"Name {e.Name}, Level = {e.GetTechLevel()}");

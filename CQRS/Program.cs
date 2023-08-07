using CQRS;

EventBroker eb = new EventBroker();

Person p = new Person(eb);

eb.Command(new ChangeAgeCommand(p, 25));

int age = eb.Query<int>(new AgeQuery(p));

foreach (var e in eb.Events)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine(age);


eb.UndoLast();

age = eb.Query<int>(new AgeQuery(p));

foreach (var e in eb.Events)
{
    Console.WriteLine(e.ToString());
}

Console.WriteLine(age);
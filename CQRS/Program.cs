using CQRS;

EventBroker eb = new EventBroker();

Person p = new Person(eb);

eb.Command(new ChangeAgeCommand(p, 25));

int age = eb.Query<int>(new AgeQuery(p));
Console.WriteLine(age);
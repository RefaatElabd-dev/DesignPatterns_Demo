namespace CQRS
{
    public class Command
    {
    }

    public class ChangeAgeCommand: Command
    {
        public Person Person { get; set; }
        public int Age { get; set; }
        public ChangeAgeCommand(Person person, int age)
        {
            this.Person = person;
            this.Age = age;
        }
    }
}
using System;

namespace Coding.Exercise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"id: {Id}, Name: {Name}";
        }
    }

    public class PersonFactory
    {
        private int count;
        public PersonFactory()
        {
            count = -1;
        }

        public Person CreatePerson(string name)
        {
            count++;
            return new Person(count, name);
        }
    }

}

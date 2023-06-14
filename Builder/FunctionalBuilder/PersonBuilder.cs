using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FunctionalBuilder
{
    //public sealed class PersonBuilder
    //{
    //    public readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();
    //    public PersonBuilder Called(string name)
    //    {
    //        Do((p) => { p.Name = name; return p; });
    //        return this;
    //    }
    //    public PersonBuilder Do(Func<Person, Person> f) => AddAction(f);
    //    private PersonBuilder AddAction(Func<Person, Person> f)
    //    {
    //        actions.Add(p => f(p));
    //        return this;
    //    }

    //    public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));
    //}



    public sealed class PersonBuilder: FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
        {
            Do((p) => { p.Name = name; return p; });
            return this;
        }
    }
}

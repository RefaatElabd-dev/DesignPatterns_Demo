namespace CQRS
{
    public class Query
    {
        public object Result;
    }

    public class AgeQuery: Query
    {
        public Person Person { get; set; }
        public AgeQuery(Person person)
        {
            this.Person = person;
        }
    }
}
namespace CQRS
{
    public class Person
    {
        public EventBroker EventBroker;

        public Person(EventBroker eventBroker)
        {
            EventBroker = eventBroker;
            EventBroker.Commands += EventBroker_Commands;
            EventBroker.Queries += EventBroker_Queries;
        }

        private void EventBroker_Queries(object? sender, Query q)
        {
            var aq = q as AgeQuery;
            if(aq != null && aq.Person == this)
            {
                q.Result = Age;
            }
        }

        private void EventBroker_Commands(object? sender, Command c)
        {
            var cac = c as ChangeAgeCommand;
            if(cac != null && cac.Person == this)
            {
                if (cac.Register)
                {
                    this.EventBroker.Events.Add(new AgeEvent(this, Age, cac.Age));
                }
                Age = cac.Age;
            }
        }

        public int Age { get; set; }
    }
}

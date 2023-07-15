using static Observable.Ex3.Person;
using System.Reactive.Linq;

namespace Observable.Ex3
{
    public class Event
    {

    }

    public class FillsIllEvent: Event
    {
        public string Address { get; set; }
    }

    public class Person : IObservable<Event>
    {
        private HashSet<Subscription> subscriptions = new HashSet<Subscription>();
        public IDisposable Subscribe(IObserver<Event> observer)
        {
            Subscription subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        private class Subscription: IDisposable
        {
            private readonly Person person;
            public readonly IObserver<Event> Observer;

            public Subscription(Person person, IObserver<Event> observer)
            {
                this.person = person;
                Observer = observer;
            }

            public void Dispose()
            {
                this.person.subscriptions.Remove(this);
            }
        }

        public void CatchACold()
        {
            foreach (var subscription in subscriptions)
            {
                subscription.Observer.OnNext(new FillsIllEvent() { Address = "123 London Road" });
            }
        }
    }

    public class Subscriper : IObserver<Event>
    {
        public Subscriper()
        {
            Person p = new Person();
            //var sub = p.Subscribe(this);

            p.OfType<FillsIllEvent>().Subscribe(args =>
            {
                Console.WriteLine($"A doctor has been called to {args.Address}");
            });

            p.CatchACold();
        }
        public void OnCompleted() { }

        public void OnError(Exception error) { }

        public void OnNext(Event value)
        {
            if (value is FillsIllEvent args)
            {
                Console.WriteLine($"A doctor has been called to {args.Address}");
            }
        }
    }
}

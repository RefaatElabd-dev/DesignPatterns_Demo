using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public class EventBroker
    {
        public List<Event> Events { get; set; }
        public event EventHandler<Command> Commands;
        public event EventHandler<Query> Queries;

        public EventBroker()
        {
            Events = new List<Event>();
        }
        public void Command(Command c)
        {
            Commands?.Invoke(this, c);
        }

        public T Query<T>(Query q)
        {
            Queries?.Invoke(this, q);
            return (T)q.Result;
        }

        public void UndoLast()
        {
            var e = Events.LastOrDefault();
            if(e != null)
            {
                var ae = e as AgeEvent;
                if(ae != null)
                {
                    Commands.Invoke(this, new ChangeAgeCommand(ae.Target, ae.OldValue) { Register = false });
                    Events.Remove(ae);
                }
            }
        }
    }
}

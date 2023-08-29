using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Participant
    {
        public int Value { get; set; }
        public readonly Mediator mediator;

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.Participants.Add(this);
        }

        public void Say(int n)
        {
            this.mediator.Broadcast(this, n);
        }
    }

    public class Mediator
    {
        public List<Participant> Participants;
        public Mediator()
        {
            this.Participants = new List<Participant>();
        }
        public void Broadcast(Participant self, int value)
        {
            foreach (Participant p in Participants)
            {
                if (!p.Equals(self))
                {
                    p.Value += value;
                }
            }
        }
    }
}

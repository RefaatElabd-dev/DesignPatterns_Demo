using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FunctionalBuilder
{
    public class FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
        where TSelf : FunctionalBuilder<TSubject, TSelf>
    {
        public readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();
  
        public TSelf Do(Func<TSubject, TSubject> f) => AddAction(f);
        private TSelf AddAction(Func<TSubject, TSubject> f)
        {
            actions.Add(p => f(p));
            return (TSelf) this;
        }

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extras
{
    // Duck Typing
    // GetEnumerator _ foreach (IEnumerable<T>)
    // Dispose - using (IDisposable)
    ref struct Foo
    {
        public void Dispose()
        {
            Console.WriteLine("Foo Disposed");
        }
    }
    

    //Mixins extend Functionality
    //At c++ can be done by multy inheritance

    public interface IScaler<T>: IEnumerable<T>
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
           yield return (T) this;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MyClass: IScaler<MyClass>
    {
        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}

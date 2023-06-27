using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public interface IDeepCopyable<T> where T : new()
    {
        void CopyTo(T target);
        T DeepCopy()
        {
            T copy = new T();
            CopyTo(copy);
            return copy;
        }
    }
}

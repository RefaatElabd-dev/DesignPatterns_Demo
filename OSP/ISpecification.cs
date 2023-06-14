using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSP
{
    public interface ISpecification<T>
    {
        public bool IsSatisfiedBy(T entity);
    }
}

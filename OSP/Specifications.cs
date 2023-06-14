using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace OSP
{
    public class Specifications
    {

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;
            public ColorSpecification(Color color)
            {
                this.color = color;
            }

            public bool IsSatisfiedBy(Product product)
            {
                return this.color == product.Color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;
            public SizeSpecification(Size size)
            {
                this.size = size;
            }

            public bool IsSatisfiedBy(Product product)
            {
                return this.size == product.Size;
            }
        }

        public class AndSpecification : ISpecification<Product>
        {
            private ISpecification<Product> spec1;
            private ISpecification<Product> spec2;
            public AndSpecification(ISpecification<Product>  spec1, ISpecification<Product> spec2)
            {
                this.spec1 = spec1 ?? throw new ArgumentNullException(paramName: nameof(spec1));
                this.spec2 = spec2 ?? throw new ArgumentNullException(paramName: nameof(spec2));
            }

            public bool IsSatisfiedBy(Product product)
            {
                return spec1.IsSatisfiedBy(product) && spec2.IsSatisfiedBy(product);
            }
        }
    }
}

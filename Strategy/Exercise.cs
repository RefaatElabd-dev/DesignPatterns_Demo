using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return (Math.Pow(b, 2) - 4 * a * c);
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        // todo (return NaN on negative discriminant!)
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = (Math.Pow(b, 2) - 4 * a * c);
            return discriminant < 0 ? double.NaN : discriminant;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            double discriminant = strategy.CalculateDiscriminant(a, b, c);
            double iPart1 = 0, realPart1 = 0, iPart2 = 0, realPart2 = 0;
            if (discriminant < 0)
            {
                realPart1 = realPart2 = -b / (2 * a);
                iPart1 = Math.Sqrt((-1 * discriminant)) / (2 * a);
                iPart2 = -1 * (Math.Sqrt((-1 * discriminant)) / (2 * a));
            }
            else if (discriminant >= 0)
            {
                iPart1 = iPart2 = 0;
                realPart1 = (-b / (2 * a)) + (Math.Sqrt(discriminant) / (2 * a));
                realPart2 = (-b / (2 * a)) - Math.Sqrt(discriminant) / (2 * a);
            }
            else
            {
                Console.WriteLine(discriminant);
                iPart1 = iPart2 = realPart1 = realPart2 = discriminant;
            }

            var s1 = new Complex(realPart1, iPart1);
            var s2 = new Complex(realPart2, iPart2);

            return new Tuple<Complex, Complex>(s1, s2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IBird
    {
        public int Weight { get; set; }
        void Fly();
    }
    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"on sky with weight {Weight}");
        }
    }

    public interface ILizard
    {
        public int Weight { get; set; }
        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            Console.WriteLine($"on the dirt with weight {Weight}");
        }
    }

    public class Dragon: IBird, ILizard // no multiple inheritance
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        int weight;
        public int Weight { 
            get => weight;
            set {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            } 
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}

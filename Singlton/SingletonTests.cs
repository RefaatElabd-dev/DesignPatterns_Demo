using Autofac;
using NUnit.Framework;

namespace Singlton
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingltonTest()
        {
            var db = SingletonDB.Instance;
            var db2 = SingletonDB.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDB.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            // testing on a live database
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.TotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }

        [Test]
        public void DependantTotalPopulationTest()
        {
            var db = new DummyDB();
            var rf = new ConfigurableRecordFinder(db);
            Assert.That(
              rf.GetTotalPopulation(new[] { "alpha", "gamma" }),
              Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDB>().As<IDB>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();
            using(var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
                var names = new[] { "Seoul", "Mexico City" };
                int tp = rf.GetTotalPopulation(names);
                Assert.That(tp, Is.EqualTo(17500000 + 17400000));
            }
        }
    }
}

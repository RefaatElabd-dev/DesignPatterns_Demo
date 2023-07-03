// See https://aka.ms/new-console-template for more information
using Proxy;

ICar car = new CarProxy(new Driver(12)); // 22
car.Drive();

// SoACompositeProxy

var creatures = new Creature[100];
foreach (var c in creatures)
{
    c.X++; // not memory-efficient
}

var creatures2 = new Creatures(100);
foreach (Creatures.CreatureProxy c in creatures2)
{
    c.X++;
}
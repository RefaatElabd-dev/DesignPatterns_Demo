// See https://aka.ms/new-console-template for more information
using ChanOfResponsibility;


//var goblin = new Creature("Goblin", 2, 2);
//Console.WriteLine(goblin);

//var root = new CreatureModifier(goblin);

//root.Add(new NoBonusesModifier(goblin));

//Console.WriteLine("Let's double goblin's attack...");
//root.Add(new DoubleAttackModifier(goblin));

//Console.WriteLine("Let's increase goblin's defense");
//root.Add(new IncreaseDefenseModifier(goblin));

//// eventually...
//root.Handle();
//Console.WriteLine(goblin);


var game = new Game();
var goblin = new Creature2(game, "Strong Goblin", 3, 3);
Console.WriteLine(goblin);

using (new DoubleAttackModifier2(game, goblin))
{
    Console.WriteLine(goblin);
    using (new IncreaseDefenseModifier2(game, goblin))
    {
        Console.WriteLine(goblin);
    }
}

Console.WriteLine(goblin);


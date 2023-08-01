using State;
using Action = State.Action;

var state = State2.OffHook;
while (true)
{
    Console.WriteLine($"The phone is currently {state}");
    Console.WriteLine("Select a trigger:");

    // foreach to for
    for (var i = 0; i < Dic.rules[state].Count; i++)
    {
        var (t, _) = Dic.rules[state][i];
        Console.WriteLine($"{i}. {t}");
    }


    int input = int.Parse(Console.ReadLine());

    var (_, s) = Dic.rules[state][input];
    state = s;
}


//Chest Example
Chest chest = Chest.Locked;
Console.WriteLine($"Chest is {chest}");

// unlock with key
chest = SwitchExpressions.Manipulate(chest, Action.Open, true);
Console.WriteLine($"Chest is now {chest}");

// close it!
chest = SwitchExpressions.Manipulate(chest, Action.Close, false);
Console.WriteLine($"Chest is now {chest}");

// close it again!
chest = SwitchExpressions.Manipulate(chest, Action.Close, false);
Console.WriteLine($"Chest is now {chest}");
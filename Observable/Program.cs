using Observable.Ex1;
using Observable.Ex2_WeakEvent;
using Observable.Ex3;
using System.ComponentModel;

//Person p = new Person();

//p.FallsIll += Person.CallDoctor;
//p.CatchCold();

//Button button = new Button();
//Window window = new Window(button);
//var windowRef = new WeakReference(window);

//button.Fire();

//Console.WriteLine("Setting Window To Null");
//window = null;

//FireGC();
//Console.WriteLine($"Is window alive after GC? {windowRef.IsAlive}");


//static void FireGC()
//{
//    Console.WriteLine("Starting GC");
//    GC.Collect();
//    GC.WaitForPendingFinalizers();
//    GC.Collect();
//    Console.WriteLine("GC is done!");
//}

new Subscriper();

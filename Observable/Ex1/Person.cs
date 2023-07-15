namespace Observable.Ex1
{
    public class FallsIllEventArgs
    {
        public string Address;
    }
    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchCold()
        {
            FallsIll?.Invoke(
                this,
                new FallsIllEventArgs { Address = "123 London Road" });
        }

        public static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }
    }
}

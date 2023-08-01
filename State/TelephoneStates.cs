namespace State
{
    public enum State2
    {
        OffHook,
        Connecting,
        Connected,
        OnHold
    }

    public enum Trigger
    {
        CallDialed,
        HungUp,
        CallConnected,
        PlacedOnHold,
        TakenOffHold,
        LeftMessage
    }

    public class Dic { 
        public static Dictionary<State2, List<(Trigger, State2)>> rules
          = new Dictionary<State2, List<(Trigger, State2)>>
          {
              [State2.OffHook] = new List<(Trigger, State2)>
            {
          (Trigger.CallDialed, State2.Connecting)
            },
              [State2.Connecting] = new List<(Trigger, State2)>
            {
          (Trigger.HungUp, State2.OffHook),
          (Trigger.CallConnected, State2.Connected)
            },
              [State2.Connected] = new List<(Trigger, State2)>
            {
          (Trigger.LeftMessage, State2.OffHook),
          (Trigger.HungUp, State2.OffHook),
          (Trigger.PlacedOnHold, State2.OnHold)
            },
              [State2.OnHold] = new List<(Trigger, State2)>
            {
          (Trigger.TakenOffHold, State2.Connected),
          (Trigger.HungUp, State2.OffHook)
            }
          };
    }
}

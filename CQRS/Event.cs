namespace CQRS
{
    public class Event
    {
    }

    public class AgeEvent : Event
    {
        public Person Target;
        public int OldValue;
        public int NewValue;

        public AgeEvent(Person target, int oldValue, int newValue)
        {
            Target = target;
            OldValue = oldValue;
            NewValue = newValue;
        }

        public override string ToString()
        {
            return $"Age Old Value: {OldValue}, and the New Value is: {NewValue}";
        }
    }
}
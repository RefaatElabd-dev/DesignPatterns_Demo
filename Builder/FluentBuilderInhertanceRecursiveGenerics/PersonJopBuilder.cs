namespace Builder.FluentBuilderInhertanceRecursiveGenerics
{
    public class PersonJopBuilder<SELF>
        : PersonInfoBuilder<PersonJopBuilder<SELF>>
        where SELF : PersonJopBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            person.Position = position;
            return (SELF) this;
        }
    }
}

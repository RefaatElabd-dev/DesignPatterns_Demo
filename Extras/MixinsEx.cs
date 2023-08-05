using System.Runtime.CompilerServices;
using static System.Console;

namespace Mixins
{
    public interface MWorkExperienceProvider // use 'M' prefix to indicate mixin interface
    {
        // nothing needed in here, it's just a 'marker' interface
    }

    public static class WorkExperienceProvider // implements the mixin using extensions methods
    {
        static ConditionalWeakTable<MWorkExperienceProvider, Fields> table;
        static WorkExperienceProvider()
        {
            table = new ConditionalWeakTable<MWorkExperienceProvider, Fields>();
        }
        private sealed class Fields // mixin's fields held in private nested class
        {
            internal DateTime FirstCareerJobDate = DateTime.UtcNow;
        }
        public static int GetYearsOfExperience(this MWorkExperienceProvider provider)
        {
            DateTime now = DateTime.UtcNow;
            DateTime born = table.GetOrCreateValue(provider).FirstCareerJobDate;
            TimeSpan experience = now - born;
            int yearsOfExperience = (int)(experience.TotalDays / 365);
            return yearsOfExperience;
        }
        public static void SetFirstJopDate(this MWorkExperienceProvider provider, DateTime firstCareerJobDate)
        {
            table.GetOrCreateValue(provider).FirstCareerJobDate = firstCareerJobDate;
        }
        public static string GetTechLevel(this MWorkExperienceProvider provider)
        {
            var yearsOfExperience = GetYearsOfExperience(provider);

            switch (yearsOfExperience)
            {
                case var exp when exp > 0 && exp <= 1: return "Fresh";
                case var exp when exp > 1 && exp <= 3: return "Junior";
                case var exp when exp > 3 && exp <= 5: return "Mid";
                case var exp when exp > 5 && exp <= 7: return "Senior";
                case var exp when exp > 7 && exp <= 10: return "Leader";
                default:  return "Unknown";
            }
        }
    }

    public abstract class Person
    {
        // contents unimportant
    }

    public class Employee : Person, MWorkExperienceProvider
    {
        public string Name;
        public Employee(string name)
        {
            Name = name;
        }
        // nothing needed in here to implement MWorkExperienceProvider
    }

    //public class Program
    //{
    //    static void Main()
    //    {
    //        Employee e1 = new Employee("Refaat");
    //        e1.SetFirstJopDate(new DateTime(2021, 5, 1));
    //        WriteLine($"Name {e1.Name}, Years Of Experiance = {e1.GetYearsOfExperience()}, Level = {e1.GetTechLevel()}");

    //        Employee e2 = new Employee("Esraa");
    //        e2.SetFirstJopDate(new DateTime(2021, 6, 17));
    //        WriteLine($"Name {e2.Name}, Years Of Experiance = {e2.GetYearsOfExperience()}, Level = {e2.GetTechLevel()}");
    //    }
    //}







    public interface MAgeProvider // use 'M' prefix to indicate mixin interface
    {
        // nothing needed in here, it's just a 'marker' interface
    }
    public static class AgeProvider // implements the mixin using extensions methods
    {
        static ConditionalWeakTable<MAgeProvider, Fields> table;
        static AgeProvider()
        {
            table = new ConditionalWeakTable<MAgeProvider, Fields>();
        }
        private sealed class Fields // mixin's fields held in private nested class
        {
            internal DateTime BirthDate = DateTime.UtcNow;
        }
        public static int GetAge(this MAgeProvider map)
        {
            DateTime dtNow = DateTime.UtcNow;
            DateTime dtBorn = table.GetOrCreateValue(map).BirthDate;
            int age = ((dtNow.Year - dtBorn.Year) * 372
                       + (dtNow.Month - dtBorn.Month) * 31
                       + (dtNow.Day - dtBorn.Day)) / 372;
            return age;
        }
        public static void SetBirthDate(this MAgeProvider map, DateTime birthDate)
        {
            table.GetOrCreateValue(map).BirthDate = birthDate;
        }
    }

    public abstract class Animal
    {
        // contents unimportant
    }

    public class Human : Animal, MAgeProvider
    {
        public string Name;
        public Human(string name)
        {
            Name = name;
        }
        // nothing needed in here to implement MAgeProvider
    }
}

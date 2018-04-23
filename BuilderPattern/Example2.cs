namespace Example2
{
    // recursive generics to allow inherited builders to chain requests
    public class Person
    {
        public string Name;

        public string Position;


        public class Builder : PersonJobBuilder<Builder>
        {
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    // class Foo : Bar<Foo>
    public class PersonInfoBuilder<SELF>
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    //new requirement, following Open-Close principle, we inherit and add extra functionality instead
    //of changing current existing one
    public class PersonJobBuilder<SELF>
        : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }


    class Example2
    {
        //static void Main(string[] args)
        //{
        //    var me = Person.New
        //        .Called("Alex")
        //        .WorksAsA("SoftwareDev")
        //        .Build();

        //    Console.WriteLine(me);
        //}
    }
}

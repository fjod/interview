using System;

namespace AkinshinProblemBooks
{
    class Foo
    {
        protected class Quux
        {
            public Quux()
            {
                Console.WriteLine("Foo.Quux()");
            }
        }
    }
    class Bar : Foo
    {
        new class Quux //it's private, so when parent instantiated, this wont be overridder
        {
            public Quux()
            {
                Console.WriteLine("Bar.Quux()");
            }
        }
    }
    class Baz : Bar
    {
        public Baz()
        {
            new Quux();
        }
    }
    
    //Классы Foo<int> и Foo<double> — это два разных класса, у каждого из них собственное статитческое поле Bar.
    class Foo<T>
    {
        public static int Bar;
    }
    
    
    public struct Foo2
    {
        public int Value;
        public void Change(int newValue)
        {
            Value = newValue;
        }
    }
    public class Bar2
    {
        //При обращении к свойству bar.Foo вызовется метод bar.get_Foo(), который вернёт нам копию структуры,
        //для которой мы выполним метод Change
        public Foo2 Foo { get; set; }
    }
    
    struct Foo3
    {   
        int value;
        public override string ToString()
        { 
            if (value == 2)
                return "Baz";
            return (value++ == 0) ? "Foo" : "Bar";
        }
    }
}
using System;

namespace AkinshinProblemBooks
{
    //https://andreyakinshin.gitbook.io/problembookdotnet/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // AugmentedAssignment t = new AugmentedAssignment();
            // t.Main();
            //
            // Rounding2 t = new Rounding2();
            // t.Work();
            //new Baz();
            //Foo<int>.Bar++;
            //Console.WriteLine(Foo<double>.Bar);
            
            // var bar = new Bar2 { Foo = new Foo2() };
            // bar.Foo.Change(5);
            // Console.WriteLine(bar.Foo.Value);
            
            var foo = new Foo3();
            Console.WriteLine(foo); //boxing, so struct is copied, so value is not changed
            Console.WriteLine(foo);
            object bar = foo;
            object qux = foo;
            object baz = bar;
            Console.WriteLine(baz);
            Console.WriteLine(bar);
            Console.WriteLine(baz);
            Console.WriteLine(qux);
        }
    }
}
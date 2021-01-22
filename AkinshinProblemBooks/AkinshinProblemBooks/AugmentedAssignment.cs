using System;

namespace AkinshinProblemBooks
{
    public class AugmentedAssignment
    {
        int _a = 0;
        int Foo()
        {
            _a = _a + 42;
            return 1;
        }
        public void Main()
        {
            _a += Foo();
            
            // a = a + Foo();
            // Сначала оценится левый операнд a, равный нулю.
            // Затем оценится правый операнд, который вернёт 1.
            // В итоге в a запишется значение 1, не смотря на то,
            // что внутри метода Foo произошло переприсвоение поля a.
            
            Console.WriteLine(_a);
        }
    }
}
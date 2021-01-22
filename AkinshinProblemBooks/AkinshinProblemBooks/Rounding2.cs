using System;

namespace AkinshinProblemBooks
{
    public class Rounding2
    {
        
            // При целочисленном делении результат всегда округляется по направлению к нулю. 
            //     При взятии остатка от деления должно выполняться следующее правило: 
            // x mod y = x - (x / y) * y.
        public void Work()
        {
            Action<int,int> print = (a, b) =>
                Console.WriteLine("{0,2} = {1,2} * {2,3}   + {3,3}  ",
                    a, b, a/b, a%b);
            Console.WriteLine(" a =  b * (a/b) + (a%b)");
            print(7, 3);  //7,3,2,2
             print(7, -3);
             print(-7, 3);
             print(-7, -3);
        }
    }
}
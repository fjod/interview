using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_12
{
    public class Modify
    {
        private int value;
       
        /// <summary>
        /// need sync
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        async Task ModifyValue(string s)
        {
            
            Console.WriteLine(s + " thread id " + Thread.CurrentThread.ManagedThreadId);
            int test = value;
            Console.WriteLine("test" +test);
            await Task.Delay(TimeSpan.FromMilliseconds(555));
            value = test + 1;
            Console.WriteLine("val" + value);

            Console.WriteLine(s + " thread id " + Thread.CurrentThread.ManagedThreadId);
        }
        
        /// <summary>
        /// does not need sync
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        async Task ModifyValue2(string s)
        {
            
            Console.WriteLine(s + " thread id " + Thread.CurrentThread.ManagedThreadId);
          
            Console.WriteLine("value" +value);
            await Task.Delay(TimeSpan.FromMilliseconds(555));
            value = value + 1;
            Console.WriteLine("val" + value);

            Console.WriteLine(s + " thread id " + Thread.CurrentThread.ManagedThreadId);
        }

        public async Task<int> Check()
        {
            Task t1 = ModifyValue("t1");
            Task t2 = ModifyValue("t2");
            Task t3 = ModifyValue("t3");

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("code done");
            return value;
        }
        
        public async Task<int> Check2()
        {
            Task t1 = ModifyValue2("t1");
            Task t2 = ModifyValue2("t2");
            Task t3 = ModifyValue2("t3");

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("code done");
            return value;
        }
    }
}
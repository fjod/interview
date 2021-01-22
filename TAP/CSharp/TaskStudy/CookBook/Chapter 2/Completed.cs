using System;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2
{
    /// <summary>
    /// 2.3 use competed task when in need
    /// </summary>
    public  abstract class CompletedTask
    {
        public abstract Task<long> CalcSomething();
        protected static readonly Task<long> FortyTwoTask = Task.FromResult(42L);
        public static CompletedTask Get()
        {
            Random r = new Random();
            if (r.Next(0, 10) > 5) return new CompletedOne();
            return new CompletedTwo();
        }
    }

    class CompletedOne : CompletedTask
    {
        public override Task<long> CalcSomething()
        {
            Console.WriteLine("Got to wait long time");
            return CustomAwaiter.TryTCSAwaiter();
        }
    }

    class CompletedTwo : CompletedTask
    {
        public override Task<long> CalcSomething()
        {
            Console.WriteLine("FromResult");
            //return Task.FromResult(42L);
            return FortyTwoTask;
        }
    }
    
    class CompletedThree : CompletedTask
    {
        public override Task<long> CalcSomething()
        {
            return Task.FromException<long>(new NotImplementedException("something something 42"));
        }
    }
}
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace TaskStudy.CookBook.Chapter_2.Value
{
    /// <summary>
    /// 2.10 When sync result comes more often then async; but it needed to be benchmarked
    /// </summary>
    public  abstract class CompletedValueTask
    {
        private bool CanBehaveSync;
        public ValueTask<int> Sample()
        {
            if (CanBehaveSync) return new ValueTask<int>(15);
            return new ValueTask<int>(SlowMethodAsync());
        }

        private Task<int> SlowMethodAsync()
        {
            Console.WriteLine("Sleep...");
            Task.Delay(500);
            return Task.FromResult(1);
        }

        public abstract ValueTask<long> CalcSomething();
        protected static readonly ValueTask<long> FortyTwoTask = ValueTask.FromResult(42L);
        public static CompletedValueTask Get()
        {
            Random r = new Random();
            var val = r.Next(0, 10);
            if ( val < 4) return new CompletedOne();
            if ( val > 7) return new CompletedTwo();
            
            return new CompletedThree();
        }
    }

    public class CompletedOne : CompletedValueTask
    {
        public override async ValueTask<long> CalcSomething()
        {
            Console.WriteLine("Got to wait long time");
            var   ret = await CustomAwaiter.TryTCSAwaiter();
            return await ValueTask.FromResult(ret);
        }
    }

    class CompletedTwo : CompletedValueTask
    {
        public override ValueTask<long> CalcSomething()
        {
            Console.WriteLine("FromResult");
            //return Task.FromResult(42L);
            return FortyTwoTask;
        }
    }
    
    class CompletedThree : CompletedValueTask
    {
        public override ValueTask<long> CalcSomething()
        {
            return ValueTask.FromException<long>(new NotImplementedException("something something 42"));
        }
    }
}
using System;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2.Value
{
    /// <summary>
    /// https://devblogs.microsoft.com/dotnet/understanding-the-whys-whats-and-whens-of-valuetask/
    /// </summary>
    public class  ValueTaskConsumerImp : ValueTaskConsumer<CompletedOne>
    {
        public async Task Test()
        {
            await Consume2(new CompletedOne());
            await Consume2(new CompletedOne());
            
            await Consume3(new CompletedOne());
            await Consume3(new CompletedOne());
        }
    }

    public class ValueTaskConsumer<T> where T:CompletedValueTask
    {
        protected async Task<long> Consume(T input)
        {
            long ret = await input.Sample();
            return await Task.FromResult(ret);
        }
        
        protected async Task<long> Consume2(T input)
        {
            var method =  input.Sample();
            var ret = await method;  //value task may be awaited only once
            Console.WriteLine(ret);
            return await Task.FromResult(ret);
        }
        
        protected async Task<long> Consume3(T input)
        {
            var method =  input.Sample().AsTask();
            var ret = await method;
            Console.WriteLine(ret);
            var ret2 = await method;
            Console.WriteLine(ret2);
            var ret3 = await method;
            Console.WriteLine(ret3);
            return await Task.FromResult(ret);
        }
    }
}

// The following operations should never be performed on a ValueTask / ValueTask<TResult>:
//
// Awaiting a ValueTask / ValueTask<TResult> multiple times.
// The underlying object may have been recycled already and be in use by another operation.
// In contrast, a Task / Task<TResult> will never transition from a complete to incomplete state,
// so you can await it as many times as you need to, and will always get the same answer every time.

// Awaiting a ValueTask / ValueTask<TResult> concurrently.
// The underlying object expects to work with only a single callback from a single consumer at a time,
// and attempting to await it concurrently could easily introduce race conditions and subtle program
// errors. It’s also just a more specific case of the above bad operation:
// “awaiting a ValueTask / ValueTask<TResult> multiple times.” In contrast,
// Task / Task<TResult> do support any number of concurrent awaits.
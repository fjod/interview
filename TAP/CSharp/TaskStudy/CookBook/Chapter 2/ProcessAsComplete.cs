using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2
{
    /// <summary>
    /// 2.6 - different ways to wait for several tasks with different results
    /// </summary>
    public static  class ProcessAsComplete
    {
        //also there is AsyncEx lib with OrderByCompletion method
        //it returns array of tasks which will complete in order
        public static async Task<long> Calc()
        {
            
            List<Task<long>> tasks = new List<Task<long>>();
            foreach (var unused in Enumerable.Range(0,5))
            {
                tasks.Add(CustomAwaiter.TryAwaitCustomType(CancellationToken.None));
            }

            long acc = 0L;
            foreach (var t in tasks)
            {
                //wait for tasks in parallel, but we dont care which finishes first
                //because we process results sequentially
                var ret = await t;
                acc += ret;
            }

            // var test = tasks.Select(async tq =>
            // {
            //     var ret = await tq;
            //     acc += ret;
            // }).ToArray();
            // await Task.WhenAll(test);


            async Task<int> DelayAndReturn(int val)
            {
                await Task.Delay(val);
                return val;
            }
            var tasks1 = new[] {DelayAndReturn(200), DelayAndReturn(400), DelayAndReturn(100)};
            var proc = tasks1.Select(async t =>
            {
                var r = await t;
                Console.WriteLine(r);
            }).ToArray(); //start all tasks 
            await Task.WhenAll(proc); //and wait for them to finish
            //100-200-400 because all tasks work in parallel

            //wait one task after another  
            var tasks2 = new[] {DelayAndReturn(200), DelayAndReturn(400), DelayAndReturn(100)};
            foreach (var task in tasks2)
            {
                var r = await task;
                Console.WriteLine(r);
            }
            //200-400-100 because tasks are started one after another
            return acc;
        }
    }
}
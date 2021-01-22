using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2
{
    /// <summary>
    /// Use Task.WhenAll to complete several tasks in parallel (2.4)
    /// </summary>
    public static class SetOfTaskToComplete
    {
        public static async Task<long> BigSum()
        {
            List<Task<long>> tasks = new List<Task<long>>();
            foreach (var unused in Enumerable.Range(0,5))
            {
                tasks.Add(CompletedTask.Get().CalcSomething());
            }

            try
            {
                var ret = await Task.WhenAll(tasks);
                return ret.Sum();
            }
            catch (Exception e)
            {
                //If any task throws, WhenAll faults with the Exception here 
                //There is no need to check exceptions from other tasks; first is enough
                Console.WriteLine(e);
                throw;
            }
          
        }
        
        //fancy select 
        public static async Task<long> BigSumIenumerable(IEnumerable<int> delays)
        {
            var tasks = delays.Select(i =>
            {
                Task.Delay(i);
                return CompletedTask.Get().CalcSomething();
            });

            Task<long>[] calculations = tasks.ToArray(); //start work
            long[] ret =  await Task.WhenAll(calculations); //async wait for results
            return ret.Sum();
        }
    }
}
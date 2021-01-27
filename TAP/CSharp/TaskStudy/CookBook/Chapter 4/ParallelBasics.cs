using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_4
{
    public class ParallelBasics
    {
        public long CalcAsParallel(IEnumerable<BigClass> jobs)
        {
            object mutex = new object();
            long counter = 0;
            Parallel.ForEach(jobs,  job =>
            {
                job.PerformCalc();
                
                lock (mutex)
                {
                    counter += job.Result;
                }
            });
            return counter;
        } 
        
        public long CalcAsParallel2(IEnumerable<BigClass> jobs)
        {
            return jobs.AsParallel().Select(j =>
            {
                j.PerformCalc();
                return j.Result;
            }).Sum();
        } 
        
        public long CalcAsParallel3(IEnumerable<BigClass> jobs)
        {
            //does not work as parallel
            return jobs.AsParallel().Aggregate(0L, (acc, item) =>
            {
                item.PerformCalc();
                return acc +item.Result;
            });
        } 
    }

    public class BigClass
    {
        public long Result { get; set; }

        public void PerformCalc()
        {
            Result = LongRunningJob.CalcSum();
        }
    }
}
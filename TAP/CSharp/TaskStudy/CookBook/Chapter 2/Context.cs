using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskStudy.CookBook.Chapter_2
{
    /// <summary>
    /// ConfigureAwait(continueOnCapturedContext: false) is used
    /// to avoid forcing the callback to be invoked on the original context or scheduler.
    /// </summary>
    public static class Context
    {
        public static async Task<long> SameContext()
        {
            PrintThread("before calling, without configure");
            var ret = await CustomAwaiter.TryTCSAwaiter();
            PrintThread("after calling, without configure");
            return ret;
        }

        public static async Task<long> SwitchOnContext()
        {
            PrintThread("before calling, with configure");
            var ret = await CustomAwaiter.TryTCSAwaiter().ConfigureAwait(false);
            PrintThread("after calling, with configure");
            return ret;
        }

        public static void PrintThread(string text)
        {
            Console.WriteLine(text + " current Thread id = " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}

//https://devblogs.microsoft.com/dotnet/configureawait-faq/
// I’ve heard ConfigureAwait(false) is no longer necessary in .NET Core. True?
//     False. It’s needed when running on .NET Core for exactly the same reasons
// it’s needed when running on .NET Framework. Nothing’s changed in that regard.
//
//     What has changed, however, is whether certain environments publish their
// own SynchronizationContext. In particular, whereas the classic ASP.NET on .NET Framework
// has its own SynchronizationContext, in contrast ASP.NET Core does not.
// That means that code running in an ASP.NET Core app by default won’t see a custom
// SynchronizationContext, which lessens the need for ConfigureAwait(false) running in such an environment.
//
//     It doesn’t mean, however, that there will never be a custom SynchronizationContext or
// TaskScheduler present. If some user code (or other library code your app is using) sets
// a custom context and calls your code, or invokes your code in a Task scheduled to a custom
// TaskScheduler, then even in ASP.NET Core your awaits may see a non-default context or scheduler
// that would lead you to want to use ConfigureAwait(false). Of course, in such situations,
// if you avoid synchronously blocking (which you should avoid doing in web apps regardless)
// and if you don’t mind the small performance overheads in such limited occurrences,
// you can probably get away without using ConfigureAwait(false).

// That awaiter is responsible for hooking up the callback (often referred to as the “continuation”)
// that will call back into the state machine when the awaited object completes,
// and it does so using whatever context/scheduler it captured at the time the callback was registered.
// While not exactly the code used (there are additional optimizations and tweaks employed),
// it’s something like this:
//
// object scheduler = SynchronizationContext.Current;
// if (scheduler is null && TaskScheduler.Current != TaskScheduler.Default)
// {
//     scheduler = TaskScheduler.Current;
// }
// In other words, it first checks whether there’s a SynchronizationContext set, and if there isn’t,
// whether there’s a non-default TaskScheduler in play.
// If it finds one, when the callback is ready to be invoked, it’ll use the captured scheduler;
// otherwise, it’ll generally just execute the callback on as part of the operation completing
// the awaited task.
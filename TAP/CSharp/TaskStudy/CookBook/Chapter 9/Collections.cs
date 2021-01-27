using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IO.Compression;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskStudy.CookBook.Chapter_9
{
    /// <summary>
    /// 9.1 Immutable collections
    /// </summary>
    public class Collections
    {
        /// <summary>
        /// references are not thread-safe
        /// </summary>
        private ImmutableStack<int> stack =  ImmutableStack<int>.Empty;

        public void TestStack()
        {
            stack = stack.Push(1); //overwrite field!
            stack = stack.Push(2); //overwrite field!
            Console.WriteLine(stack.Peek()); //2
            var biggerStack = stack.Push(3);
            Console.WriteLine(biggerStack.Peek()); //3
            Console.WriteLine(stack.Peek()); //2; now we have 2 stacks; but memory is shared
        }

        public async Task MoreSamples()
        {
            BlockingCollection<int> _stack = new BlockingCollection<int>(new ConcurrentStack<int>());
            BlockingCollection<int> _bag = new BlockingCollection<int>(new ConcurrentBag<int>());
            BlockingCollection<int> _queue = new BlockingCollection<int>(new ConcurrentQueue<int>());
            _stack.Add(7); //producer side
            _stack.CompleteAdding(); //cant add more now


            Channel<int> test = Channel.CreateUnbounded<int>();
                //producer code
                var writer = test.Writer;
                await writer.WriteAsync(50);
                await writer.WriteAsync(60);
                writer.Complete();

                var reader = test.Reader; //consumer
                await foreach (var val in reader.ReadAllAsync())
                {
                    Console.WriteLine(val);
                }

                
                var test2 = new BufferBlock<int>();//producer
                await test2.SendAsync(5);
                await test2.SendAsync(51);
                test2.Complete();

                while (await test2.OutputAvailableAsync())
                {
                    Console.WriteLine(await test2.ReceiveAsync());
                }
        }
    }
}
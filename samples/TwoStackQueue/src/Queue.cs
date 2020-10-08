using System.Collections.Generic;
using System.Linq;

namespace TwoStackQueue
{
    public class Queue<TItem> : IQueue<TItem>
    {
        // Stacks are LIFO, for the queue we want FIFO
        private readonly Stack<TItem> _in;
        private readonly Stack<TItem> _out;

        public Queue()
        {
            _in = new Stack<TItem>();
            _out = new Stack<TItem>();
        }

        public virtual void Enqueue(TItem item)
        {
            _in.Push(item);
        }

        public virtual TItem Dequeue()
        {
            if (!_out.Any())
            {
                while (_in.Count > 0)
                {
                    _out.Push(_in.Pop());
                }
            }

            return _out.TryPop(out var result) 
                ? result 
                : default(TItem);
        }
    }
}
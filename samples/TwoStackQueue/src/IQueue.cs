using System.Collections;

namespace TwoStackQueue
{
    public interface IQueue<TItem>
    {
        void Enqueue(TItem item);
        TItem Dequeue();
    }
}
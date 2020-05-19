using System;
using DataStructures.Heap;

namespace DataStructures.Queues
{
    /// <summary>
    /// 优先级队列
    /// </summary>
    public class PriorityQueue<E>
    {
        private BinaryHeap<E> heap;

        public PriorityQueue(Comparison<E> comparison)
        {
            heap = new BinaryHeap<E>(comparison);
        }

        public PriorityQueue():this(null)
        {
            
        }

        public int GetSize() => heap.Size;

        public bool IsEmpty()
        {
            return heap.IsEmpty();
        }

        public void Clear()
        {
            heap.Clear();
        }
        
        public void EnQueue(E element)
        {
            heap.AddElement(element);
        }

        public E DeQueue()
        {
            return heap.RemoveValue();
        }

        public E Peek()
        {
            return heap.GetValue();
        }
    }
}
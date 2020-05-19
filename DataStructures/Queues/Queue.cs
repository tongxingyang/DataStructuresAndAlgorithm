using System;
namespace DataStructures.Queues
{
    public class Queue<E>
    {
        private Arrays.Array<E> elements;

        public Queue(int capacity)
        {
            elements = new Arrays.Array<E>(capacity);
        }

        public Queue()
        {
            elements = new Arrays.Array<E>();
        }

        public int GetSize()
        {
            return elements.GetSize();
        }

        public bool IsEmpty()
        {
            return elements.IsEmpty();
        }

        public int GetCapacity()
        {
            return elements.GetCapacity();
        }

        public void EnQueue(E element)
        {
            elements.AddLast(element);
        }

        public E DeQueue()
        {
            return elements.RemoveFirst();
        }

        public E Peek()
        {
            return elements.GetFirst();
        }
    }
}

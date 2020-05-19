using System;
namespace DataStructures.Stacks
{
    public class Stack<E>
    {
        private Arrays.Array<E> elements;

        public Stack(int capacity)
        {
            elements = new Arrays.Array<E>(capacity);
        }

        public Stack()
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

        public void Push(E element)
        {
            elements.AddLast(element);
        }

        public E Pop()
        {
            return elements.RemoveLast();
        }

        public E Peek()
        {
            return elements.GetLast();
        }
    }
}

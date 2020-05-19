using System;
namespace DataStructures.Queues
{
    public class LoopQueue<E>
    {
        public static int DEFAULT_CAPACITY = 10;
        private E[] elements;
        private int front, tail;
        private int size;

        public LoopQueue(int capacity)
        {
            elements = new E[capacity + 1];//有一个位置是浪费的
            front = tail = size = 0;
        }

        public LoopQueue():this(10)
        {
            
        }

        public int GetCapacity()
        {
            return elements.Length - 1;
        }

        public bool IsEmpty()
        {
            return front == tail;
        }

        public int GetSize()
        {
            return size;
        }

        public E Peek()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Queue is empty.");
            return elements[front];
        }

        public void EnQueue(E element)
        {
            if((tail + 1) % elements.Length == front)
            {
                resize(this.GetCapacity() + (this.GetCapacity() >> 1));
            }

            elements[tail] = element;
            tail = (tail + 1) % elements.Length;
            size++;
        }

        public E DeQueue()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Queue is empty.");
            E ret = elements[front];
            elements[front] = default;
            front = (front + 1) % elements.Length;
            size--;

            int newCapacity = this.GetCapacity() >> 1;
            if (size <= newCapacity && GetCapacity() > DEFAULT_CAPACITY)
            {
                resize(newCapacity);
            }

            return ret;
        }

        private void resize(int newCapacity)
        {
            E[] newElements = new E[newCapacity];
            for(int i = 0; i< size; i++)
            {
                newElements[i] = elements[(front + i) % elements.Length];
            }
            elements = newElements;
            front = 0;
            tail = size;
        }
    }
}

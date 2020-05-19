using System;
namespace DataStructures.LinkedList
{
    public class LinkedList<E>
    {
        private class Node
        {
            public E element;
            public Node next;
            public Node(E element, Node next)
            {
                this.element = element;
                this.next = next;
            }

            public Node(E element) : this(element, null)
            {

            }

            public Node() : this(default, null)
            {

            }
        }

        private Node dummyHead;
        private int size;

        public LinkedList()
        {
            dummyHead = new Node();
            size = 0;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Add(int index, E element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Add failed. Illegal index.");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }

            prev.next = new Node(element, prev.next);
            size++;
        }

        public void AddFirst(E element)
        {
            Add(0, element);
        }

        public void AddLast(E element)
        {
            Add(size, element);
        }

        public E Get(int index)
        {
            if(index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Get failed. Illegal index.");
            }

            Node current = dummyHead.next;
            for (int i = 0; i < index; i++)
                current = current.next;
            return current.element;
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(size - 1);
        }

        public void Set(E element, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Get failed. Illegal index.");
            }

            Node current = dummyHead.next;
            for (int i = 0; i < index; i++)
                current = current.next;

            current.element = element;
        }

        public bool Contains(E element)
        {
            Node current = dummyHead.next;
            while (current != null)
            {
                if (current.element.Equals(element))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public E Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Get failed. Illegal index.");
            }

            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
                prev = prev.next;

            Node retNode = prev.next;
            prev.next = retNode.next;
            retNode.next = null;
            size--;

            return retNode.element;
        }

        public E RemoveFirst()
        {
            return Remove(0);
        }

        public E RemoveLast()
        {
            return Remove(size - 1);
        }

        public void RemoveElement(E element)
        {
            Node prev = dummyHead;
            while (prev.next != null)
            {
                if (prev.next.element.Equals(element))
                    break;
                prev = prev.next;
            }

            if (prev.next != null)
            {
                Node delNode = prev.next;
                prev.next = delNode.next;
                delNode.next = null;
                size--;
            }
        }
    }
}

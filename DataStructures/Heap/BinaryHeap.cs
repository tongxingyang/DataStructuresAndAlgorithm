using System;
using System.Timers;

namespace DataStructures.Heap
{
    /// <summary>
    /// 二叉堆
    /// </summary>
    public class BinaryHeap<E>
    {
        public BinaryHeap():this(null,null)
        {
            
        }

        public BinaryHeap(Comparison<E> comparison):this(null,comparison)
        {
            
        }

        public BinaryHeap(E[] elements):this(elements,null)
        {
            
        }
        
        public BinaryHeap(E[] elememts ,Comparison<E> comparison)
        {
            this.comparison = comparison;
            if (elememts == null || elememts.Length == 0)
            {
                size = 0;
                this.elements = new E[DEFAULT_CAPACITY];
            }
            else
            {
                size = elememts.Length;
                int capacity = Math.Max(size, DEFAULT_CAPACITY);
                this.elements = new E[capacity];
                for (int i = 0; i < elememts.Length; i++)
                {
                    this.elements[i] = elememts[i];
                }
                this.heapify();
            }
            
        }

        private E[] elements;
        private readonly int DEFAULT_CAPACITY = 10;

        private Comparison<E> comparison;
        
        private int size;
        public int Size => size;

        public bool IsEmpty()
        {
            return size == 0;
        }
        
        public void Clear()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = default(E);
            }
            size = 0;
        }

        public void AddElement(E element)
        {
            checkElement(element);
            ensureCapacity(size+1);
            elements[size] = element;
            siftUp(size);
            size++;
        }

        public E GetValue()
        {
            check();
            return elements[0];
        }

        public E RemoveValue()
        {
            check();
            int lastIndex = --size;
            E value = elements[0];
            elements[0] = elements[lastIndex];
            elements[lastIndex] = default(E);
            siftDown(0);
            return value;
        }

        public E ReplaceAdd(E element)
        {
            checkElement(element);
            E root = default(E);
            if (size == 0)
            {
                elements[0] = element;
                size++;
            }
            else
            {
                root = elements[0];
                elements[0] = element;
                siftDown(0);
            }
            return root;
        }

        protected int compare(E e1, E e2)
        {
            return comparison?.Invoke(e1, e2) ?? ((IComparable<E>)e1).CompareTo(e2);
        }

        private void heapify()
        {
            for (int i = (size >> 1) - 1; i >= 0; i--) {
                siftDown(i);
            }
        }
        
        private void siftDown(int index)
        {
            E element = elements[index];
            int half = size >> 1;
            while (index<half)
            {
                int childIndex = (index << 1) + 1;
                E child = elements[childIndex];
                int rightChildIndex = childIndex + 1;

                if (rightChildIndex < size && compare(elements[rightChildIndex], child) > 0)
                {
                    child = elements[childIndex = rightChildIndex];
                }

                if (compare(element, child) >= 0) break;
                elements[index] = child;
                index = childIndex;
            }
            elements[index] = element;
        }
        
        private void siftUp(int index)
        {
            E element = elements[index];//上溢的元素
            while (index>0)
            {
                int parentIndex = (index - 1) >> 1;
                E parent = elements[parentIndex];
                if(compare(element,parent)<=0) break;
                elements[index] = parent;
                index = parentIndex;
            }
            elements[index] = element;
        }
        
        private void ensureCapacity(int capacity)
        {
            int oldCapacity = elements.Length;
            if(oldCapacity>=capacity) return;
            int newCapacity = oldCapacity + (oldCapacity >> 1);
            E[] newElements = new E[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[i];
            }
            elements = newElements;
        }

        private void check()
        {
            if (size == 0)
            {
                throw new Exception("Heap is empty");
            }
        }

        private void checkElement(E ele)
        {
            if (ele == null)
            {
                throw new Exception("element must not be null");
            }
        }
    }
}
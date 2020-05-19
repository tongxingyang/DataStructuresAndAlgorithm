using System;
namespace DataStructures.Arrays
{
    public class Array<E>
    {
        public static int DEFAULT_CAPACITY = 10;
        private E[] elements;
        private int size;
        public Array(int capacity)
        {
            capacity = capacity < DEFAULT_CAPACITY ? DEFAULT_CAPACITY : capacity;
            elements = new E[capacity];
            size = 0;
        }

        public Array() : this(DEFAULT_CAPACITY)
        {

        }

        public int GetCapacity()
        {
            return elements.Length;
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
                throw new IndexOutOfRangeException("添加元素失败 索引不合法 index : " + index + " size : " + size);
            }
            if (index == this.GetCapacity())
            {
                resize(this.GetCapacity() + (this.GetCapacity() >> 1));
            }
            for (int i = size - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }
            elements[index] = element;
            size++;
        }

        public E Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("移除元素失败 索引不合法 index : " + index + " size : " + size);
            }
            E ret = elements[index];
            for (int i = index + 1; i < size; i++)
            {
                elements[i - 1] = elements[i];
            }
            size--;
            elements[size] = default;
            int newCapacity = this.GetCapacity() >> 1;
            if (size <= newCapacity && GetCapacity() > DEFAULT_CAPACITY)
            {
                resize(newCapacity);
            }
           
            return ret;
        }

        public void AddFirst(E element)
        {
            Add(0, element);
        }

        public void AddLast(E element)
        {
            Add(size, element);
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
            int index = IndexOf(element);
            if (index != -1)
            {
                Remove(index);
            }
        }

        public E Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("获取失败 索引不合法  index : " + index + " size : " + size);
            }
            return elements[index];
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(size - 1);
        }

        public void Set(int index, E element)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("设置失败 索引不合法  index : " + index + " size : " + size);
            }
            elements[index] = element;
        }

        public bool Contains(E element)
        {
            for (int i = 0; i < size; i++)
            {
                if (elements[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(E element)
        {
            for (int i = 0; i < size; i++)
            {
                if (elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        private void resize(int newCapacity)
        {
            E[] newElements = new E[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[i];
            }
            elements = newElements;
        }
    }
}

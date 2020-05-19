using System.Collections.Generic;

namespace DataStructures.Set
{
    public class ListSet<E>
    {
        private List<E> list = new List<E>();
        public int GetSize()
        {
            return list.Count;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(E element)
        {
            return list.Contains(element);
        }

        public void Add(E element)
        {
            var index = list.IndexOf(element);
            if (index != -1)
            {
                list[index] = element;
            }
            else
            {
                list.Add(element);
            }
        }

        public void Remove(E element)
        {
            var index = list.IndexOf(element);
            if (index != -1)
            {
                list.Remove(element);
            }
        }

        public void Traversal(Visitor visitor)
        {
            if (visitor == null) return;
            for (int i = 0; i < list.Count; i++)
            {
                if(visitor.visit(list[i])) return;
            }
        }
	
        public abstract class Visitor
        {
            public bool stop;
            public abstract bool visit(E element);
        }
    }
}
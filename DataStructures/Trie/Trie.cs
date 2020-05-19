using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trie
{
    /// <summary>
    /// 字典树
    /// </summary>
    public class Trie<E>
    {
        public class Node
        {
            public Node Parent { get; set; }
            public  Dictionary<char, Node> Children { get; set; }
            public char Character { get; set; }
            public E Value { get; set; }
            public bool IsWord { get; set; }

            public Node(Node parent)
            {
                this.Parent = parent;
            }
                        
        }

        private int size;
        private Node root;

        public int Size()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            size = 0;
            root = null;
        }

        public bool StartWith(string prefix)
        {
            return getNode(prefix) != null;
        }

        public E GetValue(string key)
        {
            Node node = getNode(key);
            if (node != null && node.IsWord)
            {
                return node.Value;
            }
            return default(E);
        }

        public E AddValue(string key, E value)
        {
            check(key);
            if (root == null)
            {
                root = new Node(null);
            }

            Node node = root;
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                bool empty = node.Children == null;
                Node childNode = empty ? null : node.Children[c];
                if (childNode == null)
                {
                    childNode = new Node(node);
                    childNode.Character = c;
                    node.Children = empty ? new Dictionary<char, Node>() : node.Children;
                    node.Children.Add(c,childNode);
                }
                node = childNode;
            }

            if (node.IsWord)
            {
                E oldValue = node.Value;
                node.Value = value;
                return oldValue;
            }

            node.IsWord = true;
            node.Value = value;
            size++;
            return default(E);
        }

        public E RemoveValue(string key)
        {
            Node node = getNode(key);
            if (node == null || !node.IsWord) return default(E);
            size--;
            E oldValue = node.Value;

            if (node.Children != null && node.Children.Count != 0)
            {
                node.IsWord = false;
                node.Value = default(E);
                return oldValue;    
            }

            Node parent = null;
            while ((parent = node.Parent) != null)
            {
                parent.Children.Remove(node.Character);
                if(parent.Children.Count!=0 || parent.IsWord) break;

                node = parent;
            }
            
            return oldValue;
        }
        
        private void check(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("key must not be empty"); 
            }
        }

        private Node getNode(string key)
        {
            check(key);
            Node node = root;
            for (int i = 0; i < key.Length; i++)
            {
                if (node?.Children == null || node.Children.Count == 0) return null;
                char c = key[i];
                node = node.Children[c];
            }
            return node;
        }
    }
}
using System;
using System.Collections.Generic;

namespace DataStructures.BinarySearchTree
{
    public class BST<E>
    {
        public abstract class Visitor
        {
            public bool stop;
            public abstract bool visit(E element);
        }


        public class Node
        {
            public E element;
            public Node left, right, parent;

            public Node(E element, Node parent)
            {
                this.element = element;
                this.parent = parent;
                right = left = null;
            }
            
            public bool isLeftChild() {
                return parent != null && this == parent.left;
            }
		
            public bool isRightChild() {
                return parent != null && this == parent.right;
            }
            
            public Node sibling() {
                if (isLeftChild()) {
                    return parent.right;
                }
			
                if (isRightChild()) {
                    return parent.left;
                }
			
                return null;
            }
        }

        protected Node root;
        private int size;
        private readonly Comparison<E> comparison;

        public BST(Comparison<E> comparison)
        {
            this.comparison = comparison;
            root = null;
            size = 0;
        }

        public BST() : this(null)
        {

        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        protected virtual void afterAdd(Node node) { }
        protected virtual void afterRemove(Node node) { }
        protected virtual Node createNode(E element, Node parent) {
            return new Node(element, parent);
        }
        
        public void Add(E element)
        {
            if (element == null) return;
            if (root == null)
            {
                root = createNode(element, null);
                size++;
                afterAdd(root);
                return;
            }
            Node node = root;
            Node parent;
            int cmp;
            do
            {
                parent = node;
                cmp = comparison(element, node.element);
                if (cmp > 0)
                {
                    node = node.right;
                }
                else if (cmp < 0)
                {
                    node = node.left;
                }
                else if (cmp == 0)
                {
                    node.element = element;
                    return;
                }
            } while (node != null);

            Node newNode = createNode(element, parent);
            if (cmp > 0)
            {
                parent.right = newNode;
            }
            else
            {
                parent.left = newNode;
            }
            size++;
            afterAdd(newNode);
        }

        public Node GetNode(E element)
        {
            Node node = root;
            while (node != null)
            {
                int cmp = comparison(root.element, element);
                if (cmp > 0)
                {
                    node = node.right;
                } else if (cmp < 0)
                {
                    node = node.left;
                }
                else
                {
                    return node;
                }
            }
            return null;
        }

        public bool Contains(E element)
        {
            return GetNode(element) != null;
        }

        //遍历操作

        public void PreOrderRecursion(Visitor visitor)
        {
            if (visitor == null) return;
            preOrderRecursion(root, visitor);
        }

        private void preOrderRecursion(Node node, Visitor visitor)
        {
            if (node == null || visitor.stop)
            {
                return;
            }
            visitor.stop = visitor.visit(node.element);
            preOrderRecursion(node.left, visitor);
            preOrderRecursion(node.right, visitor);
        }

        public void PreOrder(Visitor visitor)
        {
            if(visitor == null || root == null) return;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                Node node = stack.Pop();
                if(visitor.visit(node.element)) return;
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            
        }

        public void InOrderRecursion(Visitor visitor)
        {
            if (visitor == null) return;
            inOrderRecursion(root, visitor);
        }

        private void inOrderRecursion(Node node, Visitor visitor)
        {
            if (node == null || visitor.stop)
            {
                return;
            }
            inOrderRecursion(node.left, visitor);
            if (visitor.stop) return;
            visitor.stop = visitor.visit(node.element);
            inOrderRecursion(node.right, visitor);
        }

        public void InOrder(Visitor visitor)
        {
            if(visitor == null || root == null) return;
            Node node = root;
            Stack<Node> stack = new Stack<Node>();
            while (true)
            {
                if (node != null)
                {
                    stack.Push(node.left);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return;
                    }
                    node = stack.Pop();
                    if(visitor.visit(node.element)) return;

                    node = node.right;
                }
            }
        }

        public void PostOrderRecursion(Visitor visitor)
        {
            if (visitor == null) return;
            postOrderRecursion(root, visitor);
        }

        private void postOrderRecursion(Node node, Visitor visitor)
        {
            if (node == null || visitor.stop)
            {
                return;
            }
            postOrderRecursion(node.left, visitor);
            postOrderRecursion(node.right, visitor);
            if (visitor.stop) return;
            visitor.stop = visitor.visit(node.element);
        }

        public void PostOrder(Visitor visitor)
        {
            if(visitor == null || root == null) return;
            Node prev = null;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0) {
                Node top = stack.Peek();
                if ((top.left == null && top.right == null) || (prev != null && prev.parent == top)) {
                    prev = stack.Pop();
                    if (visitor.visit(prev.element)) return;
                } else {
                    if (top.right != null) {
                        stack.Push(top.right);
                    }
                    if (top.left != null) {
                        stack.Push(top.left);
                    }
                }
            }
        }

        public void LevelOrder(Visitor visitor)
        {
            if (visitor == null) return;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count != 0)
            {
                Node node = queue.Dequeue();
                visitor.stop = visitor.visit(node.element);
                if (visitor.stop) return;

                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        public Node GetMinNode(Node node = null)
        {
            if (size == 0)
                throw new IndexOutOfRangeException("BST is empty");

            node = node ?? root;
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public E GetMinElement(Node node = null)
        {
            return GetMinNode(node).element;
        }

        public Node GetMaxNode(Node node = null)
        {
            if (size == 0)
                throw new IndexOutOfRangeException("BST is empty");

            node = node ?? root;
            while (node.right != null)
            {
                node = node.right;
            }
            return node;
        }

        public E GetMaxElement(Node node = null)
        {
            return GetMaxNode(node).element;
        }


        public E RemoveMinElement(Node node = null)
        {
            if (size == 0)
                throw new IndexOutOfRangeException("BST is empty");
            Node removeNode = GetMinNode(node);
            this.removeNode(removeNode);
            return removeNode.element;
        }

        public E RemoveMaxElement(Node node = null)
        {
            if (size == 0)
                throw new IndexOutOfRangeException("BST is empty");
            Node removeNode = GetMaxNode(node);
            this.removeNode(removeNode);
            return removeNode.element;
        }

        /// <summary>
        /// 获取前驱结点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetPredecessorNode(Node node)
        {
            if (node == null) return null;
            Node leftNode = node.left;
            if (leftNode != null)
            {
                return GetMaxNode(leftNode);
            }
           
            while (node.parent != null && node.parent.left == node)
            {
                node = node.parent;
            }

            return node.parent;
        }

        /// <summary>
        /// 获取后继结点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetSuccessorNode(Node node)
        {
            if (node == null) return null;
            Node rightNode = node.right;
            if (rightNode != null)
            {
                return GetMinNode(rightNode);
            }

            while (node.parent != null && node.parent.right == node)
            {
                node = node.parent;
            }
            return node.parent;
        }

        public void Remove(E element)
        {
            removeNode(GetNode(element));
        }

        private void removeNode(Node node)
        {
            if (node == null) return;

            size--;
            //度为2
            if(node.left != null && node.right != null)
            {
                Node successorNode = GetSuccessorNode(node);
                node.element = successorNode.element;
                node = successorNode;
            }

            Node replaceNode = node.left ?? node.right;
            //度为1
            if(replaceNode != null)
            {
                replaceNode.parent = node.parent;

                if (node.parent == null)
                {
                    root = replaceNode;
                }
                else if (node == node.parent.left)
                {
                    node.parent.left = replaceNode;
                }
                else
                {
                    node.parent.right = replaceNode;
                }
                afterRemove(node);
            }
            else
            {
                if (node.parent == null)
                {
                    root = null;
                    afterRemove(node);
                }
                else
                {
                    if (node == node.parent.left)
                    {
                        node.parent.left = null;
                    }
                    else if (node == node.parent.right)
                    {
                        node.parent.right = null;
                    }
                    afterRemove(node);
                }
            }
            
        }

        public int Height(Node node = null)
        {
            node = node ?? root;
            if (node == null) return 0;

            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(node);

            int height = 0;
            int levelSize = nodes.Count;

            while (nodes.Count != 0)
            {
                Node currentNode = nodes.Dequeue();
                if (currentNode.left != null)
                {
                    nodes.Enqueue(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    nodes.Enqueue(currentNode.right);
                }
                levelSize--;
                if (levelSize == 0)
                {
                    height++;
                    levelSize = nodes.Count;
                }
            }
            return height;
        }
        
    }
}

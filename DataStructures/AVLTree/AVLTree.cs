using System;
using DataStructures.BinarySearchTree;

namespace DataStructures.AVLTree
{
    public class AVLTree<E> : BST<E>
    {
        public class AVLNode : Node
        {
            public int Height = 1;
            public AVLNode(E element, Node parent) : base(element, parent)
            {
                
            }

            /// <summary>
            /// 平衡因子
            /// </summary>
            /// <returns></returns>
            public int BalanceFactor()
            {
                int leftHeight = ((AVLNode) left)?.Height ?? 0;
                int rightHeight = ((AVLNode) right)?.Height ?? 0;
                return leftHeight - rightHeight;
            }

            public void UpdateHeight()
            {
                int leftHeight = ((AVLNode) left)?.Height ?? 0;
                int rightHeight = ((AVLNode) right)?.Height ?? 0;
                Height = 1 + Math.Max(leftHeight, rightHeight);
            }

            /// <summary>
            /// 最高的子节点
            /// </summary>
            /// <returns></returns>
            public Node TallerChild()
            {
                int leftHeight = ((AVLNode) left)?.Height ?? 0;
                int rightHeight = ((AVLNode) right)?.Height ?? 0;

                if (leftHeight > rightHeight) return left;
                if (leftHeight < rightHeight) return right;
                return isLeftChild() ? left : right;
            }
            
        }
        
        public AVLTree():this(null)
        {
            
        }

        public AVLTree(Comparison<E> comparison):base(comparison)
        {
           
        }
        
        protected override void afterAdd(Node node)
        {
            while ((node = node.parent) != null)
            {
                if (isBalanced(node))
                {
                    updateHeight(node);
                }
                else
                {
                    rebalance(node);
                    break;
                }
            }
        }
        
        
        protected override void afterRemove(Node node)
        {
            while ((node = node.parent) != null)
            {
                if (isBalanced(node))
                {
                    updateHeight(node);
                }
                else
                {
                    rebalance(node);
                }
            }
        }
        
        private void rebalance(Node grand) {
            Node parent = ((AVLNode)grand).TallerChild();
            Node node = ((AVLNode)parent).TallerChild();
            if (parent.isLeftChild()) { // L
                if (node.isLeftChild()) { // LL
                    rotate(grand, node, node.right, parent, parent.right, grand);
                } else { // LR
                    rotate(grand, parent, node.left, node, node.right, grand);
                }
            } else { // R
                if (node.isLeftChild()) { // RL
                    rotate(grand, grand, node.left, node, node.right, parent);
                } else { // RR
                    rotate(grand, grand, parent.left, parent, node.left, node);
                }
            }
        }
        
        private void rotate(Node r, Node b, Node c,Node d,Node e, Node f) {
            
            d.parent = r.parent;
            if (r.isLeftChild()) {
                r.parent.left = d;
            } else if (r.isRightChild()) {
                r.parent.right = d;
            } else {
                root = d;
            }
		
            b.right = c;
            if (c != null) {
                c.parent = b;
            }
            updateHeight(b);
		
            f.left = e;
            if (e != null) {
                e.parent = f;
            }
            updateHeight(f);
		
            d.left = b;
            d.right = f;
            b.parent = d;
            f.parent = d;
            updateHeight(d);
        }
        
        protected override Node createNode(E element, Node parent) {
            return new AVLNode(element, parent);
        }

        private void updateHeight(Node node)
        {
            ((AVLNode)node).UpdateHeight();
        }

        private bool isBalanced(Node node)
        {
            return Math.Abs(((AVLNode)node).BalanceFactor()) <= 1;
        }
        
    }
}
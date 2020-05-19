using System;
using DataStructures.BinarySearchTree;

namespace DataStructures.RBTree
{
    public class RBtree<E>:BST<E>
    {
        public class RBNode : Node
        {
            public bool color = RED;
            public RBNode(E element, Node parent) : base(element, parent)
            {
                
            }
        }
        
        private static bool RED = false;
        private static bool BLACK = true;
        
        public RBtree():this(null)
        {
            
        }

        public RBtree(Comparison<E> comparison):base(comparison)
        {
           
        }
        
        protected override Node createNode(E element, Node parent) {
            return new RBNode(element, parent);
        }

        protected void rotateLeft(Node grand) {
            Node parent = grand.right;
            Node child = parent.left;
            grand.right = child;
            parent.left = grand;
            afterRotate(grand, parent, child);
        }
	
        protected void rotateRight(Node grand) {
            Node parent = grand.left;
            Node child = parent.right;
            grand.left = child;
            parent.right = grand;
            afterRotate(grand, parent, child);
        }
	
        protected void afterRotate(Node grand, Node parent, Node child) {
            parent.parent = grand.parent;
            if (grand.isLeftChild()) {
                grand.parent.left = parent;
            } else if (grand.isRightChild()) {
                grand.parent.right = parent;
            } else { 
                root = parent;
            }
		
            if (child != null) {
                child.parent = grand;
            }
		
            grand.parent = parent;
        }

        protected override void afterAdd(Node node)
        {
            Node parent = node.parent;
		
            if (parent == null) {
                black(node);
                return;
            }
		
            if (isBlack(parent)) return;
		
            Node uncle = parent.sibling();
            Node grand = red(parent.parent);
            if (isRed(uncle)) { 
                black(parent);
                black(uncle);
                afterAdd(grand);
                return;
            }
		
            if (parent.isLeftChild()) {
                if (node.isLeftChild()) {
                    black(parent);
                } else {
                    black(node);
                    rotateLeft(parent);
                }
                rotateRight(grand);
            } else {
                if (node.isLeftChild()) {
                    black(node);
                    rotateRight(parent);
                } else {
                    black(parent);
                }
                rotateLeft(grand);
            }
        }

        protected override void afterRemove(Node node)
        {
            if (isRed(node)) {
                black(node);
                return;
            }
		
            Node parent = node.parent;
            if (parent == null) return;
		
            bool left = parent.left == null || node.isLeftChild();
            Node sibling = left ? parent.right : parent.left;
            if (left) { 
                if (isRed(sibling)) { 
                    black(sibling);
                    red(parent);
                    rotateLeft(parent);
                    sibling = parent.right;
                }
			
                if (isBlack(sibling.left) && isBlack(sibling.right)) {
                    bool parentBlack = isBlack(parent);
                    black(parent);
                    red(sibling);
                    if (parentBlack) {
                        afterRemove(parent);
                    }
                } else { 
                    if (isBlack(sibling.right)) {
                        rotateRight(sibling);
                        sibling = parent.right;
                    }
				
                    color(sibling, colorOf(parent));
                    black(sibling.right);
                    black(parent);
                    rotateLeft(parent);
                }
            } else { 
                if (isRed(sibling)) { 
                    black(sibling);
                    red(parent);
                    rotateRight(parent);
                    sibling = parent.left;
                }
			
                if (isBlack(sibling.left) && isBlack(sibling.right)) {
                    bool parentBlack = isBlack(parent);
                    black(parent);
                    red(sibling);
                    if (parentBlack) {
                        afterRemove(parent);
                    }
                } else { 
                    if (isBlack(sibling.left)) {
                        rotateLeft(sibling);
                        sibling = parent.left;
                    }
				
                    color(sibling, colorOf(parent));
                    black(sibling.left);
                    black(parent);
                    rotateRight(parent);
                }
            }
        }

        private Node color(Node node, bool color) {
            if (node == null) return null;
            ((RBNode)node).color = color;
            return node;
        }
	
        private Node red(Node node) {
            return color(node, RED);
        }
	
        private Node black(Node node) {
            return color(node, BLACK);
        }
	
        private bool colorOf(Node node) {
            return ((RBNode) node)?.color ?? BLACK;
        }
	
        private bool isBlack(Node node) {
            return colorOf(node) == BLACK;
        }
	
        private bool isRed(Node node) {
            return colorOf(node) == RED;
        }
    }
}
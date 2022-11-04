
// KRISTY RATH
// 0707345
// AS4
// BINARY SEARCH TREE with insert, delete, search, findsmallest, find sibling, find parent sibling methods

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As4
{

    public  class Node<T>
    {
        public T value;
        public Node<T> parent;
        public Node<T> left;
        public Node<T> right;
        public override String ToString()
        {
            string str = "Value: " + value + " Left: " + left + " Right: " + right;
            return str;
        }

        // compares 2 nodes 
        public int CompareTo(Node<T> obj)
        {
        if (obj == null)
            {
                return -2;
            }
            else if (this == obj)
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
        


    }
    class BinarySearchTree<T> where T: IComparable
    {

        // CONSTRUCTOR
        public BinarySearchTree()
        {
            Node<T> root;
        }

        // INSERT METHO 
        public Node<T> insert(Node<T> root, T v) // int v
        {
            // insert at empty list
            if (root == null)
            {
                root = new Node<T>();
                root.parent = null;
                root.value = v;
            }
            // insert to left when value is smaller than root
            else if (root.value.CompareTo(v) == 1)
            {
                root.left = insert(root.left, v);
                root.left.parent = root;

            }
            // insert to right when value is larger than root
            else
            {
                root.right = insert(root.right, v);
                root.right.parent = root;
            }

            return root;
        }

        // TRAVERSE METHOD
        public void traverse(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            Console.WriteLine(root.value.ToString());
            traverse(root.left);
            traverse(root.right);


        }

        // INORDER TRAVERSAL
        public string inOrder(Node<T> root)
        {
            if (root == null)
            {
                return "";
            }
            inOrder(root.left);
            Console.WriteLine(root.value.ToString());
            inOrder(root.right);
            return "";
        }

        // PREORDER TRAVERSAL
        public string preOrder(Node<T> root)
        {

            if (root == null)
            {
                return "";
            }
            Console.WriteLine(root.value.ToString());
            preOrder(root.left);
            preOrder(root.right);
            return "";
        }

        // POSTORDER TRAVERSAL
        public string postOrder(Node<T> root)
        {

            if (root == null)
            {
                return "";
            }
            postOrder(root.left);
            postOrder(root.right);
            Console.WriteLine(root.value.ToString());

            return "";
        }

        // SEARCH METHOD
        public Node<T> search(Node<T> root, Node<T> nodeToFind)
        {
            // IF NODE TO SEARCH FOR IS NOT DEFINED, RETURN NULL NODE
            Node<T> newNode = null;
            if (nodeToFind == null)
            {
                return newNode;
            }
            // ITERATE TO EITHER LEFT OR RIGHT BRANCH 
            Node<T> currentNode = root;
            while (currentNode != null)
            {
                // if found, return node
                if (nodeToFind.CompareTo(currentNode) == 0)
                {
                    return currentNode;
                }
                // if larger than current node, go to right subtree
                else if (nodeToFind.CompareTo(currentNode) > 0)
                {
                    currentNode = currentNode.right;
                }
                // if smaller than current node, go to left subtree
                else
                {
                    currentNode = currentNode.left;
                }
            }
            return newNode;


        }
        
        // DELETE METHOD
       
        public Node<T> Delete(Node<T> root, Node<T> toDelete)
        {
            // check if item to delete exists
            if (search(root, toDelete) != null)
            {
                int children = GetNumChildren(toDelete);

                // IF NODE HAS 0 CHILDREN, IS LEAF NODE, THEN NULLIFY
                if (children == 0)
                {
                    if (isRightChild(toDelete)) {
                        toDelete.parent.right = null;

                    }
                    else
                    {
                        toDelete.parent.left = null;
                    }
                    toDelete = null;
                }
                // IF NODE HAS 1 CHILDREN, REASSIGN CHILDREN TO PARENT
                else if (children == 1)
                {
                    // DELETE NODES WITH 1 LEFT CHILDREN
                    if (HasLeftChild(toDelete))
                    {
                        if (toDelete.parent != null)
                        {
                            toDelete.left.parent = toDelete.parent;
                            // check if node is a right or left node, to assign parent
                            if (isRightChild(toDelete))
                            {
                                toDelete.parent.right = toDelete.left;
                            }
                            else
                            {
                                toDelete.parent.left = toDelete.left;
                            }
                        }
                        else
                        {
                            toDelete.left.parent = null;
                            root = toDelete.left;

                        }

                    }
                    // DELETE NODES WITH 1 RIGHT CHILDREN

                    else
                    {
                        if (toDelete.parent != null) {

                            toDelete.right.parent = toDelete.parent;
                            if (isRightChild(toDelete))
                            {
                                toDelete.parent.right = toDelete.right;
                            }
                            else
                            {
                                toDelete.parent.left = toDelete.right;
                            }
                        }
                        else
                        {

                            toDelete.right.parent = null;
                            root = toDelete.right;
                        }

 
                    }
                    toDelete = null;
                }
                // DELETING NODES WITH TWO CHILDREN
                else if (children == 2)
                {
                    // finding smallest number of right subtree
                    Node<T> smallest = FindSmallest(toDelete.right);
                    Console.WriteLine("Smallest on right side of tree: " + smallest.ToString());

                    // connect position of smallest node to toDelete node
                    smallest.left = toDelete.left;
                    smallest.right = toDelete.right;
                    toDelete.right.parent = smallest;
                    toDelete.left.parent = smallest;

                    // disconnect current parent of smallest value
                    if (smallest.parent != null)
                    {
                        if (isRightChild(smallest))
                        {
                            smallest.parent.right = null;
                        }
                        else
                        {
                            smallest.parent.left = null;
                        }
                    }
                   
                    // assign parent to smallest node
                    if (toDelete.parent != null) {
                        smallest.parent = toDelete.parent;
                        if (isRightChild(toDelete))
                        {
                            toDelete.parent.right = smallest;
                        }
                        else
                        {
                            toDelete.parent.left = smallest;
                        }
                    }
                    else
                    {
                        // if smallest replaces root, no parent is assigned
                        smallest.parent = null;
                        root = smallest;
                    }

                    
                    

                    toDelete = null;
                }
                return root;
            }
            return root;
        }
        // GET SIBLINGS METHOD
        public List<Node<T>> GetSiblings (Node<T> root) {

            List<Node<T>> siblings = new List<Node<T>>();

            // if node is root, return no siblings
            if (root.parent == null)
            {
                return siblings;
            }
            else 
            {
                // check if parent is left or right child, then add its sibling
                if (root.parent.left != null)
                {
                    if (root.parent.left.CompareTo(root) == 0)
                    {
                        siblings.Add(root.parent.right);
                    }
                }
                else if (root.parent.right != null)
                {

                    if (root.parent.right.CompareTo(root) == 0)
                    {
                        siblings.Add(root.parent.left);

                    }
                }
            }

            return siblings;

        }

        // GETSIBLINGSOFPARENT
        public List<Node<T>> GetSiblingOfParent(Node<T> root) {
            List<Node<T>> siblingsOfParent;

            Node<T> parent = root.parent;
            siblingsOfParent = GetSiblings(parent);
            return siblingsOfParent;
        }


        public string breadthFirst(Node<T> root)
        {
            // first in front, out from front
            LinkedList<Node<T>> queue = new LinkedList<Node<T>>();
            LinkedList<Node<T>> visitedNodes = new LinkedList<Node<T>>();


            // add root to queue
            queue.AddLast(root);
            int numLoops = 0;
            while (queue.Count != 0)
            {   
                Console.WriteLine("\nLoop iteration" + numLoops);
                Node<T> n = queue.First();
                Console.WriteLine("Printed:" + n.value.ToString());

                Console.WriteLine("Queue:");
                foreach (Node<T> nd in queue)
                {
                    Console.WriteLine(nd.value.ToString());
                }

                if (n.left != null)
                {
                    queue.AddLast(n.left);
                }
                if (n.right != null)
                {
                    queue.AddLast(n.right);
                }
                // remove from queue once iterated through
                queue.RemoveFirst();
                numLoops++;
            }

            return "";

        }

        // FINDSMALLEST METHOD
        public Node<T> FindSmallest(Node<T> root)
        {
            // go to the left most branch
            while (root.left != null)
            {
                root = root.left;
            }
            return root;

        }

        // GETNUMCHILDREN METHOD
        public int GetNumChildren(Node<T> nd)
        {
            int numChildren = 0;

            if (nd.left != null)
            {
                numChildren++;
            }
            if (nd.right != null)
            {
                numChildren++;
            }
            return numChildren;

        }
        // HASRIGHTCHILD METHOD
        public bool HasRightChild(Node<T> nd)
        {
            if (nd.right != null)
            {
                return true;
            }
            return false;
        }

        // HASLEFTCHILD METHOD
        public bool HasLeftChild(Node<T> nd)
        {
            if (nd.left != null)
            {
                return true;
            }
            return false;
        }
        // ISRIGHTCHILD METHOD
        public bool isRightChild (Node<T> nd)
        {
            if (nd.parent != null && nd.parent.right == nd)
            {
                return true;
            }
            return false;
         }
    }
}

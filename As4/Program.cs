

// KRISTY RATH
// 0707345
// AS4
// Tests binary heap and binary search tree
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace As4
{
    class Program
    {
        static void Main(string[] args)
        {

            
            // ******************************HEAP*******************************
            Console.WriteLine("******************************HEAP*******************************");

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            int sizeOfHeap = 10;
            BinaryHeap<Animal> sampleHeap = new BinaryHeap<Animal>(sizeOfHeap);
            Random rand = new Random();

            //populate a heap
            for (int i = 0; i < 5; i++)
            {
                sampleHeap.AddItem(new Cat());
            }
            for (int i = 5; i < 10; i++)
            {
                sampleHeap.AddItem(new Snake());
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            long tsticks = stopWatch.ElapsedTicks;
            string elapsedTime = String.Format("Time for insertion {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine(elapsedTime);

            // Print each element before sorting
            foreach (Animal i in sampleHeap)
            {
                Console.WriteLine(i.ToString() + " ");
            }

            // HEAP SORT
            Console.WriteLine(">>> HEAP SORT: ");
            sampleHeap.HeapSort();
            //Print each  element in the heap
            foreach (Animal i in sampleHeap)
            {
                Console.WriteLine(i.ToString() + " ");
            }



            // ****************************** BST *******************************
            Console.WriteLine("******************************BST*******************************");

            Node<Animal> root = null;
            BinarySearchTree<Animal> bst = new BinarySearchTree<Animal>();
            int SIZE = 10; // tested on up to 200k elements and it works fine
            Animal[] testArray = new Animal[SIZE];
            Random rnd = new Random();
            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();


            Console.WriteLine(">>> Elements TO BE inserted into the BST");
            for (int i = 0; i < 5; i++)
            {
                testArray[i] = new Cat();
                Console.WriteLine(testArray[i]);
            }
            for (int i = 5; i < 10; i++)
            {
                testArray[i] = new Snake();
                Console.WriteLine(testArray[i]);
            }

            Console.WriteLine(">>> Elements INSERTED into BST");

            for (int i = 0; i < SIZE; i++)
            {
                root = bst.insert(root, testArray[i]);
            }
            Console.WriteLine("ROOT: " + root.value.ToString());

            stopWatch2.Stop();
            TimeSpan ts2 = stopWatch2.Elapsed;
            string elapsedTime2 = String.Format("Time for insertion {0:00}:{1:00}:{2:00}.{3:00}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds);
            Console.WriteLine(elapsedTime2);

            Console.WriteLine("inOrder");
            Console.WriteLine(bst.inOrder(root));

            // TEST FIND SMALLEST
            Node<Animal> smallest = bst.FindSmallest(root);
            Console.WriteLine("\n>>> Smallest value: " + smallest.value.ToString());

            // TEST FIND SEARCH
            Console.WriteLine("\n>>> Search for smallest value");

            Node<Animal> nodeToFind = bst.search(root, smallest);
            Console.WriteLine(nodeToFind.value.ToString());

            // TEST FIND SIBLINGS
            Console.WriteLine("\n>>> Find siblings of node of" + smallest.value.ID);

            List<Node<Animal>> siblings = bst.GetSiblings(smallest);

            if (siblings != null)
            {
 
                foreach (Node<Animal> sibling in siblings)
                {

                    if (sibling != null)
                    {
                        Console.WriteLine(sibling.ToString());
                    }
                }

            }


            // TEST FIND SIBLINGS OF PARENTS
            Console.WriteLine("\n>>> Find siblings of parents for node" + smallest.value.ID);

            siblings = bst.GetSiblingOfParent(smallest);

            if (siblings != null)
            {
                foreach (Node<Animal> sibling in siblings)
                {
                    if (sibling != null)
                    {
                        Console.WriteLine(sibling.ToString());
                    }
                }
            }


            // TEST SEARCH FOR 88
            Console.WriteLine("\n>>> Search for random node that doesn't exist");

            Node<Animal> random = new Node<Animal>();
            Node<Animal> toFind = bst.search(root, random);
            if (toFind != null)
            {
                Console.WriteLine(toFind.value.ToString());
            }
            else
            {
                Console.WriteLine("Node is not in list");
            }

            // TEST DELETE FOR LEAF VAUES, NO CHILDREN
            Console.WriteLine("\n>>> Test delete for smallest value/leaf value");
            bst.Delete(root, smallest);
            bst.inOrder(root);

            // TEST DELETE WITH 2 CHILDREN, DELETION OF ROOT
            Console.WriteLine("\n>>> Test delete with 2 children and when root is deleted ");
            root = bst.Delete(root, root);
            bst.inOrder(root);


   

            Console.ReadKey(); // only necessary if your project autocloses
        }
    }
}

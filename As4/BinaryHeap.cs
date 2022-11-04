
// KRISTY RATH
// 0707345
// AS4
// BinaryHeap with sort, get item methods

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As4

{
    // If you want a complete implementation of binary heaps for ints only https://egorikas.com/max-and-min-heap-implementation-with-csharp/
    class BinaryHeap<T> : IEnumerable where T : IComparable
    {
        public T[] array;
        private int count; // count is initialised in the constructor (below) and incremented in Additem
        public BinaryHeap(int size)
        {
            array = new T[size];
            count = 0;
        }
        // Get Item should really be private (needs to be public in the lab for demo purposes)
        public T GetItem(int index)
        {
            return array[index];
        }
        private void SetItem(int index, T value)
        {
            while (index >= array.Length) //note this is a while loop not an if, which fixes a bug with earlier SetItem implementations
                Grow(array.Length * 2);

            array[index] = value;

        }
        private void Grow(int newsize)
        {
            Array.Resize(ref array, newsize);
        }

        // Indices of left and right children
        // "Has" methods to determine if the indices exist
        private int LeftChildIndex(int pos) { return 2 * pos + 1; }
        private int RightChildIndex(int pos) { return 2 * pos + 2; }
        private int GetParentIndex(int pos) => (pos - 1) / 2;

        private T GetRightChild(int pos) => array[RightChildIndex(pos)];
        private T GetLeftChild(int pos) => array[LeftChildIndex(pos)];
        private T GetParent(int pos) => array[GetParentIndex(pos)];
        private bool HasLeftChild(int pos)
        {
            if (LeftChildIndex(pos) < count)
                return true;
            else
                return false;
        }
        private bool HasRightChild(int pos)
        {
            if (RightChildIndex(pos) < count)
                return true;
            else
                return false;
        }
        private bool IsRoot(int pos) => pos == 0; // (true if element is root)

        // Swap, uh, swaps two values given two indicies. This should be private but I originally had it public for some reason.   
        private void Swap(int position1, int position2)
        {
            T first = array[position1];
            array[position1] = array[position2];
            array[position2] = first;
        }


        //iterator so you can see how they work
        //This just prints all of the elements in the array in order, it's up to you to reconstruct the tree by hand. 
        // 
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < array.Length; index++)
            {
                // Yield each element 

                yield return array[index];
            }
        }
       
        public void AddItem(T value)
        {
   
            if (count >= array.Length)
            {
                Grow(array.Length + 1);
            }

            array[count] = value;
            count++;
            ReCalculateUp();
            


        }

        //ExtractRoot (which is the same as extract min in our case)
        public T ExtractHead() // (This could also be called 'pop')
        {
            // check to make sure the heap isn't empty, if it is, return a 'null' or at least, default object
            if (count <= 0) // change to count in assignment if you use that
            {
                System.Console.WriteLine("Tried to extract from an empty heap");
                return default(T);

            }

            // this should get the head
            T head = array[0];
            array[0] = array[count - 1];
            array[count - 1] = default(T);
            count--;
            ReCalculateDown();

            return head;

        }

        // add from top
        // if bigger than child, move down
        public void ReCalculateDown()
        {
            //CompareTo  
            //this.CompareTo(value) returns < 0 if this < value
            //this.CompareTo(value) returns >0 if this > value


            int index = 0;

            while (HasLeftChild(index))

            {
                // smaller index stores the index of the smaller child
                var biggerIndex = LeftChildIndex(index);
                // store smaller child in smallerIndex
                // if right child < left child
                if (HasRightChild(index) && (GetRightChild(index).CompareTo(GetLeftChild(index)) > 0)) //there's a set of ( ) around the right expression that are redundant but hopefully easier to read
                {
                    biggerIndex = RightChildIndex(index);
                }
                // if child value is smaller
                if (array[biggerIndex].CompareTo(array[index]) <= 0 ) //If array[smallerindex]>= array[index] 
                {
                    break;
                }

                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }

        // add from bottom
        // if smaller than above, swap
        public void ReCalculateUp()
        {
            //get the index of the last item
            //loop through the list, comparing the child to the parent.
            //if the parent is Greater than the child, swap them.
            //if the parent is less than or equal to the child, stop.


            // get last element
            int index = count - 1;
            // while parent is smaller
            while (!IsRoot(index) && (array[index].CompareTo(GetParent(index)) > 0))
            {
                // if parent is smaller than child
                if (GetParent(index).CompareTo(array[index]) < 0)
                {
                    var parentIndex = GetParentIndex(index);
                    Swap(parentIndex, index);
                    index = parentIndex;
                }

            }


        } 

        public ref T Peek()
        {

            return ref array[0];

        }


        public void HeapSort()
        {

            T[] sortedArr = new T[array.Length];
            // get root
            // swap root with item at end of array.
            // remove root from array and place to the end of sortedArr

            // repeat


            while (count != 0)
            {
                int lastIndex = count - 1;

                // save largest number on the other array
                sortedArr[lastIndex] = ExtractHead();
            }
            array = sortedArr;
           
        }

    }
}

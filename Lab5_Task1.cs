using System;
using System.Collections.Generic;

namespace Practise
{
    //custom collection class
    class CollectionType<T>
    {
        //stores elements
        private List<T> collection;
        //readonly number of elements
        public int Count
        {
            get { return collection.Count; }
        }
        //indexer
        public T this[int i]
        {
            get { return collection[i]; }
            set { collection[i] = value; }
        }
        //default constructor
        public CollectionType()
        {
            collection = new List<T>();
        }
        //constructor with one element as parameter
        //constructor that sets capacity
        public CollectionType(int capacity)
        {
            collection = new List<T>(capacity);
        }
        //constructor with array as parameter
        public CollectionType(T[] array)
        {
            collection = new List<T>(array);
        }
        //method to add element to the collection
        public void Add(T element)
        {
            collection.Add(element);
        }
        //method to remove element to the collection
        public void Remove(T element)
        {
            collection.Remove(element);
        }
        //method to check if collection contains such element
        public bool Contains(T element)
        {
            return collection.Contains(element);
        }
        //method to sort the collection
        public void Sort()
        {
            collection.Sort();
        }

    } 
    
    class Program
    {

        static void Main(string[] args)
        {
            CollectionType<int> test = new CollectionType<int>();
            test.Add(240);
            Console.Write(test[0]);
        }
    }
}

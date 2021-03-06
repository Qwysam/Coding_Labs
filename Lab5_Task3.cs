﻿using System;
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
        //return index of first occurence of element
        public int IndexOf(T element)
        {
            return collection.IndexOf(element);
        }
        //method to sort the collection
        public void Sort()
        {
            collection.Sort();
        }

    }



    class Program
    {
        //returns number of collections that contain two elements
        static int TwoElemCollections(CollectionType<object>[] arr)
        {
            int count = 0;
            foreach (CollectionType<object> collection in arr)
            {
                if (collection.Count == 2)
                    count++;
            }
            return count;
        }
        //res[0] = IndexOfMax  res[1] = IndexOfMin
        static int[] MaxAndMin(CollectionType<object>[] arr)
        {
            int[] res = new int[2];
            int tmp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Count > tmp)
                {
                    tmp = arr[i].Count;
                    res[0] = i;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Count < tmp)
                {
                    tmp = arr[i].Count;
                    res[1] = i;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            CollectionType<object>[] array = new CollectionType<object>[100];
            for (int i = 0; i < 100; i++)
                array[i] = new CollectionType<object>();
            Random r = new Random();
            Random e = new Random();
            array[0].Add(r);
            array[0].Add(e);
            Console.WriteLine($"There are {TwoElemCollections(array)} collections with 2 elements");
            int[] min_max = MaxAndMin(array);
            Console.WriteLine($"Index of biggest collection : {min_max[0]}");
            Console.WriteLine($"Index of smallest collection : {min_max[1]}");
        }
    }
}
﻿using BashSoft.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.DataStructures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public SimpleSortedList(int capacity) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList() : this(DefaultSize)
        {
        }

        public SimpleSortedList(IComparer<T> comparison) : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Capacity => this.innerCollection.Length;
        public int Size => this.size;

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.size - 1] = default(T);

                this.size--;
            }

            return hasBeenRemoved;
        }

        //private void InitializeInnerCollection(int capacity)
        //{
        //    if (capacity < 0)
        //    {
        //        throw new ArgumentException("Capacity cannot be negative!");
        //    }
        //
        //    this.innerCollection = new T[capacity];
        //}

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.innerCollection.Length < this.size)
            {
                this.Resize();
            }

            this.innerCollection[this.size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultyResize(collection);
            }

            foreach (var element in collection)
            {
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentException();
            }

            StringBuilder sb = new StringBuilder();

            foreach (var element in this)
            {
                sb.Append(element);
                sb.Append(joiner);
            }

            sb.Remove(sb.Length - joiner.Length, joiner.Length);

            return sb.ToString();
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size * 2];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        private void MultyResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }
    }
}
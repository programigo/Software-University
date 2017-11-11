using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DataStructure<T> : IEnumerable
    where T : IComparable<T>
{
    private List<T> elements;

    public DataStructure()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public void Remove(int index)
    {
        this.elements.RemoveAt(index);
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temporaryValue = this.elements[index1];
        this.elements[index1] = this.elements[index2];
        this.elements[index2] = temporaryValue;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        foreach (var item in this.elements)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        return this.elements.Max();
    }

    public T Min()
    {
        return this.elements.Min();
    }

    public IEnumerator GetEnumerator()
    {
        return elements.GetEnumerator();
    }
}
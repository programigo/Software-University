public class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        var array = new T[length];

        return array;
    }
}
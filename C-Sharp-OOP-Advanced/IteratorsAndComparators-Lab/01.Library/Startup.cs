namespace _01.Library
{
    public class Startup
    {
        public static void Main()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            global::_01.Library.Library libraryOne = new global::_01.Library.Library();
            global::_01.Library.Library libraryTwo = new global::_01.Library.Library(bookOne, bookTwo, bookThree);
        }
    }
}

namespace _04.CopyBinaryFile
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string sourceImagePath = Console.ReadLine();
            string destinationImagePath = Console.ReadLine();

            FileStream source = new FileStream(sourceImagePath, FileMode.Open);
            FileStream destination = new FileStream(destinationImagePath, FileMode.Create);

            using (source)
            {
                using (destination)
                {
                    byte[] buffer = new byte[source.Length];

                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
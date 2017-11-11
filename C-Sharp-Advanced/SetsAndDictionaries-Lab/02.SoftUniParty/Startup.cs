namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            SortedSet<string> signedPartyGuests = new SortedSet<string>();
            SortedSet<string> guestsOnParty = new SortedSet<string>();

            while (input != "PARTY")
            {
                signedPartyGuests.Add(input);

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                guestsOnParty.Add(input);

                input = Console.ReadLine();
            }

            foreach (var guest in guestsOnParty)
            {
                if (signedPartyGuests.Contains(guest))
                {
                    signedPartyGuests.Remove(guest);
                }
            }

            Console.WriteLine(signedPartyGuests.Count);

            foreach (var signedPartyGuest in signedPartyGuests)
            {
                Console.WriteLine(signedPartyGuest);
            }
        }
    }
}

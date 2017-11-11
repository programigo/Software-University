namespace _08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;

            IList<ISoldier> allSoldiers = new List<ISoldier>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = input.Split();

                string soldierType = soldierInfo[0];

                switch (soldierType)
                {
                    case "Private":
                        allSoldiers.Add(new Private(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], double.Parse(soldierInfo[4])));
                        break;

                    case "LeutenantGeneral":
                        var privates = new List<ISoldier>();

                        for (int i = 5; i < soldierInfo.Length; i++)
                        {
                            var priv = allSoldiers.FirstOrDefault(pr => pr.Id == int.Parse(soldierInfo[i]));

                            privates.Add(priv);
                        }

                        allSoldiers.Add(new LeutenantGeneral(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], double.Parse(soldierInfo[4]), privates));
                        break;

                    case "Engineer":
                        if (soldierInfo[5] != "Airforces" && soldierInfo[5] != "Marines")
                        {
                            break;
                        }

                        var repairs = new List<IRepair>();

                        for (int i = 6; i < soldierInfo.Length - 1; i += 2)
                        {
                            repairs.Add(new Repair(soldierInfo[i], int.Parse(soldierInfo[i + 1])));
                        }

                        allSoldiers.Add(new Engineer(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], double.Parse(soldierInfo[4]), soldierInfo[5], repairs));
                        break;

                    case "Commando":
                        if (soldierInfo[5] != "Airforces" && soldierInfo[5] != "Marines")
                        {
                            break;
                        }

                        var missions = new List<IMission>();

                        for (int i = 6; i < soldierInfo.Length - 1; i += 2)
                        {
                            if (soldierInfo[i + 1] != "inProgress" && soldierInfo[i + 1] != "Finished")
                            {
                                continue;
                            }
                            missions.Add(new Mission(soldierInfo[i], soldierInfo[i + 1]));
                        }

                        allSoldiers.Add(new Commando(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], double.Parse(soldierInfo[4]), soldierInfo[5], missions));
                        break;

                    case "Spy":
                        allSoldiers.Add(new Spy(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], int.Parse(soldierInfo[4])));
                        break;
                }
            }

            foreach (var soldier in allSoldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
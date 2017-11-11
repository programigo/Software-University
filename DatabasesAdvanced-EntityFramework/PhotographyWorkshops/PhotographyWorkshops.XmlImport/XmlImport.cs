namespace PhotographyWorkshops.XmlImport
{
    using PhotographyWorkshops.Data;
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class XmlImport
    {
        private const string AccessoiresPath = "../../../datasets/accessories.xml";
        private const string WorkshopsPath = "../../../datasets/workshops.xml";
        private const string Error = "Error. Invalid data provided";

        static void Main(string[] args)
        {
            PhotographyWorkshopsContext context = new PhotographyWorkshopsContext();

            //ImportAccessoires(context);
            ImportWorkshops(context);
        }

        private static void ImportWorkshops(PhotographyWorkshopsContext context)
        {
            XDocument xmlDocument = XDocument.Load(WorkshopsPath);

            var workshopsXmls = xmlDocument.XPathSelectElements("workshops/workshop");

            foreach (var workshopsXml in workshopsXmls)
            {
                var workshopName = workshopsXml.Attribute("name").Value;
                var workshopStartDate = DateTime.Parse(workshopsXml.Attribute("start-date").Value);
                var workshopEndDate = DateTime.Parse(workshopsXml.Attribute("end-date").Value);
                var workshopLocation = workshopsXml.Attribute("location").Value;
                var workshopPrice = decimal.Parse(workshopsXml.Attribute("price").Value);
                var trainer = workshopsXml.Element("trainer").Value;
                List<XElement> participants = new List<XElement>();
                var participant = workshopsXml.XPathSelectElement("participants/participant");
                var participantFullName = participant.Attribute("first-name") + " " +
                                           participant.Attribute("last-name");

                participants.Add(participant);

                if (workshopName == null || workshopPrice == null || workshopLocation == null || trainer == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Workshop workshop = new Workshop()
                {
                    Name = workshopName,
                    StartDate = workshopStartDate,
                    EndDate = workshopEndDate,
                    Location = workshopLocation,
                    PricePerParticipant = workshopPrice,                   
                };

                context.Workshops.Add(workshop);
                Console.WriteLine($"Successfully imported {workshop.Name}");
            }

            context.SaveChanges();
        }

        private static void ImportAccessoires(PhotographyWorkshopsContext context)
        {
            XDocument xmlDocument = XDocument.Load(AccessoiresPath);

            var accessoriesXmls = xmlDocument.XPathSelectElements("accessories/accessory");

            foreach (var accessoriesXml in accessoriesXmls)
            {
                var accessoryName = accessoriesXml.Attribute("name").Value;

                Accessory accessory = new Accessory()
                {
                    Name = accessoryName
                };

                context.Accessories.Add(accessory);

                Console.WriteLine($"Successfully imported {accessory.Name}");
            }

            context.SaveChanges();
        }
    }
}

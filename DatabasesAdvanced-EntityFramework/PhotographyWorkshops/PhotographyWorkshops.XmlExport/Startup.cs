namespace PhotographyWorkshops.XmlExport
{
    using PhotographyWorkshops.Data;
    using System.Linq;
    using System.Xml.Linq;

    public class Startup
    {
        public static void Main()
        {
            PhotographyWorkshopsContext context = new PhotographyWorkshopsContext();

            var photographers = context.Photographers.Where(
                    camera => camera.PrimaryCamera.Make == camera.SecondaryCamera.Make)
                .Select(photographer => new
                {
                    Name = photographer.FirstName + " " + photographer.LastName,
                    PrimaryCamera = photographer.PrimaryCamera.Make + " " + photographer.PrimaryCamera.Model,
                    Lenses = photographer.Lenses
                });

            var xmlDocument = new XElement("photographers");

            foreach (var photographer in photographers)
            {
                XElement photographerEl = new XElement("photographer");
                photographerEl.Add(new XAttribute("name", photographer.Name));
                photographerEl.Add(new XAttribute("primary-camera", photographer.PrimaryCamera));

                XElement lensesEl = new XElement("lenses");

                foreach (var victim in photographer.Lenses)
                {

                }

                xmlDocument.Save("../../../datasets/same-cameras-photographers.xml");
            }
        }
    }
}

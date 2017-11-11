using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhotographyWorkshops.Data;

namespace PhotographyWorkshops.JsonExport
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotographyWorkshopsContext context = new PhotographyWorkshopsContext();

            OrderedPhotographers(context);
            LandscapePhotographers(context);
        }

        private static void LandscapePhotographers(PhotographyWorkshopsContext context)
        {
            var photographers = context.Photographers.Select(photographer => new
            {
                FirstName = photographer.FirstName,
                LastName = photographer.LastName,
                CameraMake = photographer.PrimaryCamera.Make,
                LensesCount = photographer.Lenses.Count
            })
            .Where(camera => camera.CameraMake == "DSLR")
            .OrderBy(firstame => firstame.FirstName);

            var json = JsonConvert.SerializeObject(photographers, Formatting.Indented);

            File.WriteAllText("../../../datasets/landscape-photogaphers.json", json);
        }

        private static void OrderedPhotographers(PhotographyWorkshopsContext context)
        {
            var photographers = context.Photographers.Select(photographer => new
            {
                FirstName = photographer.FirstName,
                LastName = photographer.LastName,
                Phone = photographer.Phone
            })
            .OrderBy(firstname => firstname.FirstName)
            .ThenByDescending(lastname => lastname.LastName);

            var json = JsonConvert.SerializeObject(photographers, Formatting.Indented);

            File.WriteAllText("../../../datasets/photographers-ordered.json", json);
        }
    }
}

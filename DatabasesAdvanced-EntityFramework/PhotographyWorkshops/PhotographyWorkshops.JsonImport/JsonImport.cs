using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using PhotographyWorkshops.Data;
using PhotographyWorkshops.Dtos;

namespace PhotographyWorkshops.JsonImport
{
    class JsonImport
    {
        private const string LensesPath = "../../../datasets/lenses.json";
        private const string CamerasPath = "../../../datasets/cameras.json";
        private const string PhotographersPath = "../../../datasets/photographers.json";
       
        private const string Error = "Error. Invalid data provided";
        static void Main()
        {
            PhotographyWorkshopsContext context = new PhotographyWorkshopsContext();

            //ImportLenses(context);
            //ImportCameras(context);
            Importhotographers(context);
        }

        private static void Importhotographers(PhotographyWorkshopsContext context)
        {
            string json = File.ReadAllText(PhotographersPath);
            var photographersDtos = JsonConvert.DeserializeObject<IEnumerable<PhotographerDto>>(json);

            foreach (var photographersDto in photographersDtos)
            {
                if (photographersDto.FirstName == null || photographersDto.LastName == null || photographersDto.Phone == null || photographersDto.Lenses.Count == 0)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Photographer photographer = new Photographer()
                {
                    FirstName = photographersDto.FirstName,
                    LastName = photographersDto.LastName,
                    Phone = photographersDto.Phone
                };

                if (photographer.FirstName == null || photographer.LastName == null || photographer.Phone == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                context.Photographers.Add(photographer);

                Console.WriteLine($"Successfully imported {photographer.FirstName} {photographer.LastName} | Lenses: {photographer.Lenses.Count}");
            }

            context.SaveChanges();
        }

        private static void ImportCameras(PhotographyWorkshopsContext context)
        {
            string json = File.ReadAllText(CamerasPath);
            var camerasDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(json);

            foreach (var camerasDto in camerasDtos)
            {
                if (camerasDto.Make == null || camerasDto.MinIso == 0 || camerasDto.Model == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Camera camera = new Camera()
                {
                    CameraType = camerasDto.Type,
                    Make = camerasDto.Make,
                    Model = camerasDto.Model,
                    MaxIso = camerasDto.MaxIso,
                    MinIso = camerasDto.MinIso,
                    MaxShutterSpeed = camerasDto.MaxShutterSpeed,                  
                };

                context.Cameras.Add(camera);
                Console.WriteLine($"Successfully imported {camera.CameraType} {camera.Make} {camera.Model}");
            }

            context.SaveChanges();
        }


        private static void ImportLenses(PhotographyWorkshopsContext context)
        {
            string json = File.ReadAllText(LensesPath);
            var lensesDtos = JsonConvert.DeserializeObject<IEnumerable<LensDto>>(json);

            foreach (var lensesDto in lensesDtos)
            {
                if (lensesDto.Make == null || lensesDto.FocalLength == 0 || lensesDto.MaxAperture == 0 || lensesDto.CompatibleWith == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Lens lens = new Lens()
                {
                    Make = lensesDto.Make,
                    FocalLength = lensesDto.FocalLength,
                    MaxAperture = lensesDto.MaxAperture,
                    CompatibleWith = lensesDto.CompatibleWith
                };              

                context.Lenses.Add(lens);
                Console.WriteLine($"Successfully imported {lens.Make} {lens.FocalLength}mm f{lens.MaxAperture}");
            }

            context.SaveChanges();
        }
    }
}

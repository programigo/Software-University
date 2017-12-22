namespace BikeMania.Test
{
    using AutoMapper;
    using BikeMania.Web.Infrastructure.Extensions.Mapping;

    public class Tests
    {
        private static bool testInitialized = false;


        public static void Initialize()
        {
            if (!testInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testInitialized = true;
            }
        }
        
    }
}

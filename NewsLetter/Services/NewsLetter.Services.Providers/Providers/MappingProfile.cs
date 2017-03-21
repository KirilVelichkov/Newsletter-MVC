using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Providers.Providers
{
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebMappingProfile());  //mapping between Web and Business layer objects
                cfg.AddProfile(new BusinessLayerProfile());  // mapping between Business and DB layer objects
            });

            return config;
        }
    }
}

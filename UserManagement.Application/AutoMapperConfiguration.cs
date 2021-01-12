using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UserManagement
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.GetEntryAssembly());
            });

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.GetEntryAssembly()));


            //Compile mapping after configuration to boost map speed
            configuration.CompileMappings();
        }
    }
}

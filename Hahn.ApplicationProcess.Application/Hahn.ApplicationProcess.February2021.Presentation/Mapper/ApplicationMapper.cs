using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Presentation.Mapper
{
    public class ApplicationMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Ensures that internal properties are mapped.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AssetMappingProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
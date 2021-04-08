using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Models;
using Hahn.ApplicationProcess.February2021.Presentation.Commands;
using Hahn.ApplicationProcess.February2021.Presentation.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicationProcess.February2021.Presentation.Mapper
{
    class AssetMappingProfile : Profile
    {
        public AssetMappingProfile()
        {

            CreateMap<Asset, CreateAssetCommand>().ReverseMap()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.DepartmentId));
            
            CreateMap<Asset, AssetResponse>().ReverseMap();



            CreateMap<AllAssetResponse, Asset>().ReverseMap()
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.AssetId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Asset, EditAssetCommand > ().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AssetId)); 

            CreateMap<Asset, DeleteAssetCommand>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AssetId));
        }
    }
}

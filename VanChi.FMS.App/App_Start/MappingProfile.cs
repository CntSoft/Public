using AutoMapper;
using VanChi.Business.DTO;
using VanChi.FMS.App.Models;
using VanChi.Data;

namespace VanChi.FMS.App
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Mapping Entity & EntityDTO
            //CreateMap<Resource, ResourceDTO>().ReverseMap();
            CreateMap<M_City, CityDTO>().ReverseMap();
            CreateMap<CityDTO, M_City>().ReverseMap();
            CreateMap<M_Country, CountryDTO>().ReverseMap();
            CreateMap<CountryDTO, M_Country>().ReverseMap();
            #endregion
            #region Mapping EntityDTO & Entity
            //CreateMap<ResourceDTO, ResourceModel>().ReverseMap();
            #endregion
        }
    }
}

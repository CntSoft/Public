using AutoMapper;
using VanChi.Business.DTO;
using VanChi.FMS.Web.Models;
using VanChi.Data;

namespace VanChi.FMS.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Mapping Entity & EntityDTO
            //CreateMap<Resource, ResourceDTO>().ReverseMap();
            #endregion
            #region Mapping EntityDTO & Entity
            //CreateMap<ResourceDTO, ResourceModel>().ReverseMap();
            #endregion
        }
    }
}

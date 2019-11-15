using VanChi.Business.Common;
using VanChi.Business.Concrete.ObjectBusiness;
using VanChi.Business.DTO;
using VanChi.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanChi.Business.Concrete
{
    public partial class Business : IBusiness
    {
       // public async Task<CheckContainerDTO> ContainerRelease_GetByDOId(Guid Id, AppType.Container type = AppType.Container.Release)
       // {
       //     return await new ContainerReleaseBusiness(this.UnitOfWork).GetByDOId(Id, type);
       // }
       // public async Task<ContainerReleaseTotalDTO> ContainerRelease_Total_GetByDOId(Guid Id, AppType.Container type = AppType.Container.Release)
       // {
       //     return await new ContainerReleaseBusiness(this.UnitOfWork).Total_GetByDOId(Id, type);
       // }
       //public async Task<bool> ContainerRelease_UpdateReturn_InsertHistory(List<Guid> LstID, ContainerReleaseHistoryDTO HistoryDto, StatusDTO dto)
       // {
       //     return await new ContainerReleaseBusiness(this.UnitOfWork).ContainerReleaseUpdateReturn_InsertHistory(LstID, HistoryDto, dto);
       // }
       // public async Task<bool> CRHistories_Insert(ContainerReleaseHistoryDTO historyDto, StatusDTO dto)
       // {
       //     return await new ContainerReleaseBusiness(this.UnitOfWork).CRHistories_Insert(historyDto, dto);
       // }
       // public async Task<Tuple<int, IList<ContainerReleaseHistoryDTO>>> ScanHistory_GetPaging(int pageIndex, int pageSize, string keyWord, string status, string type, string consignee, string scanfromdate, string scantodate, string username)
       // {
       //     return await new ContainerReleaseHistoryBusiness(this.UnitOfWork).ScanHistory_GetPaging(pageIndex, pageSize,  keyWord,  status,  type,  consignee,  scanfromdate,  scantodate,  username);
       // }
    }
}

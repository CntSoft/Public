using AutoMapper;
using VanChi.Business.DTO;
using VanChi.Business.Interface;
using VanChi.Data;
using VanChi.Repository.Interface;

namespace VanChi.Business.Concrete
{
    public partial class Business : IBusiness
    {
        #region Properties
        protected IUnitOfWork UnitOfWork { get; set; }

        #endregion

        #region Constructors
        public Business(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #endregion
    }
}

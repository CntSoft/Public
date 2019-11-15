using Autofac;
using Autofac.Integration.Mvc;
using VanChi.Business.Interface;
using VanChi.FMS.Web.Common;
using VanChi.Repository.EF;
using VanChi.Data;
using VanChi.Repository.Interface;
using System.Reflection;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(VanChi.FMS.Web.Autofac), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(VanChi.FMS.Web.Autofac), "Stop")]
namespace VanChi.FMS.Web
{
    public static class Autofac
    {
        #region Variables and Properties

        private static readonly ContainerBuilder container = new ContainerBuilder();
        private static IContainer containerBase;

        #endregion

        #region Public Methods
        public static void Start()
        {
            container.RegisterControllers(Assembly.GetExecutingAssembly());
            container.RegisterFilterProvider();
            RegisterService(container);
            containerBase = container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBase));
        }
        public static void Stop()
        {
            containerBase.Dispose();
        }
        public static IBusiness GetBusiness()
        {
            return new VanChi.Business.Concrete.Business(GetUnitOfWork());
        }

        #endregion

        #region Private Methods
        private static void RegisterService(ContainerBuilder container)
        {
            RegisterService_Business(container);
            RegisterService_Database(container);
            RegisterService_Others();
        }
        private static void RegisterService_Business(ContainerBuilder container)
        {
            container.RegisterType<VanChi.Business.Concrete.Business>().As<IBusiness>().InstancePerRequest();
        }
        private static void RegisterService_Database(ContainerBuilder container)
        {
            container.RegisterType<System.Data.Entity.DbContext>().As<System.Data.Entity.DbContext>().WithParameter(Constant.NameOrConnectionString_Key, Constant.NameOrConnectionString_Value);
            container.RegisterType<VanChi.Repository.EF.UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
        private static void RegisterService_Others()
        {
        }
        private static IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(new FMSDBEntities());
        }

        #endregion
    }
}
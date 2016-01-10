using Microsoft.Practices.Unity;
using Server.Business.Interfaces;
using Server.Business.Services;
using Server.Data;
using Server.Data.Repositories;
using System.Data.Entity;

namespace Server.Business.Configs
{
    public class UnityDIResolver
    {
        private static IUnityContainer defaultContainer = null;

        public static IUnityContainer DefaultContainer
        {
            get
            {
                if (defaultContainer == null)
                {
                    defaultContainer = CreateUnityContainer();
                }
                return defaultContainer;
            }

            set
            {
                defaultContainer = value;
            }
        }

        private static IUnityContainer CreateUnityContainer()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IEmployeeService, EmployeeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IHolidayService, HolidayService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILeaveDaysService, LeaveDaysService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVacationRequestService, VacationRequestService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAdditionalWorkingDaysService, AdditionalWorkingDaysService>(new HierarchicalLifetimeManager());


            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            return container;
        }
    }
}

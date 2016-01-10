using Microsoft.Practices.Unity;
using Server.Business.Interfaces;
using Server.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Business.Configs
{
    public class UnityResolver
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

            return container;
        }
    }
}

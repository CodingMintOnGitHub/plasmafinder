using MvvmCross.ViewModels;
using PlasmaFinder.Bootstrap;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.IoC;

namespace PlasmaFinder
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //register dependencies for DI
            AppContainer.RegisterDependencies();

            //initial viewmodel to be loaded
            // RegisterAppStart<ViewModels.ProvisioningViewModel>();
            RegisterCustomAppStart<CoreAppStart>();
        }

    }
}

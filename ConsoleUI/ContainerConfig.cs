using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        //Our Factory or atleast Acts like one
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //TOP DOWN DEPENDENCIES Program.cs DOWN to DemoLibrary

            builder.RegisterType<Application>().As<IApplication>();
            //tell builder to REGISTER!!!! (if not you get a Error!) differnt pieces of applications
            //TESTING D.I. Must change in CONTAINER TOO!!!
            builder.RegisterType<BetterBizLogic>().As<IBusinessLogic>();

            //These 2 Code Segments are the EXACT SAME but we are doing it for everyclass in the Utilites Folder!

            //using Demolibrary its strongly typed and powerful
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))              //REgister all the classes in Utilites Folder
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            //Link or match the classes with the Interface it belongs to. Using 


            return builder.Build();
        }
    }
}

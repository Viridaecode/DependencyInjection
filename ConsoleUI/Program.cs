using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ConsoleUI
{
    class Program //highlevel object
    {
        //TO TEST DEPENDENCY INJECTION TRY ADDING A CLASS THEN Have it Implement an Interface, then change its constructer(interface Createdobject, Interface CreatedData)
        //Loosy Coupled
        //Only things that change is Contructor() and Old Class that WAS implemented by that Interface HAHAH! YES!!!

        static void Main(string[] args)
        {   
            //Wire up your container Creates instances or Factory Check Container Class
            // newing up instances in Container, Don't Put them in static classes!

            var container = ContainerConfig.Configure();

            //Standard uses for Dependency injection got BeginLifetimeScope
            using (var scope = container.BeginLifetimeScope())
            {
                //using scope object to Give IAPPLICATION Manually
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}

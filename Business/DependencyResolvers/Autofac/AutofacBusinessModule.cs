using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VeterinaryClinicManager>().As<IVeterinaryClinicService>();
            builder.RegisterType<EfVeterinaryClinicDal>().As<IVeterinaryClinicDal>();

            builder.RegisterType<VetManager>().As<IVetService>();
            builder.RegisterType<EfVetDal>().As<IVetDal>();

            builder.RegisterType<PetOwnerManager>().As<IPetOwnerService>();
            builder.RegisterType<EfPetOwnerDal>().As<IPetOwnerDal>();

            builder.RegisterType<PetManager>().As<IPetService>();
            builder.RegisterType<EfPetDal>().As<IPetDal>();

            builder.RegisterType<ExaminationManager>().As<IExaminationService>();
            builder.RegisterType<EfExaminationDal>().As<IExaminationDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

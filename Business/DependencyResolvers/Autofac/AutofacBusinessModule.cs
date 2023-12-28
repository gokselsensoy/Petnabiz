using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.JWT;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
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

            builder.RegisterType<PetManager>().As<IPetService>();
            builder.RegisterType<EfPetDal>().As<IPetDal>();

            builder.RegisterType<ExaminationManager>().As<IExaminationService>();
            builder.RegisterType<EfExaminationDal>().As<IExaminationDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

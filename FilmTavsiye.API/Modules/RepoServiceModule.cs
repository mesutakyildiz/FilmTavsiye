using Autofac;
using FilmTavsiye.Core.Repositories;
using FilmTavsiye.Core.Service;
using FilmTavsiye.Core.Services;
using FilmTavsiye.Core.UnitOfWork;
using FilmTavsiye.Repository;
using FilmTavsiye.Repository.Repositories;
using FilmTavsiye.Service;
using FilmTavsiye.Service.Configurations;
using FilmTavsiye.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace FilmTavsiye.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ServiceGeneric<,>)).As(typeof(IServiceGeneric<,>)).InstancePerLifetimeScope();
          

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<MailSettings>().As<MailSettings>();

            var APIAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(DtoMapper));


            builder.RegisterAssemblyTypes(APIAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(APIAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}

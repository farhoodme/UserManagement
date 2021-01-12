using Autofac;
using AutoMapper;
using UserManagement.EntityFrameworkCore;
using UserManagement.Repositories;
using UserManagement.Services;
using UserManagement.Users;

namespace UserManagement
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().AsSelf().SingleInstance();

            var dataAssembly = typeof(UserDbContext).Assembly;
            var mapperAssembly = typeof(ApplicationAutoMapperProfile).Assembly;

            builder.RegisterAssemblyTypes(dataAssembly).AsSelf().SingleInstance();

            builder.Register(context =>
            {
                var config = new MapperConfiguration(x =>
                {
                    x.AddProfile(typeof(ApplicationAutoMapperProfile));
                });

                return config;
            }).SingleInstance()
            .AutoActivate()
            .AsSelf();

            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();
                return config.CreateMapper();
            }).As<IMapper>();
        }
    }
}

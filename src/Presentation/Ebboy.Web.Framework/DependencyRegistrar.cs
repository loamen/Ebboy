using Autofac;
using Autofac.Integration.Mvc;
using Ebboy.Core;
using Ebboy.Core.Caching;
using Ebboy.Core.Data;
using Ebboy.Core.Domain.Security;
using Ebboy.Core.Infrastructure;
using Ebboy.Core.Infrastructure.DependencyManagement;
using Ebboy.Data;
using Ebboy.Services.Installation;
using Ebboy.Services.Logs;
using Ebboy.Services.Regions;
using Ebboy.Services.Security;
using Ebboy.Services.Users;
using System.Linq;
using System.Web;

namespace Ebboy.Web.Framework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Framework 依赖注入
        /// </summary>
        /// <param name="builder"></param>
        /// 创 建 者：Loamen.com
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //注入WorkContext
            builder.RegisterType<WebWorkContext>().As<IWorkContext>();

            //HTTP context
            if (HttpContext.Current != null)
            {
                builder.Register(c =>
                    (new HttpContextWrapper(HttpContext.Current) as HttpContextBase))
                    .As<HttpContextBase>()
                    .InstancePerLifetimeScope();
            }
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //EncryptionService
            var parameter = new NamedParameter("securitySettings", new SecuritySettings { EncryptionKey = "25126848FE0144F4A0E04D82066F25B7" });
            builder.RegisterType<EncryptionService>().As<IEncryptionService>().WithParameter(parameter).InstancePerLifetimeScope();

            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //data
            builder.RegisterType<DataContext>().As<IDbContext>().InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryService<>)).As(typeof(IRepository<>));

            //install
            builder.RegisterType<CodeFirstInstallationService>().As<IInstallationService>().InstancePerLifetimeScope();

            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("bangbang_cache_static").SingleInstance();
            //builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("bangbang_cache_per_request").InstancePerHttpRequest();

            //WebHelper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();


            #region services
            //用户
            builder.RegisterType<MemberService>().As<IMemberService>().InstancePerLifetimeScope();

            //地区 
            builder.RegisterType<ProvinceCityService>().As<IProvinceCityService>().InstancePerLifetimeScope();

            //日志
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();
            #endregion
        }
        public int Order
        {
            get { return 0; }
        }
    }
}

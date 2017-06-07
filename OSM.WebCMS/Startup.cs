using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OSM.WebCMS.Mapping;
using Microsoft.EntityFrameworkCore;
using Autofac;
using OSM.Data;
using OSM.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OSM.Service;
using OSM.Data.Infrastructure;
using OSM.Data.Repositories;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;

namespace OSM_WebCMS
{
    public class Startup
    {

        private static string _applicationPath = string.Empty;

        private string sqlConnectionString = string.Empty;

        private bool useInMemoryProvider = false;

        // Using Autofac
        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) { 
            try
            {
                string sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    useInMemoryProvider = bool.Parse(Configuration["AppSettings:InMemoryProvider"]);
                }
                catch { }

                services.AddDbContext<AppsDbContext>(options =>
                {
                    switch (useInMemoryProvider)
                    {
                        case true:
                            options.UseInMemoryDatabase();
                            break;

                        default:
                            options.UseSqlServer(sqlConnectionString,
                        b => b.MigrationsAssembly("OSM.Data"));
                            break;
                    }
                });

                // HTTPS Protocol

                //services.Configure<MvcOptions>(options =>
                //{
                //    options.Filters.Add(new RequireHttpsAttribute());
                //});

                // Register all Repositories

                //Enabling Cross-Origin Requests
                services.AddCors();


                AutoMapperConfiguration.Configuration();

                // ASP.NET Core docs for Autofac are here:
                // http://autofac.readthedocs.io/en/latest/integration/aspnetcore.html

                // Add Identity Framework
                services.AddIdentity<ApplicationUser, IdentityRole>()
                        .AddEntityFrameworkStores<AppsDbContext>()
                        .AddDefaultTokenProviders();

                services.AddScoped<SignInManager<ApplicationUser>, SignInManager<ApplicationUser>>();

                // Hung Ly - Controller as Services Add framework services.
                services.AddMvc();//.AddControllersAsServices();

                //services.AddAutoMapper();

                services.AddSingleton<IUnitOfWork, UnitOfWork>();

                // Add application services for IEmail & ISmsSender
                services.AddTransient<IEmailSender, AuthMessageSender>();
                services.AddTransient<ISmsSender, AuthMessageSender>();

                // Create the Autofac container builder.
                var builder = new ContainerBuilder();

                //builder.RegisterControllers(Assembly.GetExecutingAssembly());
                builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly());

                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

                builder.RegisterType<AppsDbContext>().AsSelf().InstancePerRequest();

                // Repositories
                builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).GetTypeInfo().Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();

                // Services
                builder.RegisterAssemblyTypes(typeof(PostCategoryService).GetTypeInfo().Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

               // Autofac.IContainer container = builder.Build();
               // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

                //Set the WebApi DependencyResolver
                //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

                // Populate the services.
                builder.Populate(services);        
 
                // Build the container.
                ApplicationContainer = builder.Build();

                // Create and return the service provider.
                return new AutofacServiceProvider(ApplicationContainer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AppsDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
            SeedData.Initialize(context);
        }
    }
}

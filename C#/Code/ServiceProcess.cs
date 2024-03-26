using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace C_.Code
{
    /// <summary>
    /// Microsoft.Extensions.Hosting (8.0.0)
    /// DI(dependency injection)
    /// </summary>
    internal class ServiceProcess
    {
        public void F(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.TryAddSingleton<IAlpha, A>();
            builder.Services.TryAddSingleton<IAlpha, B>(); //same interface no add

            using IHost host = builder.Build();

            IAlpha al = host.Services.GetService<IAlpha>(); //A
            al.Run();
        }
        public void F2(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddSingleton<IAlpha, A>();
            builder.Services.AddSingleton<IAlpha, B>(); //last add IAlpha

            using IHost host = builder.Build();

            IAlpha al = host.Services.GetService<IAlpha>(); //B
            al.Run();
        }

        interface IAlpha
        {
            void Run();
        }

        class A : IAlpha
        {
            public void Run() => throw new NotImplementedException();
        }
        class B : IAlpha
        {
            public void Run() => throw new NotImplementedException();
        }
    }
}

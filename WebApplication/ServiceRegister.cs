using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application;
using Shop.Database.Repositories;

namespace WebApplication
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes.Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }
            
            // TODO: interfaces!
            @this.AddTransient<ProductRepository>();
            @this.AddTransient<RatingRepository>();
            @this.AddTransient<FileRepository>();
            @this.AddTransient<ProducerRepository>();

            return @this;
        }
    }
}
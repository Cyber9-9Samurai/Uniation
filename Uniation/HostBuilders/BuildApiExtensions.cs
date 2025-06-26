using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uniation.Helpers;
using Refit;
using Uniation.Models;

namespace Uniation.HostBuilders;

public static class BuildApiExtensions
{
    public static IHostBuilder BuildApi(this IHostBuilder builder)
    {

        builder.ConfigureServices((context,services) =>
        {
            services.AddSingleton<ApiService>();
            services.AddRefitClient<IJsonPlaceholderApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri("http://api-sdr.itlabs.top"));
        });
        return builder;
    }
}
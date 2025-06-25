using Microsoft.Extensions.Hosting;

namespace Uniation.HostBuilders;

public static class BuildApiExtensions
{
    public static IHostBuilder BuildApi(this IHostBuilder builder)
    {

        builder.ConfigureServices((context,services) =>
        {
            
        });
        return builder;
    }
}
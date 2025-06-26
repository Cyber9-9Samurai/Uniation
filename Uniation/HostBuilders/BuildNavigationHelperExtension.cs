using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniation.Helpers;

namespace Uniation.HostBuilders
{
    public static class BuildNavigationHelperExtension
    {
        public static IHostBuilder BuildNavigationHelper(this IHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<NavigationHelper>();
            });

            return builder;
        }
    }
}

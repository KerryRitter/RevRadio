﻿using Microsoft.Extensions.DependencyInjection;
using RevRadio.Data.Interfaces;

namespace RevRadio.Data
{
    public static class DependencyModule
    {
        public static void AddRevRadioDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbDapperContextFactory, DbDapperContextFactory>();

            services.AddTransient<IUserService, UserService>();
        }
    }
}

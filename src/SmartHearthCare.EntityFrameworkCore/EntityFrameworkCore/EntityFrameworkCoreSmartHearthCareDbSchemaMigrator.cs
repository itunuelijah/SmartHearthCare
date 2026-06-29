using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartHearthCare.Data;
using Volo.Abp.DependencyInjection;

namespace SmartHearthCare.EntityFrameworkCore;

public class EntityFrameworkCoreSmartHearthCareDbSchemaMigrator
    : ISmartHearthCareDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSmartHearthCareDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SmartHearthCareDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SmartHearthCareDbContext>()
            .Database
            .MigrateAsync();
    }
}

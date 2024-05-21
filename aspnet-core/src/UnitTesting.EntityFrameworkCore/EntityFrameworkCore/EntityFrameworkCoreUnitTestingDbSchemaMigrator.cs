using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitTesting.Data;
using Volo.Abp.DependencyInjection;

namespace UnitTesting.EntityFrameworkCore;

public class EntityFrameworkCoreUnitTestingDbSchemaMigrator
    : IUnitTestingDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreUnitTestingDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the UnitTestingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<UnitTestingDbContext>()
            .Database
            .MigrateAsync();
    }
}

using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace UnitTesting.Data;

/* This is used if database provider does't define
 * IUnitTestingDbSchemaMigrator implementation.
 */
public class NullUnitTestingDbSchemaMigrator : IUnitTestingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

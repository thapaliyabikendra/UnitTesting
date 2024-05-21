using System.Threading.Tasks;

namespace UnitTesting.Data;

public interface IUnitTestingDbSchemaMigrator
{
    Task MigrateAsync();
}

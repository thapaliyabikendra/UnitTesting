using UnitTesting.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace UnitTesting.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(UnitTestingEntityFrameworkCoreModule),
    typeof(UnitTestingApplicationContractsModule)
    )]
public class UnitTestingDbMigratorModule : AbpModule
{
}

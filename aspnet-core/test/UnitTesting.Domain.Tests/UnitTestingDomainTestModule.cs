using Volo.Abp.Modularity;

namespace UnitTesting;

[DependsOn(
    typeof(UnitTestingDomainModule),
    typeof(UnitTestingTestBaseModule)
)]
public class UnitTestingDomainTestModule : AbpModule
{

}

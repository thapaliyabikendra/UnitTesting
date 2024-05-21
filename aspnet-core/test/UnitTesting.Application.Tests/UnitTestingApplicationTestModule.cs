using Volo.Abp.Modularity;

namespace UnitTesting;

[DependsOn(
    typeof(UnitTestingApplicationModule),
    typeof(UnitTestingDomainTestModule)
)]
public class UnitTestingApplicationTestModule : AbpModule
{

}

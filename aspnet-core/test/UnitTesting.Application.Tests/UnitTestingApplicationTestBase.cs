using Volo.Abp.Modularity;

namespace UnitTesting;

public abstract class UnitTestingApplicationTestBase<TStartupModule> : UnitTestingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

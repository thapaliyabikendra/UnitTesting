using Volo.Abp.Modularity;

namespace UnitTesting;

/* Inherit from this class for your domain layer tests. */
public abstract class UnitTestingDomainTestBase<TStartupModule> : UnitTestingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

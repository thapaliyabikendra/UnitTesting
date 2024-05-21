using UnitTesting.Samples;
using Xunit;

namespace UnitTesting.EntityFrameworkCore.Domains;

[Collection(UnitTestingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<UnitTestingEntityFrameworkCoreTestModule>
{

}

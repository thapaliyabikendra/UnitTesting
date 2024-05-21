using UnitTesting.Samples;
using Xunit;

namespace UnitTesting.EntityFrameworkCore.Applications;

[Collection(UnitTestingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<UnitTestingEntityFrameworkCoreTestModule>
{

}

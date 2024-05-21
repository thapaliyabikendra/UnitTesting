using UnitTesting.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace UnitTesting.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class UnitTestingController : AbpControllerBase
{
    protected UnitTestingController()
    {
        LocalizationResource = typeof(UnitTestingResource);
    }
}

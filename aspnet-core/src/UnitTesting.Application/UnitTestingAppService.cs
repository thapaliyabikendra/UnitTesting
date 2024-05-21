using System;
using System.Collections.Generic;
using System.Text;
using UnitTesting.Localization;
using Volo.Abp.Application.Services;

namespace UnitTesting;

/* Inherit your application services from this class.
 */
public abstract class UnitTestingAppService : ApplicationService
{
    protected UnitTestingAppService()
    {
        LocalizationResource = typeof(UnitTestingResource);
    }
}

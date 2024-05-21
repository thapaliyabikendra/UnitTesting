using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace UnitTesting;

[Dependency(ReplaceServices = true)]
public class UnitTestingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UnitTesting";
}

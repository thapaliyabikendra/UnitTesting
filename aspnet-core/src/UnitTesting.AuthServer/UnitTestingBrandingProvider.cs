using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace UnitTesting;

[Dependency(ReplaceServices = true)]
public class UnitTestingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "UnitTesting";
}

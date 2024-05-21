using Volo.Abp.Settings;

namespace UnitTesting.Settings;

public class UnitTestingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(UnitTestingSettings.MySetting1));
    }
}

using UnitTesting.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace UnitTesting.Permissions;

public class UnitTestingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(UnitTestingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(UnitTestingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<UnitTestingResource>(name);
    }
}

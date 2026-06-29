using SmartHearthCare.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SmartHearthCare.Permissions;

public class SmartHearthCarePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SmartHearthCarePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SmartHearthCarePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SmartHearthCareResource>(name);
    }
}

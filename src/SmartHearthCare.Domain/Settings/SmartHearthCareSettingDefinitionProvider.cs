using Volo.Abp.Settings;

namespace SmartHearthCare.Settings;

public class SmartHearthCareSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SmartHearthCareSettings.MySetting1));
    }
}

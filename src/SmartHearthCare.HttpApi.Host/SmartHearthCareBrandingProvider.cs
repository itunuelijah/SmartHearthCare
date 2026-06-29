using Microsoft.Extensions.Localization;
using SmartHearthCare.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SmartHearthCare;

[Dependency(ReplaceServices = true)]
public class SmartHearthCareBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SmartHearthCareResource> _localizer;

    public SmartHearthCareBrandingProvider(IStringLocalizer<SmartHearthCareResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

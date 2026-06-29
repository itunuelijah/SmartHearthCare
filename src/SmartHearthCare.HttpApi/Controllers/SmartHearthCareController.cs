using SmartHearthCare.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SmartHearthCare.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SmartHearthCareController : AbpControllerBase
{
    protected SmartHearthCareController()
    {
        LocalizationResource = typeof(SmartHearthCareResource);
    }
}

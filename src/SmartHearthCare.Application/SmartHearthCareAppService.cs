using System;
using System.Collections.Generic;
using System.Text;
using SmartHearthCare.Localization;
using Volo.Abp.Application.Services;

namespace SmartHearthCare;

/* Inherit your application services from this class.
 */
public abstract class SmartHearthCareAppService : ApplicationService
{
    protected SmartHearthCareAppService()
    {
        LocalizationResource = typeof(SmartHearthCareResource);
    }
}

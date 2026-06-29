using Volo.Abp.Modularity;

namespace SmartHearthCare;

[DependsOn(
    typeof(SmartHearthCareApplicationModule),
    typeof(SmartHearthCareDomainTestModule)
)]
public class SmartHearthCareApplicationTestModule : AbpModule
{

}

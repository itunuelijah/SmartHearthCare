using Volo.Abp.Modularity;

namespace SmartHearthCare;

[DependsOn(
    typeof(SmartHearthCareDomainModule),
    typeof(SmartHearthCareTestBaseModule)
)]
public class SmartHearthCareDomainTestModule : AbpModule
{

}

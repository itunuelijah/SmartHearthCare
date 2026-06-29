using Volo.Abp.Modularity;

namespace SmartHearthCare;

public abstract class SmartHearthCareApplicationTestBase<TStartupModule> : SmartHearthCareTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

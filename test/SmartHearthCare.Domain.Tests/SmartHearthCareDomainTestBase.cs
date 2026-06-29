using Volo.Abp.Modularity;

namespace SmartHearthCare;

/* Inherit from this class for your domain layer tests. */
public abstract class SmartHearthCareDomainTestBase<TStartupModule> : SmartHearthCareTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

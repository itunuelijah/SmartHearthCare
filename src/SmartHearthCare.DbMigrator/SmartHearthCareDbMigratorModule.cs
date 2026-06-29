using SmartHearthCare.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SmartHearthCare.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SmartHearthCareEntityFrameworkCoreModule),
    typeof(SmartHearthCareApplicationContractsModule)
    )]
public class SmartHearthCareDbMigratorModule : AbpModule
{
}

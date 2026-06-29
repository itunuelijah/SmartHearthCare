using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SmartHearthCare.Data;

/* This is used if database provider does't define
 * ISmartHearthCareDbSchemaMigrator implementation.
 */
public class NullSmartHearthCareDbSchemaMigrator : ISmartHearthCareDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

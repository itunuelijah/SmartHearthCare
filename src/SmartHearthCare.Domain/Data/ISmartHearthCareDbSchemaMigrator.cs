using System.Threading.Tasks;

namespace SmartHearthCare.Data;

public interface ISmartHearthCareDbSchemaMigrator
{
    Task MigrateAsync();
}

using Xunit;

namespace SmartHearthCare.EntityFrameworkCore;

[CollectionDefinition(SmartHearthCareTestConsts.CollectionDefinitionName)]
public class SmartHearthCareEntityFrameworkCoreCollection : ICollectionFixture<SmartHearthCareEntityFrameworkCoreFixture>
{

}

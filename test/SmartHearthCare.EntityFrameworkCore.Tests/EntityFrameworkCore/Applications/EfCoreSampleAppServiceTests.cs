using SmartHearthCare.Samples;
using Xunit;

namespace SmartHearthCare.EntityFrameworkCore.Applications;

[Collection(SmartHearthCareTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SmartHearthCareEntityFrameworkCoreTestModule>
{

}

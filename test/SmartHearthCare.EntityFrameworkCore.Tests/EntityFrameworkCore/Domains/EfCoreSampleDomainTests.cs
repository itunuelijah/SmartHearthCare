using SmartHearthCare.Samples;
using Xunit;

namespace SmartHearthCare.EntityFrameworkCore.Domains;

[Collection(SmartHearthCareTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SmartHearthCareEntityFrameworkCoreTestModule>
{

}

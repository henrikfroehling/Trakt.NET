namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class TraktPersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPersonIdsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPersonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPersonIds>));
        }
    }
}

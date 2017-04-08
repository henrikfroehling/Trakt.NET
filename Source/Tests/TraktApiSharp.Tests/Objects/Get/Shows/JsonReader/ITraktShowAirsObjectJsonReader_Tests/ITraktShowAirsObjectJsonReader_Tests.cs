namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ITraktShowAirsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowAirsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowAirsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktShowAirs>));
        }
    }
}

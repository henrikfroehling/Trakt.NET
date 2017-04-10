namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class IITraktShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktShow>));
        }
    }
}

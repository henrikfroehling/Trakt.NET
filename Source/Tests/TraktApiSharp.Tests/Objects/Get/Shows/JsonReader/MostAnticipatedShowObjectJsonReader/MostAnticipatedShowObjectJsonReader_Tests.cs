namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class MostAnticipatedShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_MostAnticipatedShowObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(MostAnticipatedShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktMostAnticipatedShow>));
        }
    }
}

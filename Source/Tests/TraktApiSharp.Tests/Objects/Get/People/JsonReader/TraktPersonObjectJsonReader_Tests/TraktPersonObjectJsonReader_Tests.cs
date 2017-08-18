namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class TraktPersonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktPersonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktPersonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPerson>));
        }
    }
}

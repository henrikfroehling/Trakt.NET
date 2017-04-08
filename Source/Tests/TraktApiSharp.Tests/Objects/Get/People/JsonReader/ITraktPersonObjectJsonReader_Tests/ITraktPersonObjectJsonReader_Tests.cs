namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class ITraktPersonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktPersonObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktPersonObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktPerson>));
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PersonIdsObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PersonIdsObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPersonIds>));
        }
    }
}

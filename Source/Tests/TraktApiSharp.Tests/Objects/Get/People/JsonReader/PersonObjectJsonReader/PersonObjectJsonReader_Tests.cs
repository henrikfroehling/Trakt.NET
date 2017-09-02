namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.People.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.JsonReader")]
    public partial class PersonObjectJsonReader_Tests
    {
        [Fact]
        public void Test_PersonObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(PersonObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktPerson>));
        }
    }
}

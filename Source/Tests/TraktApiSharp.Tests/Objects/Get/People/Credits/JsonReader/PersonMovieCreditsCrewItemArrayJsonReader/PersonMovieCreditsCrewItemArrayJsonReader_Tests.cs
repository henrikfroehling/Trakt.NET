namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCrewItemArrayJsonReader_Tests
    {
        [Fact]
        public void Test_PersonMovieCreditsCrewItemArrayJsonReader_Implements_IArrayJsonReader_Interface()
        {
            typeof(PersonMovieCreditsCrewItemArrayJsonReader).GetInterfaces().Should().Contain(typeof(IArrayJsonReader<ITraktPersonMovieCreditsCrewItem>));
        }
    }
}

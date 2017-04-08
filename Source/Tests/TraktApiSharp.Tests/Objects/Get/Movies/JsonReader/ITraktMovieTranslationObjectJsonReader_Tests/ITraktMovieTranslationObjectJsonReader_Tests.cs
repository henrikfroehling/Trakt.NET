namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class ITraktMovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMovieTranslationObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMovieTranslationObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMovieTranslation>));
        }
    }
}

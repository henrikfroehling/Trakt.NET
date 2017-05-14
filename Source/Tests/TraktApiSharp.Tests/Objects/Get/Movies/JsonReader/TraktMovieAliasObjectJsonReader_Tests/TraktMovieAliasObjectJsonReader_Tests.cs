namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class TraktMovieAliasObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktMovieAliasObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktMovieAliasObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMovieAlias>));
        }
    }
}

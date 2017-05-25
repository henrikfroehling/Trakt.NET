namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class TraktWatchedMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktWatchedMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktWatchedMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktWatchedMovie>));
        }
    }
}

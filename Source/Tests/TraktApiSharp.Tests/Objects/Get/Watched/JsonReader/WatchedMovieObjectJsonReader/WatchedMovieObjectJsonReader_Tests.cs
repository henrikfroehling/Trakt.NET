namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchedMovieObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(WatchedMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktWatchedMovie>));
        }
    }
}

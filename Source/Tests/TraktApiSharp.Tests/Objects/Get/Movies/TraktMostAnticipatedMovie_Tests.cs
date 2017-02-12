namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using Xunit;

    [Category("Objects.Get.Movies")]
    public class TraktMostAnticipatedMovie_Tests
    {
        [Fact]
        public void Test_TraktMostAnticipatedMovie_Implements_ITraktMostAnticipatedMovie_Interface()
        {
            typeof(TraktMostAnticipatedMovie).GetInterfaces().Should().Contain(typeof(ITraktMostAnticipatedMovie));
        }
    }
}

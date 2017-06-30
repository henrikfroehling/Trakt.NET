namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Interfaces")]
    public class ITraktMovieCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktMovieCheckinPostResponse_Is_Interface()
        {
            typeof(ITraktMovieCheckinPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieCheckinPostResponse_Inherits_ITraktCheckinPostResponse_Interface()
        {
            typeof(ITraktMovieCheckinPostResponse).GetInterfaces().Should().Contain(typeof(ITraktCheckinPostResponse));
        }

        [Fact]
        public void Test_ITraktMovieCheckinPostResponse_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktMovieCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}

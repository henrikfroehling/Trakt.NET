namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.Interfaces")]
    public class ITraktMovieScrobblePostResponse_Tests
    {
        [Fact]
        public void Test_ITraktMovieScrobblePostResponse_Is_Interface()
        {
            typeof(ITraktMovieScrobblePostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieScrobblePostResponse_Inherits_ITraktScrobblePostResponse_Interface()
        {
            typeof(ITraktMovieScrobblePostResponse).GetInterfaces().Should().Contain(typeof(ITraktScrobblePostResponse));
        }

        [Fact]
        public void Test_ITraktMovieScrobblePostResponse_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktMovieScrobblePostResponse).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}

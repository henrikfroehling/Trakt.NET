namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Movies;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class MovieWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_MovieWatchingUsersRequest_IsNotAbstract()
        {
            typeof(MovieWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_IsSealed()
        {
            typeof(MovieWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(MovieWatchingUsersRequest).IsSubclassOf(typeof(AMovieRequest<ITraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(MovieWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieWatchingUsersRequest();
            request.UriTemplate.Should().Be("movies/{id}/watching{?extended}");
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MovieWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MovieWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_MovieWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieWatchingUsersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new MovieWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new MovieWatchingUsersRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

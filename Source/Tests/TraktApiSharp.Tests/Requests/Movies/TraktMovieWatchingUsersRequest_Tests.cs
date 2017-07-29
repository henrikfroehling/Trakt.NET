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
    public class TraktMovieWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_IsNotAbstract()
        {
            typeof(TraktMovieWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_IsSealed()
        {
            typeof(TraktMovieWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieWatchingUsersRequest).IsSubclassOf(typeof(ATraktMovieRequest<ITraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktMovieWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieWatchingUsersRequest();
            request.UriTemplate.Should().Be("movies/{id}/watching{?extended}");
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktMovieWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktMovieWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktMovieWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieWatchingUsersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieWatchingUsersRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

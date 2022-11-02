namespace TraktNet.Requests.Tests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Episodes;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [TestCategory("Requests.Episodes")]
    public class EpisodeWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_EpisodeWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}");
        }

        [Fact]
        public void Test_EpisodeWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new EpisodeWatchingUsersRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number / without extended info
            request = new EpisodeWatchingUsersRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["episode"] = "1"
                                                   });

            // -------------------------------------------
            var extendedInfo = new TraktExtendedInfo { Full = true };

            // with implicit season number / with extended info
            request = new EpisodeWatchingUsersRequest { Id = "123", EpisodeNumber = 1, ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(4)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with explicit season number / with extended info
            request = new EpisodeWatchingUsersRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1, ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(4)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["episode"] = "1",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_EpisodeWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeWatchingUsersRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new EpisodeWatchingUsersRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new EpisodeWatchingUsersRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // episode number == 0
            request = new EpisodeWatchingUsersRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

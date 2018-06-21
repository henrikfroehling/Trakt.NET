namespace TraktNet.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Episodes;
    using Xunit;

    [Category("Requests.Episodes")]
    public class EpisodeStatisticsRequest_Tests
    {
        [Fact]
        public void Test_EpisodeStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeStatisticsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/stats");
        }

        [Fact]
        public void Test_EpisodeStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new EpisodeStatisticsRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number
            request = new EpisodeStatisticsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["episode"] = "1"
                                                   });
        }

        [Fact]
        public void Test_EpisodeStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeStatisticsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new EpisodeStatisticsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new EpisodeStatisticsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // episode number == 0
            request = new EpisodeStatisticsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

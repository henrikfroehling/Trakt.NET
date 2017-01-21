namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeStatisticsRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeStatisticsRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeStatisticsRequest_IsSealed()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeStatisticsRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSubclassOf(typeof(ATraktEpisodeRequest<TraktStatistics>)).Should().BeTrue();
        }
        
        [Fact]
        public void Test_TraktEpisodeStatisticsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeStatisticsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/stats");
        }
        
        [Fact]
        public void Test_TraktEpisodeStatisticsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new TraktEpisodeStatisticsRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number
            request = new TraktEpisodeStatisticsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
        public void Test_TraktEpisodeStatisticsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeStatisticsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeStatisticsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeStatisticsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeStatisticsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

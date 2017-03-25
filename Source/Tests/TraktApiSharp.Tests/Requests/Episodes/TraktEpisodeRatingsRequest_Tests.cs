namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Requests.Episodes;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeRatingsRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeRatingsRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeRatingsRequest_IsSealed()
        {
            typeof(TraktEpisodeRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeRatingsRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeRatingsRequest).IsSubclassOf(typeof(ATraktEpisodeRequest<TraktRating>)).Should().BeTrue();
        }
        
        [Fact]
        public void Test_TraktEpisodeRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/ratings");
        }
        
        [Fact]
        public void Test_TraktEpisodeRatingsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new TraktEpisodeRatingsRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });
            
            // with explicit season number
            request = new TraktEpisodeRatingsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
        public void Test_TraktEpisodeRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeRatingsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeRatingsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeRatingsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeRatingsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

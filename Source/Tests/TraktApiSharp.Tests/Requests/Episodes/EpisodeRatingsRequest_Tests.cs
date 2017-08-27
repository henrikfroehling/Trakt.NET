namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Episodes;
    using Xunit;

    [Category("Requests.Episodes")]
    public class EpisodeRatingsRequest_Tests
    {
        [Fact]
        public void Test_EpisodeRatingsRequest_IsNotAbstract()
        {
            typeof(EpisodeRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_EpisodeRatingsRequest_IsSealed()
        {
            typeof(EpisodeRatingsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeRatingsRequest_Inherits_AEpisodeRequest_1()
        {
            typeof(EpisodeRatingsRequest).IsSubclassOf(typeof(AEpisodeRequest<ITraktRating>)).Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeRatingsRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeRatingsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/ratings");
        }

        [Fact]
        public void Test_EpisodeRatingsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var request = new EpisodeRatingsRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number
            request = new EpisodeRatingsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
        public void Test_EpisodeRatingsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeRatingsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new EpisodeRatingsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new EpisodeRatingsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new EpisodeRatingsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

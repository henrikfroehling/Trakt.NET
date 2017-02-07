namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeSummaryRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeSummaryRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeSummaryRequest_IsSealed()
        {
            typeof(TraktEpisodeSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeSummaryRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeSummaryRequest).IsSubclassOf(typeof(ATraktEpisodeRequest<TraktEpisode>)).Should().BeTrue();
        }
        
        [Fact]
        public void Test_TraktEpisodeSummaryRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktEpisodeSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }
        
        [Fact]
        public void Test_TraktEpisodeSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeSummaryRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}{?extended}");
        }
        
        [Fact]
        public void Test_TraktEpisodeSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new TraktEpisodeSummaryRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number / without extended info
            request = new TraktEpisodeSummaryRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
            request = new TraktEpisodeSummaryRequest { Id = "123", EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
            request = new TraktEpisodeSummaryRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
        public void Test_TraktEpisodeSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeSummaryRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeSummaryRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeSummaryRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeSummaryRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

﻿namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Episodes")]
    public class EpisodeSummaryRequest_Tests
    {
        [Fact]
        public void Test_EpisodeSummaryRequest_IsNotAbstract()
        {
            typeof(EpisodeSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_EpisodeSummaryRequest_IsSealed()
        {
            typeof(EpisodeSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeSummaryRequest_Inherits_AEpisodeRequest_1()
        {
            typeof(EpisodeSummaryRequest).IsSubclassOf(typeof(AEpisodeRequest<ITraktEpisode>)).Should().BeTrue();
        }

        [Fact]
        public void Test_EpisodeSummaryRequest_Implements_ISupportsExtendedInfo_Interface()
        {
            typeof(EpisodeSummaryRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_EpisodeSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeSummaryRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}{?extended}");
        }

        [Fact]
        public void Test_EpisodeSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new EpisodeSummaryRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number / without extended info
            request = new EpisodeSummaryRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
            request = new EpisodeSummaryRequest { Id = "123", EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
            request = new EpisodeSummaryRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
        public void Test_EpisodeSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeSummaryRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new EpisodeSummaryRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new EpisodeSummaryRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new EpisodeSummaryRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
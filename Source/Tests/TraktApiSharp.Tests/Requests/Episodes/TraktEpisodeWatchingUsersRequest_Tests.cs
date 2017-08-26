namespace TraktApiSharp.Tests.Requests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Episodes;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using Xunit;

    [Category("Requests.Episodes")]
    public class TraktEpisodeWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_IsNotAbstract()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_IsSealed()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_Inherits_ATraktEpisodeRequest_1()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsSubclassOf(typeof(AEpisodeRequest<ITraktUser>)).Should().BeTrue();
        }
        
        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktEpisodeWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }
        
        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktEpisodeWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/watching{?extended}");
        }
        
        [Fact]
        public void Test_TraktEpisodeWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new TraktEpisodeWatchingUsersRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number / without extended info
            request = new TraktEpisodeWatchingUsersRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

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
            request = new TraktEpisodeWatchingUsersRequest { Id = "123", EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
            request = new TraktEpisodeWatchingUsersRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1, ExtendedInfo = extendedInfo };

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
        public void Test_TraktEpisodeWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktEpisodeWatchingUsersRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktEpisodeWatchingUsersRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktEpisodeWatchingUsersRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // episode number == 0
            request = new TraktEpisodeWatchingUsersRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

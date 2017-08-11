namespace TraktApiSharp.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class TraktSeasonWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_IsNotAbstract()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_IsSealed()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_Inherits_ATraktSeasonRequest_1()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSubclassOf(typeof(ATraktSeasonRequest<ITraktUser>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(TraktSeasonWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSeasonWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/watching{?extended}");
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new TraktSeasonWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number / without extended info
            request = new TraktSeasonWatchingUsersRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });

            // -------------------------------------------
            var extendedInfo = new TraktExtendedInfo { Full = true };

            // with implicit season number / with extended info
            request = new TraktSeasonWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with explicit season number / with extended info
            request = new TraktSeasonWatchingUsersRequest { Id = "123", SeasonNumber = 2, ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktSeasonWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktSeasonWatchingUsersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktSeasonWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktSeasonWatchingUsersRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

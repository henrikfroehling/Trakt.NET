namespace TraktNet.Tests.Requests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class SeasonWatchingUsersRequest_Tests
    {
        [Fact]
        public void Test_SeasonWatchingUsersRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonWatchingUsersRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/watching{?extended}");
        }

        [Fact]
        public void Test_SeasonWatchingUsersRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without extended info
            var request = new SeasonWatchingUsersRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number / without extended info
            request = new SeasonWatchingUsersRequest { Id = "123", SeasonNumber = 2 };

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
            request = new SeasonWatchingUsersRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with explicit season number / with extended info
            request = new SeasonWatchingUsersRequest { Id = "123", SeasonNumber = 2, ExtendedInfo = extendedInfo };

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
        public void Test_SeasonWatchingUsersRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonWatchingUsersRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new SeasonWatchingUsersRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new SeasonWatchingUsersRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

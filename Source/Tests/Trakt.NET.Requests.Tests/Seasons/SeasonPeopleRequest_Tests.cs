namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [TestCategory("Requests.Seasons")]
    public class SeasonPeopleRequest_Tests
    {
        [Fact]
        public void Test_SeasonPeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonPeopleRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/people{?extended}");
        }

        [Fact]
        public void Test_SeasonPeopleRequest_Returns_Valid_UriPathParameters()
        {

            // with implicit season number / without extended info
            var request = new SeasonPeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number / without extended info
            request = new SeasonPeopleRequest { Id = "123", SeasonNumber = 2 };

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
            request = new SeasonPeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });

            // with explicit season number / with extended info
            request = new SeasonPeopleRequest { Id = "123", SeasonNumber = 2, ExtendedInfo = extendedInfo };

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
        public void Test_SeasonPeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonPeopleRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new SeasonPeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new SeasonPeopleRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

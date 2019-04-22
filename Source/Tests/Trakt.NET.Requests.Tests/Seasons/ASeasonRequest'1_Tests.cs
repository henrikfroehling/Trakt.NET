namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [Category("Requests.Seasons")]
    public class ASeasonRequest_1_Tests
    {
        internal class SeasonRequestMock : ASeasonRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ASeasonRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new SeasonRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ASeasonRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new SeasonRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Seasons);
        }

        [Fact]
        public void Test_ASeasonRequest_1_Returns_Valid_UriPathParameters()
        {
            // with implicit season number
            var requestMock = new SeasonRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "0"
                                                       });

            // with explicit season number
            requestMock = new SeasonRequestMock { Id = "123", SeasonNumber = 2 };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["season"] = "2"
                                                       });
        }

        [Fact]
        public void Test_ASeasonRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new SeasonRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            requestMock = new SeasonRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            requestMock = new SeasonRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

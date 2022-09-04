namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
    public class AListRequest_Tests
    {
        internal class ListRequestMock : AListRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AListRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ListRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AistRequest_Returns_Valid_UriPathParameters()
        {
            var request = new ListRequestMock { Id = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "1"
                                                   });
        }

        [Fact]
        public void Test_AListRequest_Validate_Throws_Exceptions()
        {
            var requestMock = new ListRequestMock { Id = -1 };

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            requestMock = new ListRequestMock { Id = 0 };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

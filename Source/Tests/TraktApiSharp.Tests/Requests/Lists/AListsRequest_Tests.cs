namespace TraktApiSharp.Tests.Requests.Lists
{
    using FluentAssertions;
    using System;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Lists;
    using Xunit;

    [Category("Requests.Lists")]
    public class AListsRequest_Tests
    {
        internal class ListsRequestMock : AListsRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AListsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ListsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AListsRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new ListsRequestMock();
            requestMock.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}

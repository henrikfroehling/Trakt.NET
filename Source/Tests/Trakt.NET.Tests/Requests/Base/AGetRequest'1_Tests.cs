namespace TraktNet.Tests.Requests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Traits;
    using TraktNet.Requests.Base;
    using Xunit;

    [Category("Requests.Base")]
    public class AGetRequest_1_Tests
    {
        internal class GetRequestMock : AGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AGetRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new GetRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AGetRequest_1_Returns_Valid_Method()
        {
            var requestMock = new GetRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Get);
        }
    }
}

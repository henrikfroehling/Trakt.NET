namespace TraktNet.Requests.Tests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using Xunit;

    [TestCategory("Requests.Base")]
    public class ABodylessPostRequest_1_Tests
    {
        internal class BodylessPostRequestMock : ABodylessPostRequest<int>
        {
            public override string UriTemplate => throw new NotImplementedException();
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new BodylessPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Returns_Valid_Method()
        {
            var requestMock = new BodylessPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }
    }
}

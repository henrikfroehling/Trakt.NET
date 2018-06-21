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
    public class ADeleteRequest_Tests
    {
        internal class DeleteRequestMock : ADeleteRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_ADeleteRequest_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new DeleteRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ADeleteRequest_Returns_Valid_Method()
        {
            var requestMock = new DeleteRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Delete);
        }
    }
}

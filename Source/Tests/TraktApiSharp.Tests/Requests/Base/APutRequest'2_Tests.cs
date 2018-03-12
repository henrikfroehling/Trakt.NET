namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Base")]
    public class APutRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public string HttpContentAsString => throw new NotImplementedException();

            public HttpContent ToHttpContent() => throw new NotImplementedException();

            public void Validate() => throw new NotImplementedException();
        }

        internal class PutRequestMock : APutRequest<string, RequestBodyMock>
        {
            public override RequestBodyMock RequestBody { get; set; }
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_APutRequest_2_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new PutRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_APutRequest_2_Returns_Valid_Method()
        {
            var requestMock = new PutRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Put);
        }

        [Fact]
        public void Test_APutRequest_2_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new PutRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();
        }
    }
}

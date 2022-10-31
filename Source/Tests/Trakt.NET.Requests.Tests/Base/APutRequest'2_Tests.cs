namespace TraktNet.Requests.Tests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Base")]
    public class APutRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public Task<string> ToJson(CancellationToken cancellationToken = default(CancellationToken)) => Task.FromResult("");

            public void Validate()
            {
            }
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
        public void Test_APutRequest_2_Validate_Throws_TraktRequestValidationException()
        {
            var requestMock = new PutRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

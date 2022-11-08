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

    [TestCategory("Requests.Base")]
    public class APostRequest_2_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public Task<string> ToJson(CancellationToken cancellationToken = default) => Task.FromResult("");

            public void Validate()
            {
            }
        }

        internal class PostRequestMock : APostRequest<string, RequestBodyMock>
        {
            public override RequestBodyMock RequestBody { get; set; }
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_APostRequest_2_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new PostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_APostRequest_2_Returns_Valid_Method()
        {
            var requestMock = new PostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_APostRequest_2_Validate_Throws_TraktRequestValidationException()
        {
            var requestMock = new PostRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

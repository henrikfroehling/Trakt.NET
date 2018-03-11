namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using Xunit;

    [Category("Requests.Base")]
    public class APutRequest_1_Tests
    {
        internal class PutRequestMock : APutRequest<object>
        {
            public override object RequestBody { get; set; }
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_APutRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new PutRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_APutRequest_1_Returns_Valid_Method()
        {
            var requestMock = new PutRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Put);
        }

        [Fact]
        public void Test_APutRequest_1_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new PutRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();
        }
    }
}

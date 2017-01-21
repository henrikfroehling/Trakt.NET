namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Base")]
    public class ATraktBodylessPostRequest_Tests
    {
        internal class TraktBodylessPostRequestMock : ATraktBodylessPostRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override IDictionary<string, object> GetUriPathParameters()
            {
                throw new NotImplementedException();
            }

            public override void Validate()
            {
                throw new NotImplementedException();
            }
        };

        [Fact]
        public void Test_ATraktBodylessPostRequest_Is_AbstractClass()
        {
            typeof(ATraktBodylessPostRequest).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_Inherits_ATraktRequest()
        {
            typeof(ATraktBodylessPostRequest).IsSubclassOf(typeof(ATraktRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_Implements_ITraktBodylessPostRequest_Interface()
        {
            typeof(ATraktBodylessPostRequest).GetInterfaces().Should().Contain(typeof(ITraktBodylessPostRequest));
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_Returns_Valid_Method()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktBodylessPostRequest).GetProperties()
                                                                .Where(p => p.Name == "Method")
                                                                .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

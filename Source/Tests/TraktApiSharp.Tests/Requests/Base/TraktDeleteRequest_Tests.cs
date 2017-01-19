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
    public class TraktDeleteRequest_Tests
    {
        internal class TraktDeleteRequestMock : TraktDeleteRequest
        {
            public override string UriTemplate => throw new NotImplementedException();

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
        public void Test_TraktDeleteRequest_Is_AbstractClass()
        {
            typeof(TraktDeleteRequest).IsAbstract.Should().BeTrue();
        }
        
        [Fact]
        public void Test_TraktDeleteRequest_Inherits_TraktRequest()
        {
            typeof(TraktDeleteRequest).IsSubclassOf(typeof(TraktRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktDeleteRequest_Implements_ITraktDeleteRequest_Interface()
        {
            typeof(TraktDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktDeleteRequest));
        }

        [Fact]
        public void Test_TraktDeleteRequest_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktDeleteRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktDeleteRequest_Returns_Valid_Method()
        {
            var requestMock = new TraktDeleteRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Delete);
        }

        [Fact]
        public void Test_TraktDeleteRequest_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(TraktDeleteRequest).GetProperties()
                                                         .Where(p => p.Name == "Method")
                                                         .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

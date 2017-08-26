namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces.Base;
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
        public void Test_ADeleteRequest_Is_AbstractClass()
        {
            typeof(ADeleteRequest).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ADeleteRequest_Inherits_ATraktRequest()
        {
            typeof(ADeleteRequest).IsSubclassOf(typeof(ARequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_ADeleteRequest_Implements_ITraktDeleteRequest_Interface()
        {
            typeof(ADeleteRequest).GetInterfaces().Should().Contain(typeof(IDeleteRequest));
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

        [Fact]
        public void Test_ADeleteRequest_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ADeleteRequest).GetProperties()
                                                          .Where(p => p.Name == "Method")
                                                          .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

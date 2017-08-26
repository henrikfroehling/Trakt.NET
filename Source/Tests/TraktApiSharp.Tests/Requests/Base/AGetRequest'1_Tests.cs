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
    public class AGetRequest_1_Tests
    {
        internal class GetRequestMock : AGetRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_AGetRequest_1_Is_AbstractClass()
        {
            typeof(AGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_AGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(AGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(AGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_AGetRequest_1_Inherits_ATraktRequest_1()
        {
            typeof(AGetRequest<int>).IsSubclassOf(typeof(ARequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_AGetRequest_1_Implements_ITraktGetRequest_1_Interface()
        {
            typeof(AGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktGetRequest<int>));
        }

        [Fact]
        public void Test_AGetRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new GetRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AGetRequest_1_Returns_Valid_Method()
        {
            var requestMock = new GetRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void Test_AGetRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(AGetRequest<>).GetProperties()
                                                         .Where(p => p.Name == "Method")
                                                         .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

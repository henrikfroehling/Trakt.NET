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
    public class TraktBodylessPostRequest_1_Tests
    {
        internal class TraktBodylessPostRequestMock : TraktBodylessPostRequest<int>
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
        public void Test_TraktBodylessPostRequest_1_Is_AbstractClass()
        {
            typeof(TraktBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(TraktBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(TraktBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Inherits_TraktRequest_1()
        {
            typeof(TraktBodylessPostRequest<int>).IsSubclassOf(typeof(TraktRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Implements_ITraktBodylessPostRequest_1_Interface()
        {
            typeof(TraktBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktBodylessPostRequest<int>));
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Returns_Valid_Method()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_TraktBodylessPostRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(TraktBodylessPostRequest<>).GetProperties()
                                                                 .Where(p => p.Name == "Method")
                                                                 .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

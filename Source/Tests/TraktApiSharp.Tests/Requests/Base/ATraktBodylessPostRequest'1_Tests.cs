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
    public class ATraktBodylessPostRequest_1_Tests
    {
        internal class TraktBodylessPostRequestMock : ATraktBodylessPostRequest<int>
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
        public void Test_ATraktBodylessPostRequest_1_Is_AbstractClass()
        {
            typeof(ATraktBodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Inherits_ATraktRequest_1()
        {
            typeof(ATraktBodylessPostRequest<int>).IsSubclassOf(typeof(ATraktRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Implements_ITraktBodylessPostRequest_1_Interface()
        {
            typeof(ATraktBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktBodylessPostRequest<int>));
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Returns_Valid_Method()
        {
            var requestMock = new TraktBodylessPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_ATraktBodylessPostRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktBodylessPostRequest<>).GetProperties()
                                                                  .Where(p => p.Name == "Method")
                                                                  .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

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
    public class ATraktGetRequest_1_Tests
    {
        internal class TraktGetRequestMock : ATraktGetRequest<int>
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
        public void Test_ATraktGetRequest_1_Is_AbstractClass()
        {
            typeof(ATraktGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Inherits_ATraktRequest_1()
        {
            typeof(ATraktGetRequest<int>).IsSubclassOf(typeof(ATraktRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Implements_ITraktGetRequest_1_Interface()
        {
            typeof(ATraktGetRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktGetRequest<int>));
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktGetRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Returns_Valid_Method()
        {
            var requestMock = new TraktGetRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Get);
        }

        [Fact]
        public void Test_ATraktGetRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktGetRequest<>).GetProperties()
                                                         .Where(p => p.Name == "Method")
                                                         .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

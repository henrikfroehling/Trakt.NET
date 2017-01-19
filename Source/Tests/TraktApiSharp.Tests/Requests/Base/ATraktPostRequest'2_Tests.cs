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
    public class ATraktPostRequest_2_Tests
    {
        internal class TraktPostRequestMock : ATraktPostRequest<string, object>
        {
            public override object RequestBody { get; set; }

            public override string UriTemplate => throw new NotImplementedException();

            public override IDictionary<string, object> GetUriPathParameters()
            {
                throw new NotImplementedException();
            }
        };

        [Fact]
        public void Test_ATraktPostRequest_2_Is_AbstractClass()
        {
            typeof(ATraktPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Has_GenericTypeParameter()
        {
            typeof(ATraktPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Inherits_ATraktRequest_1()
        {
            typeof(ATraktPostRequest<int, float>).IsSubclassOf(typeof(ATraktRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Implements_ITraktPostRequest_2_Interface()
        {
            typeof(ATraktPostRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPostRequest<int, float>));
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Returns_Valid_Method()
        {
            var requestMock = new TraktPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new TraktPostRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Has_Abstract_RequestBody_Property()
        {
            var propertyInfo = typeof(ATraktPostRequest<,>).GetProperties()
                                                           .Where(p => p.Name == "RequestBody")
                                                           .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPostRequest_2_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktPostRequest<,>).GetProperties()
                                                           .Where(p => p.Name == "Method")
                                                           .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

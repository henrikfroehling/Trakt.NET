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
    public class ATraktPutRequest_1_Tests
    {
        internal class TraktPutRequestMock : ATraktPutRequest<object>
        {
            public override object RequestBody { get; set; }

            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override IDictionary<string, object> GetUriPathParameters()
            {
                throw new NotImplementedException();
            }
        };

        [Fact]
        public void Test_ATraktPutRequest_1_Is_AbstractClass()
        {
            typeof(ATraktPutRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPutRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Inherits_ATraktRequest()
        {
            typeof(ATraktPutRequest<>).IsSubclassOf(typeof(ATraktRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Implements_ITraktPutRequest_1_Interface()
        {
            typeof(ATraktPutRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPutRequest<int>));
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktPutRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Returns_Valid_Method()
        {
            var requestMock = new TraktPutRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Put);
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new TraktPutRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Has_Abstract_RequestBody_Property()
        {
            var propertyInfo = typeof(ATraktPutRequest<>).GetProperties()
                                                         .Where(p => p.Name == "RequestBody")
                                                         .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktPutRequest<>).GetProperties()
                                                         .Where(p => p.Name == "Method")
                                                         .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

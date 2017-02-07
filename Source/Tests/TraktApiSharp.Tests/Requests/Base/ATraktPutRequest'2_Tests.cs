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
    public class ATraktPutRequest_2_Tests
    {
        internal class TraktPutRequestMock : ATraktPutRequest<string, object>
        {
            public override object RequestBody { get; set; }

            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override IDictionary<string, object> GetUriPathParameters()
            {
                throw new NotImplementedException();
            }
        };

        [Fact]
        public void Test_ATraktPutRequest_2_Is_AbstractClass()
        {
            typeof(ATraktPutRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Has_GenericTypeParameter()
        {
            typeof(ATraktPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Inherits_ATraktRequest_1()
        {
            typeof(ATraktPutRequest<int, float>).IsSubclassOf(typeof(ATraktRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Implements_ITraktPutRequest_2_Interface()
        {
            typeof(ATraktPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPutRequest<int, float>));
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new TraktPutRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Returns_Valid_Method()
        {
            var requestMock = new TraktPutRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Put);
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new TraktPutRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Has_Abstract_RequestBody_Property()
        {
            var propertyInfo = typeof(ATraktPutRequest<,>).GetProperties()
                                                          .Where(p => p.Name == "RequestBody")
                                                          .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPutRequest_2_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ATraktPutRequest<,>).GetProperties()
                                                          .Where(p => p.Name == "Method")
                                                          .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

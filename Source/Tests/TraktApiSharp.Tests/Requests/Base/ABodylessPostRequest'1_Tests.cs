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
    public class ABodylessPostRequest_1_Tests
    {
        internal class BodylessPostRequestMock : ABodylessPostRequest<int>
        {
            public override string UriTemplate => throw new NotImplementedException();
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
            public override void Validate() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Is_AbstractClass()
        {
            typeof(ABodylessPostRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Has_GenericTypeParameter()
        {
            typeof(ABodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ABodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Inherits_ARequest_1()
        {
            typeof(ABodylessPostRequest<int>).IsSubclassOf(typeof(ARequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Implements_IBodylessPostRequest_1_Interface()
        {
            typeof(ABodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(IBodylessPostRequest<int>));
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new BodylessPostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Returns_Valid_Method()
        {
            var requestMock = new BodylessPostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_ABodylessPostRequest_1_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(ABodylessPostRequest<>).GetProperties()
                                                                  .Where(p => p.Name == "Method")
                                                                  .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

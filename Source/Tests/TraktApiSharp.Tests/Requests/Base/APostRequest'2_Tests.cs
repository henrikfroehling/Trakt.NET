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
    public class APostRequest_2_Tests
    {
        internal class PostRequestMock : APostRequest<string, object>
        {
            public override object RequestBody { get; set; }
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override IDictionary<string, object> GetUriPathParameters() => throw new NotImplementedException();
        }

        [Fact]
        public void Test_APostRequest_2_Is_AbstractClass()
        {
            typeof(APostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_APostRequest_2_Has_GenericTypeParameter()
        {
            typeof(APostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(APostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_APostRequest_2_Inherits_ARequest_1()
        {
            typeof(APostRequest<int, float>).IsSubclassOf(typeof(ARequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_APostRequest_2_Implements_IPostRequest_2_Interface()
        {
            typeof(APostRequest<int, float>).GetInterfaces().Should().Contain(typeof(IPostRequest<int, float>));
        }

        [Fact]
        public void Test_APostRequest_2_Returns_Valid_AuthorizationRequirement()
        {
            var requestMock = new PostRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_APostRequest_2_Returns_Valid_Method()
        {
            var requestMock = new PostRequestMock();
            requestMock.Method.Should().Be(HttpMethod.Post);
        }

        [Fact]
        public void Test_APostRequest_2_Validate_Throws_ArgumentNullException()
        {
            var requestMock = new PostRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Test_APostRequest_2_Has_Abstract_RequestBody_Property()
        {
            var propertyInfo = typeof(APostRequest<,>).GetProperties()
                                                           .Where(p => p.Name == "RequestBody")
                                                           .FirstOrDefault();

            propertyInfo.GetMethod.IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_APostRequest_2_Has_Sealed_Method_Property()
        {
            var propertyInfo = typeof(APostRequest<,>).GetProperties()
                                                           .Where(p => p.Name == "Method")
                                                           .FirstOrDefault();

            propertyInfo.GetMethod.IsFinal.Should().BeTrue();
        }
    }
}

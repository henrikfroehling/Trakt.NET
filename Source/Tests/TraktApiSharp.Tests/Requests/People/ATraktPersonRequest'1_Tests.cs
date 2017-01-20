namespace TraktApiSharp.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.People;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.People")]
    public class ATraktPersonRequest_1_Tests
    {
        internal class TraktPersonRequestMock : ATraktPersonRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_IsAbstract()
        {
            typeof(ATraktPersonRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktPersonRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPersonRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(ATraktPersonRequest<int>).IsSubclassOf(typeof(ATraktGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Implements_ITraktHasId()
        {
            typeof(ATraktPersonRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Implements_ITraktSupportsExtendedInfo()
        {
            typeof(ATraktPersonRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktPersonRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktPersonRequestMock();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.People);
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new TraktPersonRequestMock { Id = "123" };
            
            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktPersonRequestMock { Id = "123", ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["extended"] = extendedInfo.ToString()
                                                       });
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Validate_Throws_ArgumentException_If_Id_NotSet()
        {
            var requestMock = new TraktPersonRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

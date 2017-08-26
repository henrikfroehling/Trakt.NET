namespace TraktApiSharp.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.People;
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
            typeof(ATraktPersonRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktPersonRequest<>).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(ATraktPersonRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new TraktPersonRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_ATraktPersonRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktPersonRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.People);
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
        public void Test_ATraktPersonRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktPersonRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktPersonRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktPersonRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

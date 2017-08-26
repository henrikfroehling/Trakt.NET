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
    public class APersonRequest_1_Tests
    {
        internal class PersonRequestMock : APersonRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_APersonRequest_1_IsAbstract()
        {
            typeof(APersonRequest<>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_APersonRequest_1_Has_GenericTypeParameter()
        {
            typeof(APersonRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(APersonRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_APersonRequest_1_Inherits_ATraktGetRequest_1()
        {
            typeof(APersonRequest<int>).IsSubclassOf(typeof(AGetRequest<int>)).Should().BeTrue();
        }

        [Fact]
        public void Test_APersonRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(APersonRequest<>).GetInterfaces().Should().Contain(typeof(IHasId));
        }

        [Fact]
        public void Test_APersonRequest_1_Implements_ITraktSupportsExtendedInfo_Interface()
        {
            typeof(APersonRequest<>).GetInterfaces().Should().Contain(typeof(ISupportsExtendedInfo));
        }

        [Fact]
        public void Test_APersonRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new PersonRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_APersonRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new PersonRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.People);
        }

        [Fact]
        public void Test_APersonRequest_1_Returns_Valid_UriPathParameters()
        {
            // only id
            var requestMock = new PersonRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new PersonRequestMock { Id = "123", ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123",
                                                           ["extended"] = extendedInfo.ToString()
                                                       });
        }

        [Fact]
        public void Test_APersonRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new PersonRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new PersonRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new PersonRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

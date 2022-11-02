namespace TraktNet.Requests.Tests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.People;
    using Xunit;

    [TestCategory("Requests.People")]
    public class APersonRequest_1_Tests
    {
        internal class PersonRequestMock : APersonRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
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
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            requestMock = new PersonRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            requestMock = new PersonRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}

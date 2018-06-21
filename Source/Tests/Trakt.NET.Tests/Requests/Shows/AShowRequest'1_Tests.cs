namespace TraktNet.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class AShowRequest_1_Tests
    {
        internal class ShowRequestMock : AShowRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AShowRequest_1_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new ShowRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_AShowRequest_1_Returns_Valid_RequestObjectType()
        {
            var requestMock = new ShowRequestMock();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Shows);
        }

        [Fact]
        public void Test_AShowRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new ShowRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AShowRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new ShowRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            requestMock = new ShowRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            requestMock = new ShowRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

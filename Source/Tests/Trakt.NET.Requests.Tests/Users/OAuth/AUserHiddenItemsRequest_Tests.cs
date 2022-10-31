namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class AUserHiddenItemsRequest_Tests
    {
        internal class UserHiddenItemsRequestMock : AUserHiddenItemsRequest<int>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AUserHiddenItemsRequest_Has_AuthorizationRequirement_Required()
        {
            var requestMock = new UserHiddenItemsRequestMock();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_AUserHiddenItemsRequest_Validate_Throws_Exceptions()
        {
            // section is null
            var requestMock = new UserHiddenItemsRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // section is unspecified
            requestMock = new UserHiddenItemsRequestMock
            {
                Section = TraktHiddenItemsSection.Unspecified
            };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }

        [Fact]
        public void Test_AUserHiddenItemsRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new UserHiddenItemsRequestMock
            {
                Section = TraktHiddenItemsSection.Calendar
            };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["section"] = TraktHiddenItemsSection.Calendar.UriName,
                                                       });
        }
    }
}

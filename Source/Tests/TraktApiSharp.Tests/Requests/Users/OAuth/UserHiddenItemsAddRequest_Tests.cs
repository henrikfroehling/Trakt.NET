namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserHiddenItemsAddRequest_Tests
    {
        [Fact]
        public void Test_UserHiddenItemsAddRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserHiddenItemsAddRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserHiddenItemsAddRequest_Has_Valid_UriTemplate()
        {
            var request = new UserHiddenItemsAddRequest();
            request.UriTemplate.Should().Be("users/hidden/{section}");
        }

        [Fact]
        public void Test_UserHiddenItemsAddRequest_Validate_Throws_Exceptions()
        {
            // section is null
            var request = new UserHiddenItemsAddRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // section is unspecified
            request = new UserHiddenItemsAddRequest
            {
                Section = TraktHiddenItemsSection.Unspecified
            };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_UserHiddenItemsAddRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserHiddenItemsAddRequest
            {
                Section = TraktHiddenItemsSection.Calendar
            };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["section"] = TraktHiddenItemsSection.Calendar.UriName,
                                                   });
        }
    }
}

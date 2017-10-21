namespace TraktApiSharp.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.People;
    using Xunit;

    [Category("Requests.People")]
    public class PersonShowCreditsRequest_Tests
    {
        [Fact]
        public void Test_PersonShowCreditsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new PersonShowCreditsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_PersonShowCreditsRequest_Returns_Valid_RequestObjectType()
        {
            var request = new PersonShowCreditsRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.People);
        }

        [Fact]
        public void Test_PersonShowCreditsRequest_Has_Valid_UriTemplate()
        {
            var request = new PersonShowCreditsRequest();
            request.UriTemplate.Should().Be("people/{id}/shows{?extended}");
        }

        [Fact]
        public void Test_PersonShowCreditsRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new PersonShowCreditsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new PersonShowCreditsRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_PersonShowCreditsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new PersonShowCreditsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new PersonShowCreditsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new PersonShowCreditsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

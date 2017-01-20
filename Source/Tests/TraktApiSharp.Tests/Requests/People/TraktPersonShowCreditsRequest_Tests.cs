namespace TraktApiSharp.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.People;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.People")]
    public class TraktPersonShowCreditsRequest_Tests
    {
        [Fact]
        public void Test_TraktPersonShowCreditsRequest_IsNotAbstract()
        {
            typeof(TraktPersonShowCreditsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_IsSealed()
        {
            typeof(TraktPersonShowCreditsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Inherits_ATraktPersonRequest_1()
        {
            typeof(TraktPersonShowCreditsRequest).IsSubclassOf(typeof(ATraktPersonRequest<TraktPersonShowCredits>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktPersonShowCreditsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktPersonShowCreditsRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.People);
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktPersonShowCreditsRequest();
            request.UriTemplate.Should().Be("people/{id}/shows{?extended}");
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktPersonShowCreditsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktPersonShowCreditsRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktPersonShowCreditsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktPersonShowCreditsRequest();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktPersonShowCreditsRequest { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

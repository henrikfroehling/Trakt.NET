namespace TraktApiSharp.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.People;
    using Xunit;

    [Category("Requests.People")]
    public class TraktPersonSummaryRequest_Tests
    {
        [Fact]
        public void Test_TraktPersonSummaryRequest_IsNotAbstract()
        {
            typeof(TraktPersonSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_IsSealed()
        {
            typeof(TraktPersonSummaryRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Inherits_ATraktPersonRequest_1()
        {
            typeof(TraktPersonSummaryRequest).IsSubclassOf(typeof(ATraktPersonRequest<TraktPerson>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktPersonSummaryRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Returns_Valid_RequestObjectType()
        {
            var request = new TraktPersonSummaryRequest();
            request.RequestObjectType.Should().Be(TraktRequestObjectType.People);
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktPersonSummaryRequest();
            request.UriTemplate.Should().Be("people/{id}{?extended}");
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new TraktPersonSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktPersonSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_TraktPersonSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktPersonSummaryRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktPersonSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktPersonSummaryRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}

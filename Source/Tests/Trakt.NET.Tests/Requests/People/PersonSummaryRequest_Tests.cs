namespace TraktNet.Tests.Requests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.People;
    using Xunit;

    [Category("Requests.People")]
    public class PersonSummaryRequest_Tests
    {
        [Fact]
        public void Test_PersonSummaryRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new PersonSummaryRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_PersonSummaryRequest_Returns_Valid_RequestObjectType()
        {
            var request = new PersonSummaryRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.People);
        }

        [Fact]
        public void Test_PersonSummaryRequest_Has_Valid_UriTemplate()
        {
            var request = new PersonSummaryRequest();
            request.UriTemplate.Should().Be("people/{id}{?extended}");
        }

        [Fact]
        public void Test_PersonSummaryRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new PersonSummaryRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new PersonSummaryRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_PersonSummaryRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new PersonSummaryRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new PersonSummaryRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new PersonSummaryRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

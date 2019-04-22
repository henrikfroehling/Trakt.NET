namespace TraktNet.Requests.Tests.People
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.People;
    using Xunit;

    [Category("Requests.People")]
    public class PersonMovieCreditsRequest_Tests
    {
        [Fact]
        public void Test_PersonMovieCreditsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new PersonMovieCreditsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_PersonMovieCreditsRequest_Returns_Valid_RequestObjectType()
        {
            var request = new PersonMovieCreditsRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.People);
        }

        [Fact]
        public void Test_PersonMovieCreditsRequest_Has_Valid_UriTemplate()
        {
            var request = new PersonMovieCreditsRequest();
            request.UriTemplate.Should().Be("people/{id}/movies{?extended}");
        }

        [Fact]
        public void Test_PersonMovieCreditsRequest_Returns_Valid_UriPathParameters()
        {
            // only id
            var request = new PersonMovieCreditsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // id and extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new PersonMovieCreditsRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_PersonMovieCreditsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new PersonMovieCreditsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new PersonMovieCreditsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new PersonMovieCreditsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}

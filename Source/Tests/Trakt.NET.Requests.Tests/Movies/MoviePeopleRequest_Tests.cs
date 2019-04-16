namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Movies;
    using TraktNet.Requests.Parameters;
    using Xunit;

    [Category("Requests.Movies")]
    public class MoviePeopleRequest_Tests
    {
        [Fact]
        public void Test_MoviePeopleRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviePeopleRequest();
            request.UriTemplate.Should().Be("movies/{id}/people{?extended}");
        }

        [Fact]
        public void Test_MoviePeopleRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MoviePeopleRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MoviePeopleRequest { Id = "123", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_MoviePeopleRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MoviePeopleRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MoviePeopleRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MoviePeopleRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();
        }
    }
}

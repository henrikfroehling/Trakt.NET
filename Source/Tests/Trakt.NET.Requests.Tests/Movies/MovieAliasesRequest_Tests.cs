namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieAliasesRequest_Tests
    {
        [Fact]
        public void Test_MovieAliasesRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieAliasesRequest();
            request.UriTemplate.Should().Be("movies/{id}/aliases");
        }

        [Fact]
        public void Test_MovieAliasesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new MovieAliasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_MovieAliasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieAliasesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MovieAliasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MovieAliasesRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();
        }
    }
}

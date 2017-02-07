namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieAliasesRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieAliasesRequest_IsNotAbstract()
        {
            typeof(TraktMovieAliasesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieAliasesRequest_IsSealed()
        {
            typeof(TraktMovieAliasesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieAliasesRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieAliasesRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktMovieAlias>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieAliasesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieAliasesRequest();
            request.UriTemplate.Should().Be("movies/{id}/aliases");
        }

        [Fact]
        public void Test_TraktMovieAliasesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktMovieAliasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktMovieAliasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieAliasesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieAliasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieAliasesRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

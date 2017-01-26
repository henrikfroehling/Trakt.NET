namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Movies")]
    public class TraktMovieReleasesRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieReleasesRequest_IsNotAbstract()
        {
            typeof(TraktMovieReleasesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_IsSealed()
        {
            typeof(TraktMovieReleasesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieReleasesRequest).IsSubclassOf(typeof(ATraktMovieRequest<TraktMovieRelease>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieReleasesRequest();
            request.UriTemplate.Should().Be("movies/{id}/releases{/country}");
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_Has_CountryCode_Property()
        {
            var sortingPropertyInfo = typeof(TraktMovieReleasesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "CountryCode")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_Returns_Valid_UriPathParameters()
        {
            // without country code
            var request = new TraktMovieReleasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with country code
            request = new TraktMovieReleasesRequest { Id = "123", CountryCode = "us" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["country"] = "us"
                                                   });
        }

        [Fact]
        public void Test_TraktMovieReleasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieReleasesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieReleasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieReleasesRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

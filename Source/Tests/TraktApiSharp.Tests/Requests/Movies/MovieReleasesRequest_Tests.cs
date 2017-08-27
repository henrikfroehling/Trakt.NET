namespace TraktApiSharp.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
    public class MovieReleasesRequest_Tests
    {
        [Fact]
        public void Test_MovieReleasesRequest_IsNotAbstract()
        {
            typeof(MovieReleasesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_MovieReleasesRequest_IsSealed()
        {
            typeof(MovieReleasesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_MovieReleasesRequest_Inherits_AMovieRequest_1()
        {
            typeof(MovieReleasesRequest).IsSubclassOf(typeof(AMovieRequest<ITraktMovieRelease>)).Should().BeTrue();
        }

        [Fact]
        public void Test_MovieReleasesRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieReleasesRequest();
            request.UriTemplate.Should().Be("movies/{id}/releases{/country}");
        }

        [Fact]
        public void Test_MovieReleasesRequest_Has_CountryCode_Property()
        {
            var propertyInfo = typeof(MovieReleasesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "CountryCode")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_MovieReleasesRequest_Returns_Valid_UriPathParameters()
        {
            // without country code
            var request = new MovieReleasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with country code
            request = new MovieReleasesRequest { Id = "123", CountryCode = "us" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["country"] = "us"
                                                   });
        }

        [Fact]
        public void Test_MovieReleasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieReleasesRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new MovieReleasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new MovieReleasesRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();

            // country code with wrong length
            request = new MovieReleasesRequest { Id = "123", CountryCode = "usa" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new MovieReleasesRequest { Id = "123", CountryCode = "a" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}

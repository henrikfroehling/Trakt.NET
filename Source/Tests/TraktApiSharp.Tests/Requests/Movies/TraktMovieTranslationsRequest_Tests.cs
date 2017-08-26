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
    public class TraktMovieTranslationsRequest_Tests
    {
        [Fact]
        public void Test_TraktMovieTranslationsRequest_IsNotAbstract()
        {
            typeof(TraktMovieTranslationsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_IsSealed()
        {
            typeof(TraktMovieTranslationsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_Inherits_ATraktMovieRequest_1()
        {
            typeof(TraktMovieTranslationsRequest).IsSubclassOf(typeof(AMovieRequest<ITraktMovieTranslation>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktMovieTranslationsRequest();
            request.UriTemplate.Should().Be("movies/{id}/translations{/language}");
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_Has_LanguageCode_Property()
        {
            var propertyInfo = typeof(TraktMovieTranslationsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LanguageCode")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // without language code
            var request = new TraktMovieTranslationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with language code
            request = new TraktMovieTranslationsRequest { Id = "123", LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["language"] = "en"
                                                   });
        }

        [Fact]
        public void Test_TraktMovieTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktMovieTranslationsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktMovieTranslationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktMovieTranslationsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();

            // language code with wrong length
            request = new TraktMovieTranslationsRequest { Id = "123", LanguageCode = "eng" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new TraktMovieTranslationsRequest { Id = "123", LanguageCode = "e" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}

namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Shows")]
    public class TraktShowTranslationsRequest_Tests
    {
        [Fact]
        public void Test_TraktShowTranslationsRequest_Is_Not_Abstract()
        {
            typeof(TraktShowTranslationsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Is_Sealed()
        {
            typeof(TraktShowTranslationsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Inherits_ATraktShowRequest_1()
        {
            typeof(TraktShowTranslationsRequest).IsSubclassOf(typeof(ATraktShowRequest<TraktShowTranslation>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktShowTranslationsRequest();
            request.UriTemplate.Should().Be("shows/{id}/translations{/language}");
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Has_LanguageCode_Property()
        {
            var sortingPropertyInfo = typeof(TraktShowTranslationsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LanguageCode")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // without language code
            var request = new TraktShowTranslationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with language code
            request = new TraktShowTranslationsRequest { Id = "123", LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["language"] = "en"
                                                   });
        }

        [Fact]
        public void Test_TraktShowTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktShowTranslationsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktShowTranslationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktShowTranslationsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();
        }
    }
}

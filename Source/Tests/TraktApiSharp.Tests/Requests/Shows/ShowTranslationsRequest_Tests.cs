namespace TraktApiSharp.Tests.Requests.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Shows;
    using Xunit;

    [Category("Requests.Shows")]
    public class ShowTranslationsRequest_Tests
    {
        [Fact]
        public void Test_ShowTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new ShowTranslationsRequest();
            request.UriTemplate.Should().Be("shows/{id}/translations{/language}");
        }

        [Fact]
        public void Test_ShowTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // without language code
            var request = new ShowTranslationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with language code
            request = new ShowTranslationsRequest { Id = "123", LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["language"] = "en"
                                                   });
        }

        [Fact]
        public void Test_ShowTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new ShowTranslationsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new ShowTranslationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new ShowTranslationsRequest { Id = "invalid id" };
            act.ShouldThrow<ArgumentException>();

            // language code with wrong length
            request = new ShowTranslationsRequest { Id = "123", LanguageCode = "eng" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();

            request = new ShowTranslationsRequest { Id = "123", LanguageCode = "e" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }
    }
}

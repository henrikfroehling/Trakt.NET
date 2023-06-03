namespace TraktNet.Objects.Get.Tests.Movies.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonWriter")]
    public partial class MovieTranslationObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktMovieTranslation));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Only_Title_Property()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                Title = "title"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""title"":""title""}");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Only_Overview_Property()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                Overview = "overview"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""overview"":""overview""}");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Only_Tagline_Property()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                Tagline = "tagline"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""tagline"":""tagline""}");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Only_LanguageCode_Property()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                LanguageCode = "en"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""language"":""en""}");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Only_CountryCode_Property()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktMovieTranslation traktMovieTranslation = new TraktMovieTranslation
            {
                Title = "title",
                Overview = "overview",
                LanguageCode = "en",
                CountryCode = "us",
                Tagline = "tagline"
            };

            var traktJsonWriter = new MovieTranslationObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktMovieTranslation);
            json.Should().Be(@"{""title"":""title"",""overview"":""overview"",""language"":""en"",""country"":""us"",""tagline"":""tagline""}");
        }
    }
}

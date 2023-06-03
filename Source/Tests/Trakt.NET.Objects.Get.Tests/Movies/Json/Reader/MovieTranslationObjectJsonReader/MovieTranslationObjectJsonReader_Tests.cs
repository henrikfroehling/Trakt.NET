namespace TraktNet.Objects.Get.Tests.Movies.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Movies.JsonReader")]
    public partial class MovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().BeNull();
            traktMovieTranslation.CountryCode.Should().Be("us");
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas,...");
            traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
            traktMovieTranslation.LanguageCode.Should().Be("en");
            traktMovieTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktMovieTranslation.Should().NotBeNull();
            traktMovieTranslation.Title.Should().BeNull();
            traktMovieTranslation.Overview.Should().BeNull();
            traktMovieTranslation.Tagline.Should().BeNull();
            traktMovieTranslation.LanguageCode.Should().BeNull();
            traktMovieTranslation.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();
            Func<Task<ITraktMovieTranslation>> traktMovieTranslation = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktMovieTranslation.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktMovieTranslation.Should().BeNull();
        }
    }
}

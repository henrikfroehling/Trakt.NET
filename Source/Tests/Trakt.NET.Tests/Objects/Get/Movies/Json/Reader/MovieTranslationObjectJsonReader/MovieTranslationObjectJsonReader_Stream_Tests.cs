namespace TraktNet.Tests.Objects.Get.Movies.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieTranslationObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().Be("en");
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
                traktMovieTranslation.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
                traktMovieTranslation.Tagline.Should().Be("The Force Lives On...");
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);

                traktMovieTranslation.Should().NotBeNull();
                traktMovieTranslation.Title.Should().BeNull();
                traktMovieTranslation.Overview.Should().BeNull();
                traktMovieTranslation.Tagline.Should().BeNull();
                traktMovieTranslation.LanguageCode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMovieTranslation.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieTranslationObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MovieTranslationObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMovieTranslation = await traktJsonReader.ReadObjectAsync(stream);
                traktMovieTranslation.Should().BeNull();
            }
        }
    }
}

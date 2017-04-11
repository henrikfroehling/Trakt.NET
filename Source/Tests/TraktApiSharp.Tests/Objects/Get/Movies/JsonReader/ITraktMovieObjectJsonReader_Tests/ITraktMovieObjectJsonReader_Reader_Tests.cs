namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class ITraktMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_23()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_24()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_25()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_26()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_27()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_27))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_28()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_28))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_29()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_29))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_30()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_30))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_31()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_31))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_32()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_32))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_13()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_14()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_15()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().Be("PG-13");
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_16()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMovie.Year.Should().Be(2015);
                traktMovie.Ids.Should().NotBeNull();
                traktMovie.Ids.Trakt.Should().Be(94024U);
                traktMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMovie.Ids.Imdb.Should().Be("tt2488496");
                traktMovie.Ids.Tmdb.Should().Be(140607U);
                traktMovie.Tagline.Should().Be("Every generation has a story.");
                traktMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
                traktMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
                traktMovie.Runtime.Should().Be(136);
                traktMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
                traktMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
                traktMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
                traktMovie.Rating.Should().Be(8.31988f);
                traktMovie.Votes.Should().Be(9338);
                traktMovie.LanguageCode.Should().Be("en");
                traktMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
                traktMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_17()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMovie.Should().NotBeNull();
                traktMovie.Title.Should().BeNull();
                traktMovie.Year.Should().BeNull();
                traktMovie.Ids.Should().BeNull();
                traktMovie.Tagline.Should().BeNull();
                traktMovie.Overview.Should().BeNull();
                traktMovie.Released.Should().BeNull();
                traktMovie.Runtime.Should().BeNull();
                traktMovie.UpdatedAt.Should().BeNull();
                traktMovie.Trailer.Should().BeNull();
                traktMovie.Homepage.Should().BeNull();
                traktMovie.Rating.Should().BeNull();
                traktMovie.Votes.Should().BeNull();
                traktMovie.LanguageCode.Should().BeNull();
                traktMovie.AvailableTranslationLanguageCodes.Should().BeNull();
                traktMovie.Genres.Should().BeNull();
                traktMovie.Certification.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMovie.Should().BeNull();
            }
        }
    }
}

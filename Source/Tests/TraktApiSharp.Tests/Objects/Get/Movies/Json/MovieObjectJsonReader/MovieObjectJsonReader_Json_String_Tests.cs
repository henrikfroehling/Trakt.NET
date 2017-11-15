namespace TraktApiSharp.Tests.Objects.Get.Movies.Json
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies.Json;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public partial class MovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_COMPLETE);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_3()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_4()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_4);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_5()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_5);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_6()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_INCOMPLETE_6);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_4()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(MINIMAL_JSON_NOT_VALID_4);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_COMPLETE);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_4);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_5);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_6);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_7);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_8);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_9);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_10);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_11);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_12);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_13);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_14);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_15()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_15);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_16()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_16);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_17()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_17);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_18()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_18);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_19()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_19);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_20()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_20);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_21()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_21);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_22()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_22);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_23()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_23);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_24()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_24);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_25()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_25);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_26()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_26);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_27()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_27);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_28()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_28);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_29()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_29);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_30()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_30);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_31()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_31);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_32()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_INCOMPLETE_32);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_4);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_5);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_6);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_7);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_8);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_9()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_9);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_10()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_10);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_11()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_11);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_12()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_12);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_13()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_13);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_14()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_14);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_15()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_15);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_16()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_16);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_17()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(FULL_JSON_NOT_VALID_17);

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

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(default(string));
            traktMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_MovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MovieObjectJsonReader();

            var traktMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktMovie.Should().BeNull();
        }
    }
}

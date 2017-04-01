namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public class ITraktMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMovie>));
        }

        [Fact]
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_COMPLETE);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_1()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_1);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_2()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_2);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_3()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_3);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_4()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_4);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_5()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_5);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Incomplete_6()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_INCOMPLETE_6);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_1()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_1);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_2()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_2);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_3()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_3);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Minimal_Not_Valid_4()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(MINIMAL_JSON_NOT_VALID_4);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Complete()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_COMPLETE);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_1()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_1);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_2()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_2);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_3()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_3);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_4()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_4);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_5()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_5);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_6()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_6);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_7()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_7);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_8()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_8);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_9()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_9);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_10()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_10);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_11()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_11);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_12()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_12);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_13()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_13);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_14()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_14);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_15()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_15);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_16()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_16);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_17()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_17);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_18()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_18);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_19()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_19);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_20()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_20);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_21()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_21);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_22()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_22);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_23()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_23);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_24()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_24);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_25()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_25);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_26()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_26);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_27()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_27);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_28()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_28);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_29()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_29);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_30()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_30);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_31()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_31);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Incomplete_32()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_INCOMPLETE_32);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_1()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_1);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_2()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_2);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_3()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_3);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_4()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_4);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_5()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_5);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_6()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_6);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_7()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_7);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_8()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_8);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_9()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_9);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_10()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_10);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_11()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_11);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_12()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_12);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_13()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_13);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_14()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_14);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_15()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_15);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_16()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_16);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Full_Not_Valid_17()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(FULL_JSON_NOT_VALID_17);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(default(string));
            traktMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(string.Empty);
            traktMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Complete()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Incomplete_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Minimal_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(MINIMAL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Complete()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_7()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_8()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_9()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_10()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_11()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_12()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_13()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_14()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_15()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_16()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_17()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_18()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_19()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_20()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_21()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_22()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_23()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_24()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_25()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_25))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_26()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_26))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_27()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_27))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_28()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_28))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_29()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_29))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_30()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_30))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_31()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_31))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Incomplete_32()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_INCOMPLETE_32))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_6()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_7()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_8()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_9()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_10()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_11()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_12()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_13()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_14()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_15()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_16()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Full_Not_Valid_17()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(FULL_JSON_NOT_VALID_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMovieObjectJsonReader();

            var traktMovie = jsonReader.ReadObject(default(JsonTextReader));
            traktMovie.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMovie = traktJsonReader.ReadObject(jsonReader);
                traktMovie.Should().BeNull();
            }
        }

        private const string MINIMAL_JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015
              }";

        private const string MINIMAL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string MINIMAL_JSON_INCOMPLETE_5 =
            @"{
                ""year"": 2015
              }";

        private const string MINIMAL_JSON_INCOMPLETE_6 =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string MINIMAL_JSON_NOT_VALID_4 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string FULL_JSON_COMPLETE =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_1 =
            @"{
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_5 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_6 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_7 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_8 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_9 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_10 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_11 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_12 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_13 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_14 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_15 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_INCOMPLETE_16 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_17 =
            @"{
                ""title"": ""Star Wars: The Force Awakens""
              }";

        private const string FULL_JSON_INCOMPLETE_18 =
            @"{
                ""year"": 2015
              }";

        private const string FULL_JSON_INCOMPLETE_19 =
            @"{
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                }
              }";

        private const string FULL_JSON_INCOMPLETE_20 =
            @"{
                ""tagline"": ""Every generation has a story.""
              }";

        private const string FULL_JSON_INCOMPLETE_21 =
            @"{
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.""
              }";

        private const string FULL_JSON_INCOMPLETE_22 =
            @"{
                ""released"": ""2015-12-18""
              }";

        private const string FULL_JSON_INCOMPLETE_23 =
            @"{
                ""runtime"": 136
              }";

        private const string FULL_JSON_INCOMPLETE_24 =
            @"{
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U""
              }";

        private const string FULL_JSON_INCOMPLETE_25 =
            @"{
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii""
              }";

        private const string FULL_JSON_INCOMPLETE_26 =
            @"{
                ""rating"": 8.31988
              }";

        private const string FULL_JSON_INCOMPLETE_27 =
            @"{
                ""votes"": 9338
              }";

        private const string FULL_JSON_INCOMPLETE_28 =
            @"{
                ""updated_at"": ""2016-03-31T09:01:59Z""
              }";

        private const string FULL_JSON_INCOMPLETE_29 =
            @"{
                ""language"": ""en""
              }";

        private const string FULL_JSON_INCOMPLETE_30 =
            @"{
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_31 =
            @"{
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ]
              }";

        private const string FULL_JSON_INCOMPLETE_32 =
            @"{
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tl"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_5 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""ov"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_6 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""re"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_7 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""ru"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_8 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""tr"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_9 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""hp"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_10 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""ra"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_11 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""vo"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_12 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""ua"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_13 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""la"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_14 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_15 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""ge"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""certification"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_16 =
            @"{
                ""title"": ""Star Wars: The Force Awakens"",
                ""year"": 2015,
                ""ids"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tagline"": ""Every generation has a story."",
                ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""released"": ""2015-12-18"",
                ""runtime"": 136,
                ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""rating"": 8.31988,
                ""votes"": 9338,
                ""updated_at"": ""2016-03-31T09:01:59Z"",
                ""language"": ""en"",
                ""available_translations"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""genres"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""cert"": ""PG-13""
              }";

        private const string FULL_JSON_NOT_VALID_17 =
            @"{
                ""ti"": ""Star Wars: The Force Awakens"",
                ""ye"": 2015,
                ""id"": {
                  ""trakt"": 94024,
                  ""slug"": ""star-wars-the-force-awakens-2015"",
                  ""imdb"": ""tt2488496"",
                  ""tmdb"": 140607
                },
                ""tl"": ""Every generation has a story."",
                ""ov"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                ""re"": ""2015-12-18"",
                ""ru"": 136,
                ""tr"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                ""hp"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                ""ra"": 8.31988,
                ""vo"": 9338,
                ""ua"": ""2016-03-31T09:01:59Z"",
                ""la"": ""en"",
                ""availtr"": [
                  ""en"",
                  ""de"",
                  ""en"",
                  ""it""
                ],
                ""ge"": [
                  ""action"",
                  ""adventure"",
                  ""fantasy"",
                  ""science-fiction""
                ],
                ""cert"": ""PG-13""
              }";
    }
}

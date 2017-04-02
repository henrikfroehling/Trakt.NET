namespace TraktApiSharp.Tests.Objects.Get.Movies.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Movies.JsonReader")]
    public class ITraktMostPWCMovieObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMostPWCMovieObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMostPWCMovieObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMostPWCMovie>));
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().NotBeNull();
            traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            traktMostPWCMovie.Movie.Year.Should().Be(2015);
            traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
            traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
            traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
            traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().Be(4992);
            traktMostPWCMovie.PlayCount.Should().Be(7100);
            traktMostPWCMovie.CollectedCount.Should().Be(1348);
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMostPWCMovie.Should().NotBeNull();
            traktMostPWCMovie.WatcherCount.Should().BeNull();
            traktMostPWCMovie.PlayCount.Should().BeNull();
            traktMostPWCMovie.CollectedCount.Should().BeNull();
            traktMostPWCMovie.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(default(string));
            traktMostPWCMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(string.Empty);
            traktMostPWCMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().NotBeNull();
                traktMostPWCMovie.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                traktMostPWCMovie.Movie.Year.Should().Be(2015);
                traktMostPWCMovie.Movie.Ids.Should().NotBeNull();
                traktMostPWCMovie.Movie.Ids.Trakt.Should().Be(94024U);
                traktMostPWCMovie.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                traktMostPWCMovie.Movie.Ids.Imdb.Should().Be("tt2488496");
                traktMostPWCMovie.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().Be(4992);
                traktMostPWCMovie.PlayCount.Should().Be(7100);
                traktMostPWCMovie.CollectedCount.Should().Be(1348);
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCMovie.Should().NotBeNull();
                traktMostPWCMovie.WatcherCount.Should().BeNull();
                traktMostPWCMovie.PlayCount.Should().BeNull();
                traktMostPWCMovie.CollectedCount.Should().BeNull();
                traktMostPWCMovie.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMostPWCMovieObjectJsonReader();

            var traktMostPWCMovie = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMostPWCMovie.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktMostPWCMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMostPWCMovieObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMostPWCMovie.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watcher_count"": 4992,
                ""collected_count"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watcher_count"": 4992
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""play_count"": 7100
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""collected_count"": 1348
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wc"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watcher_count"": 4992,
                ""pc"": 7100,
                ""collected_count"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""cc"": 1348,
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""mo"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""wc"": 4992,
                ""pc"": 7100,
                ""cc"": 1348,
                ""mo"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";
    }
}

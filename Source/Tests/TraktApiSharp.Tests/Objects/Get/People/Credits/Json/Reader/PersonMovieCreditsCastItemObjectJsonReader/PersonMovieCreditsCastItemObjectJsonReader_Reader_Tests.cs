namespace TraktNet.Tests.Objects.Get.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().Be("Joe Brody");
                movieCreditsCastItem.Movie.Should().NotBeNull();
                movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCastItem.Movie.Year.Should().Be(2015);
                movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().BeNull();
                movieCreditsCastItem.Movie.Should().NotBeNull();
                movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCastItem.Movie.Year.Should().Be(2015);
                movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().Be("Joe Brody");
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().BeNull();
                movieCreditsCastItem.Movie.Should().NotBeNull();
                movieCreditsCastItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCastItem.Movie.Year.Should().Be(2015);
                movieCreditsCastItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCastItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCastItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCastItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCastItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().Be("Joe Brody");
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().BeNull();
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            movieCreditsCastItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                movieCreditsCastItem.Should().BeNull();
            }
        }
    }
}

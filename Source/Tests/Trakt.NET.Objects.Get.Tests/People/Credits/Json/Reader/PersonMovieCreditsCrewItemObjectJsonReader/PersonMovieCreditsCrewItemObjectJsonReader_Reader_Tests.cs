namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                movieCreditsCrewItem.Movie.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCrewItem.Movie.Year.Should().Be(2015);
                movieCreditsCrewItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().BeNull();
                movieCreditsCrewItem.Movie.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCrewItem.Movie.Year.Should().Be(2015);
                movieCreditsCrewItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                movieCreditsCrewItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().BeNull();
                movieCreditsCrewItem.Movie.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
                movieCreditsCrewItem.Movie.Year.Should().Be(2015);
                movieCreditsCrewItem.Movie.Ids.Should().NotBeNull();
                movieCreditsCrewItem.Movie.Ids.Trakt.Should().Be(94024U);
                movieCreditsCrewItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                movieCreditsCrewItem.Movie.Ids.Imdb.Should().Be("tt2488496");
                movieCreditsCrewItem.Movie.Ids.Tmdb.Should().Be(140607U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
                movieCreditsCrewItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                movieCreditsCrewItem.Should().NotBeNull();
                movieCreditsCrewItem.Jobs.Should().BeNull();
                movieCreditsCrewItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public void Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();
            Func<Task<ITraktPersonMovieCreditsCrewItem>> movieCreditsCrewItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            movieCreditsCrewItem.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCrewItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                movieCreditsCrewItem.Should().BeNull();
            }
        }
    }
}

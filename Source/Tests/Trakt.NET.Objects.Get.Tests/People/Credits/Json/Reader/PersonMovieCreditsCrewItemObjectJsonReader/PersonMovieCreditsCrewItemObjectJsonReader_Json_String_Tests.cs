namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            movieCreditsCrewItem.Should().NotBeNull();
            movieCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            movieCreditsCrewItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            movieCreditsCrewItem.Should().NotBeNull();
            movieCreditsCrewItem.Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            movieCreditsCrewItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            movieCreditsCrewItem.Should().NotBeNull();
            movieCreditsCrewItem.Jobs.Should().BeNull();
            movieCreditsCrewItem.Movie.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(default(string));
            movieCreditsCrewItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonMovieCreditsCrewItemObjectJsonReader();

            var movieCreditsCrewItem = await jsonReader.ReadObjectAsync(string.Empty);
            movieCreditsCrewItem.Should().BeNull();
        }
    }
}

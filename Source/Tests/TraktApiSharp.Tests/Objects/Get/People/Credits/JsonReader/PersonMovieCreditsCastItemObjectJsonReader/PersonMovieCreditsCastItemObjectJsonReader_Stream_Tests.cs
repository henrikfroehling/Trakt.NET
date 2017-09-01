namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().Be("Joe Brody");
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().Be("Joe Brody");
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);

                movieCreditsCastItem.Should().NotBeNull();
                movieCreditsCastItem.Character.Should().BeNull();
                movieCreditsCastItem.Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            var movieCreditsCastItem = await jsonReader.ReadObjectAsync(default(Stream));
            movieCreditsCastItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PersonMovieCreditsCastItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var movieCreditsCastItem = await jsonReader.ReadObjectAsync(stream);
                movieCreditsCastItem.Should().BeNull();
            }
        }
    }
}

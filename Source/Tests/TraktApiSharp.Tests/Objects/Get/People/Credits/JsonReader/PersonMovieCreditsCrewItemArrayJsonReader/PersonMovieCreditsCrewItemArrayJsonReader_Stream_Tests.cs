namespace TraktApiSharp.Tests.Objects.Get.People.Credits.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.People.Credits.JsonReader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCrewItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);
                movieCreditsCrewItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().NotBeNull();
                items[1].Movie.Title.Should().Be("TRON: Legacy");
                items[1].Movie.Year.Should().Be(2010);
                items[1].Movie.Ids.Should().NotBeNull();
                items[1].Movie.Ids.Trakt.Should().Be(12601U);
                items[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                items[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                items[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().NotBeNull();
                items[1].Movie.Title.Should().Be("TRON: Legacy");
                items[1].Movie.Year.Should().Be(2010);
                items[1].Movie.Ids.Should().NotBeNull();
                items[1].Movie.Ids.Trakt.Should().Be(12601U);
                items[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                items[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                items[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().NotBeNull();
                items[1].Movie.Title.Should().Be("TRON: Legacy");
                items[1].Movie.Year.Should().Be(2010);
                items[1].Movie.Ids.Should().NotBeNull();
                items[1].Movie.Ids.Trakt.Should().Be(12601U);
                items[1].Movie.Ids.Slug.Should().Be("tron-legacy-2010");
                items[1].Movie.Ids.Imdb.Should().Be("tt1104001");
                items[1].Movie.Ids.Tmdb.Should().Be(20526U);
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().Be("Director");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);

                movieCreditsCrewItems.Should().NotBeNull();
                var items = movieCreditsCrewItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Job.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Job.Should().Be("Producer");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(default(Stream));
            movieCreditsCrewItems.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCrewItemArrayJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PersonMovieCreditsCrewItemArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var movieCreditsCrewItems = await jsonReader.ReadArrayAsync(stream);
                movieCreditsCrewItems.Should().BeNull();
            }
        }
    }
}

namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonMovieCreditsCastItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                movieCreditsCastItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
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
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
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
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
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
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);

                movieCreditsCastItems.Should().NotBeNull();
                var items = movieCreditsCastItems.ToArray();

                items[0].Should().NotBeNull();
                items[0].Characters.Should().BeNull();
                items[0].Movie.Should().NotBeNull();
                items[0].Movie.Title.Should().Be("Star Wars: The Force Awakens");
                items[0].Movie.Year.Should().Be(2015);
                items[0].Movie.Ids.Should().NotBeNull();
                items[0].Movie.Ids.Trakt.Should().Be(94024U);
                items[0].Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
                items[0].Movie.Ids.Imdb.Should().Be("tt2488496");
                items[0].Movie.Ids.Tmdb.Should().Be(140607U);

                items[1].Should().NotBeNull();
                items[1].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Sam Flynn");
                items[1].Movie.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();
            Func<Task<IEnumerable<ITraktPersonMovieCreditsCastItem>>> movieCreditsCastItems = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await movieCreditsCastItems.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonMovieCreditsCastItemArrayJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktPersonMovieCreditsCastItem>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var movieCreditsCastItems = await traktJsonReader.ReadArrayAsync(jsonReader);
                movieCreditsCastItems.Should().BeNull();
            }
        }
    }
}

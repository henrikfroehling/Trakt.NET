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

    [TestCategory("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().BeNull();
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().BeNull();
                showCreditsCastItem.Show.Should().NotBeNull();
                showCreditsCastItem.Show.Title.Should().Be("Game of Thrones");
                showCreditsCastItem.Show.Year.Should().Be(2011);
                showCreditsCastItem.Show.Ids.Should().NotBeNull();
                showCreditsCastItem.Show.Ids.Trakt.Should().Be(1390U);
                showCreditsCastItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                showCreditsCastItem.Show.Ids.Tvdb.Should().Be(121361U);
                showCreditsCastItem.Show.Ids.Imdb.Should().Be("tt0944947");
                showCreditsCastItem.Show.Ids.Tmdb.Should().Be(1399U);
                showCreditsCastItem.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                showCreditsCastItem.Should().NotBeNull();
                showCreditsCastItem.Characters.Should().BeNull();
                showCreditsCastItem.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();
            Func<Task<ITraktPersonShowCreditsCastItem>> showCreditsCastItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await showCreditsCastItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showCreditsCastItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                showCreditsCastItem.Should().BeNull();
            }
        }
    }
}

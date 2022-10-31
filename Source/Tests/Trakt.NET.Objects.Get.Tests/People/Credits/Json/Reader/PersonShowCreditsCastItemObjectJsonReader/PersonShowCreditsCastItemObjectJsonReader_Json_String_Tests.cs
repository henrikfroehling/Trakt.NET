namespace TraktNet.Objects.Get.Tests.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCastItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            showCreditsCastItem.Should().NotBeNull();
            showCreditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            showCreditsCastItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            showCreditsCastItem.Should().NotBeNull();
            showCreditsCastItem.Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Joe Brody");
            showCreditsCastItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            showCreditsCastItem.Should().NotBeNull();
            showCreditsCastItem.Characters.Should().BeNull();
            showCreditsCastItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();
            Func<Task<ITraktPersonShowCreditsCastItem>> showCreditsCastItem = () => jsonReader.ReadObjectAsync(default(string));
            await showCreditsCastItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCastItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonShowCreditsCastItemObjectJsonReader();

            var showCreditsCastItem = await jsonReader.ReadObjectAsync(string.Empty);
            showCreditsCastItem.Should().BeNull();
        }
    }
}

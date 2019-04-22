namespace TraktNet.Objects.Tests.Get.People.Credits.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People.Credits.Json.Reader;
    using Xunit;

    [Category("Objects.Get.People.Credits.JsonReader")]
    public partial class PersonShowCreditsCrewItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().Be("Director");
            showCreditsCrewItem.Show.Should().NotBeNull();
            showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            showCreditsCrewItem.Show.Year.Should().Be(2011);
            showCreditsCrewItem.Show.Ids.Should().NotBeNull();
            showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().BeNull();
            showCreditsCrewItem.Show.Should().NotBeNull();
            showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            showCreditsCrewItem.Show.Year.Should().Be(2011);
            showCreditsCrewItem.Show.Ids.Should().NotBeNull();
            showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().Be("Director");
            showCreditsCrewItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().BeNull();
            showCreditsCrewItem.Show.Should().NotBeNull();
            showCreditsCrewItem.Show.Title.Should().Be("Game of Thrones");
            showCreditsCrewItem.Show.Year.Should().Be(2011);
            showCreditsCrewItem.Show.Ids.Should().NotBeNull();
            showCreditsCrewItem.Show.Ids.Trakt.Should().Be(1390U);
            showCreditsCrewItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            showCreditsCrewItem.Show.Ids.Tvdb.Should().Be(121361U);
            showCreditsCrewItem.Show.Ids.Imdb.Should().Be("tt0944947");
            showCreditsCrewItem.Show.Ids.Tmdb.Should().Be(1399U);
            showCreditsCrewItem.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().Be("Director");
            showCreditsCrewItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            showCreditsCrewItem.Should().NotBeNull();
            showCreditsCrewItem.Job.Should().BeNull();
            showCreditsCrewItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(default(string));
            showCreditsCrewItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonShowCreditsCrewItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonShowCreditsCrewItemObjectJsonReader();

            var showCreditsCrewItem = await jsonReader.ReadObjectAsync(string.Empty);
            showCreditsCrewItem.Should().BeNull();
        }
    }
}

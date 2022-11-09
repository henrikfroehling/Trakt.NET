namespace TraktNet.Objects.Get.Tests.People.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.People.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.People.JsonReader")]
    public partial class PersonIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(297737);
            traktPersonIds.Slug.Should().Be("bryan-cranston");
            traktPersonIds.Imdb.Should().Be("nm0186505");
            traktPersonIds.Tmdb.Should().Be(17419U);
            traktPersonIds.TvRage.Should().Be(1797U);
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            traktPersonIds.Should().NotBeNull();
            traktPersonIds.Trakt.Should().Be(0);
            traktPersonIds.Slug.Should().BeNull();
            traktPersonIds.Imdb.Should().BeNull();
            traktPersonIds.Tmdb.Should().BeNull();
            traktPersonIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PersonIdsObjectJsonReader();
            Func<Task<ITraktPersonIds>> traktPersonIds = () => jsonReader.ReadObjectAsync(default(string));
            await traktPersonIds.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PersonIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PersonIdsObjectJsonReader();

            var traktPersonIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktPersonIds.Should().BeNull();
        }
    }
}

namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonReader")]
    public partial class MostAnticipatedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();
            Func<Task<ITraktMostAnticipatedShow>> traktMostAnticipatedShow = () => jsonReader.ReadObjectAsync(default(string));
            await traktMostAnticipatedShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktMostAnticipatedShow.Should().BeNull();
        }
    }
}

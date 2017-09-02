namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            postResponseNotFoundSeason.Should().NotBeNull();
            postResponseNotFoundSeason.Ids.Should().NotBeNull();
            postResponseNotFoundSeason.Ids.Trakt.Should().Be(61430U);
            postResponseNotFoundSeason.Ids.Tvdb.Should().Be(279121U);
            postResponseNotFoundSeason.Ids.Tmdb.Should().Be(60523U);
            postResponseNotFoundSeason.Ids.TvRage.Should().Be(36939U);
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            postResponseNotFoundSeason.Should().NotBeNull();
            postResponseNotFoundSeason.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(default(string));
            postResponseNotFoundSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(string.Empty);
            postResponseNotFoundSeason.Should().BeNull();
        }
    }
}

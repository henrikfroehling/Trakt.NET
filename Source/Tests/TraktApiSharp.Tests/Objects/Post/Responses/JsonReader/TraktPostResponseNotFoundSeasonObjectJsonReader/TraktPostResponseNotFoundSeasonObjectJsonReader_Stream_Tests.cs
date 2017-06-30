namespace TraktApiSharp.Tests.Objects.Post.Responses.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Post.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class TraktPostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktPostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktPostResponseNotFoundSeasonObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundSeason.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Trakt.Should().Be(61430U);
                postResponseNotFoundSeason.Ids.Tvdb.Should().Be(279121U);
                postResponseNotFoundSeason.Ids.Tmdb.Should().Be(60523U);
                postResponseNotFoundSeason.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new TraktPostResponseNotFoundSeasonObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundSeason.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktPostResponseNotFoundSeasonObjectJsonReader();

            var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(default(Stream));
            postResponseNotFoundSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktPostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktPostResponseNotFoundSeasonObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundSeason.Should().BeNull();
            }
        }
    }
}

namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundSeason.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Trakt.Should().Be(61430U);
                postResponseNotFoundSeason.Ids.Tvdb.Should().Be(279121U);
                postResponseNotFoundSeason.Ids.Tmdb.Should().Be(60523U);
                postResponseNotFoundSeason.Ids.TvRage.Should().Be(36939U);
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                postResponseNotFoundSeason.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundSeason>> postResponseNotFoundSeason = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await postResponseNotFoundSeason.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var postResponseNotFoundSeason = await traktJsonReader.ReadObjectAsync(jsonReader);
                postResponseNotFoundSeason.Should().BeNull();
            }
        }
    }
}

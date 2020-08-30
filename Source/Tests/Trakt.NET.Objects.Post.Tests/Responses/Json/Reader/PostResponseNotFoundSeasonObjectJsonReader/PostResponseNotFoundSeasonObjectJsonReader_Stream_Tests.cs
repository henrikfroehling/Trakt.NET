namespace TraktNet.Objects.Post.Tests.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Responses;
    using TraktNet.Objects.Post.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Responses.JsonReader")]
    public partial class PostResponseNotFoundSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

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
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(stream);

                postResponseNotFoundSeason.Should().NotBeNull();
                postResponseNotFoundSeason.Ids.Should().BeNull();
            }
        }

        [Fact]
        public void Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();
            Func<Task<ITraktPostResponseNotFoundSeason>> postResponseNotFoundSeason = () => jsonReader.ReadObjectAsync(default(Stream));
            postResponseNotFoundSeason.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_PostResponseNotFoundSeasonObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new PostResponseNotFoundSeasonObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var postResponseNotFoundSeason = await jsonReader.ReadObjectAsync(stream);
                postResponseNotFoundSeason.Should().BeNull();
            }
        }
    }
}

namespace TraktNet.Objects.Basic.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Basic.JsonWriter")]
    public partial class IdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new IdsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_Trakt_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Trakt = 123
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":123}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_Slug_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Slug = "ids slug"
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":0,""slug"":""ids slug""}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_Tvdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Tvdb = 456
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":0,""tvdb"":456}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_Imdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Imdb = "ids imdb"
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":0,""imdb"":""ids imdb""}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_Tmdb_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                Tmdb = 789
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":0,""tmdb"":789}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Only_TvRage_Property()
        {
            ITraktIds traktIds = new TraktIds
            {
                TvRage = 101
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":0,""tvrage"":101}");
        }

        [Fact]
        public async Task Test_IdsObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktIds traktIds = new TraktIds
            {
                Trakt = 123,
                Slug = "ids slug",
                Tvdb = 456,
                Imdb = "ids imdb",
                Tmdb = 789,
                TvRage = 101
            };

            var traktJsonWriter = new IdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktIds);
            json.Should().Be(@"{""trakt"":123,""slug"":""ids slug"",""tvdb"":456," +
                             @"""imdb"":""ids imdb"",""tmdb"":789,""tvrage"":101}");
        }
    }
}

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
    public partial class StudioIdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_StudioIdsObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new StudioIdsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StudioIdsObjectJsonWriter_WriteObject_Only_Trakt_Property()
        {
            ITraktStudioIds traktStudioIds = new TraktStudioIds
            {
                Trakt = 20
            };

            var traktJsonWriter = new StudioIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudioIds);
            json.Should().Be(@"{""trakt"":20}");
        }

        [Fact]
        public async Task Test_StudioIdsObjectJsonWriter_WriteObject_Only_Slug_Property()
        {
            ITraktStudioIds traktStudioIds = new TraktStudioIds
            {
                Slug = "20th-century-fox"
            };

            var traktJsonWriter = new StudioIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudioIds);
            json.Should().Be(@"{""trakt"":0,""slug"":""20th-century-fox""}");
        }

        [Fact]
        public async Task Test_StudioIdsObjectJsonWriter_WriteObject_Only_Tmdb_Property()
        {
            ITraktStudioIds traktStudioIds = new TraktStudioIds
            {
                Tmdb = 25
            };

            var traktJsonWriter = new StudioIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudioIds);
            json.Should().Be(@"{""trakt"":0,""tmdb"":25}");
        }

        [Fact]
        public async Task Test_StudioIdsObjectJsonWriter_WriteObject_Complete()
        {
            ITraktStudioIds traktStudioIds = new TraktStudioIds
            {
                Trakt = 20,
                Slug = "20th-century-fox",
                Tmdb = 25
            };

            var traktJsonWriter = new StudioIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudioIds);
            json.Should().Be(@"{""trakt"":20,""slug"":""20th-century-fox"",""tmdb"":25}");
        }
    }
}

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
    public partial class StudioObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_StudioObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new StudioObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_StudioObjectJsonWriter_WriteObject_Only_Name_Property()
        {
            ITraktStudio traktStudio = new TraktStudio
            {
                Name = "20th Century Fox"
            };

            var traktJsonWriter = new StudioObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudio);
            json.Should().Be(@"{""name"":""20th Century Fox""}");
        }

        [Fact]
        public async Task Test_StudioObjectJsonWriter_WriteObject_Only_CountryCode_Property()
        {
            ITraktStudio traktStudio = new TraktStudio
            {
                CountryCode = "us"
            };

            var traktJsonWriter = new StudioObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudio);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_StudioObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktStudio traktStudio = new TraktStudio
            {
                Ids = new TraktStudioIds
                {
                    Trakt = 20,
                    Slug = "20th-century-fox",
                    Tmdb = 25
                }
            };

            var traktJsonWriter = new StudioObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudio);
            json.Should().Be(@"{""ids"":{""trakt"":20,""slug"":""20th-century-fox"",""tmdb"":25}}");
        }

        [Fact]
        public async Task Test_StudioObjectJsonWriter_WriteObject_Complete()
        {
            ITraktStudio traktStudio = new TraktStudio
            {
                Name = "20th Century Fox",
                CountryCode = "us",
                Ids = new TraktStudioIds
                {
                    Trakt = 20,
                    Slug = "20th-century-fox",
                    Tmdb = 25
                }
            };

            var traktJsonWriter = new StudioObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktStudio);
            json.Should().Be(@"{""name"":""20th Century Fox"",""country"":""us""," +
                             @"""ids"":{""trakt"":20,""slug"":""20th-century-fox"",""tmdb"":25}}");
        }
    }
}

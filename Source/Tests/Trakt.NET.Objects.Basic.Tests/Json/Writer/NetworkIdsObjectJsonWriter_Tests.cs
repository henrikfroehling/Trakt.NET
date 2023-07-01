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
    public partial class NetworkIdsObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_NetworkIdsObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new NetworkIdsObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonWriter_WriteObject_Only_Trakt_Property()
        {
            ITraktNetworkIds traktNetworkIds = new TraktNetworkIds
            {
                Trakt = 20
            };

            var traktJsonWriter = new NetworkIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetworkIds);
            json.Should().Be(@"{""trakt"":20,""tmdb"":0}");
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonWriter_WriteObject_Only_Tmdb_Property()
        {
            ITraktNetworkIds traktNetworkIds = new TraktNetworkIds
            {
                Tmdb = 25
            };

            var traktJsonWriter = new NetworkIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetworkIds);
            json.Should().Be(@"{""trakt"":0,""tmdb"":25}");
        }

        [Fact]
        public async Task Test_NetworkIdsObjectJsonWriter_WriteObject_Complete()
        {
            ITraktNetworkIds traktNetworkIds = new TraktNetworkIds
            {
                Trakt = 20,
                Tmdb = 25
            };

            var traktJsonWriter = new NetworkIdsObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetworkIds);
            json.Should().Be(@"{""trakt"":20,""tmdb"":25}");
        }
    }
}

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
    public partial class NetworkObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Exceptions()
        {
            var traktJsonWriter = new NetworkObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Only_Name_Property()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Name = "ABC"
            };

            var traktJsonWriter = new NetworkObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetwork);
            json.Should().Be(@"{""name"":""ABC""}");
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Only_CountryCode_Property()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Country = "us"
            };

            var traktJsonWriter = new NetworkObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetwork);
            json.Should().Be(@"{""country"":""us""}");
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Only_Ids_Property()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Ids = new TraktNetworkIds
                {
                    Trakt = 20,
                    Tmdb = 25
                }
            };

            var traktJsonWriter = new NetworkObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetwork);
            json.Should().Be(@"{""ids"":{""trakt"":20,""tmdb"":25}}");
        }

        [Fact]
        public async Task Test_NetworkObjectJsonWriter_WriteObject_Complete()
        {
            ITraktNetwork traktNetwork = new TraktNetwork
            {
                Name = "ABC",
                Country = "us",
                Ids = new TraktNetworkIds
                {
                    Trakt = 20,
                    Tmdb = 25
                }
            };

            var traktJsonWriter = new NetworkObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktNetwork);
            json.Should().Be(@"{""name"":""ABC"",""country"":""us""," +
                             @"""ids"":{""trakt"":20,""tmdb"":25}}");
        }
    }
}

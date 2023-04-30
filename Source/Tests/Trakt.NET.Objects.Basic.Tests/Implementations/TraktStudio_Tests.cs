namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Basic.Implementations")]
    public class TraktStudio_Tests
    {
        [Fact]
        public void Test_TraktStudio_Default_Constructor()
        {
            var traktStudio = new TraktStudio();

            traktStudio.Name.Should().BeNull();
            traktStudio.CountryCode.Should().BeNull();
            traktStudio.Ids.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktStudio_From_Json()
        {
            var jsonReader = new StudioObjectJsonReader();
            var traktStudio = await jsonReader.ReadObjectAsync(JSON) as TraktStudio;

            traktStudio.Should().NotBeNull();
            traktStudio.Name.Should().Be("20th Century Fox");
            traktStudio.CountryCode.Should().Be("us");
            traktStudio.Ids.Should().NotBeNull();
            traktStudio.Ids.Trakt.Should().Be(20U);
            traktStudio.Ids.Slug.Should().Be("20th-century-fox");
            traktStudio.Ids.Tmdb.Should().Be(25U);
        }

        private const string JSON =
            @"{
                ""name"": ""20th Century Fox"",
                ""country"": ""us"",
                ""ids"": {
                  ""trakt"": 20,
                  ""slug"": ""20th-century-fox"",
                  ""tmdb"": 25
                }
              }";
    }
}

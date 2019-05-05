namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktGenre_Tests
    {
        [Fact]
        public void Test_TraktGenre_Default_Constructor()
        {
            var traktGenre = new TraktGenre();

            traktGenre.Name.Should().BeNull();
            traktGenre.Slug.Should().BeNull();
            traktGenre.Type.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktGenre_From_Json()
        {
            var jsonReader = new GenreObjectJsonReader();
            var traktGenre = await jsonReader.ReadObjectAsync(JSON) as TraktGenre;

            traktGenre.Should().NotBeNull();
            traktGenre.Name.Should().Be("Action");
            traktGenre.Slug.Should().Be("action");
            traktGenre.Type.Should().BeNull();
        }

        private const string JSON =
            @"{
                ""name"": ""Action"",
                ""slug"": ""action""
              }";
    }
}

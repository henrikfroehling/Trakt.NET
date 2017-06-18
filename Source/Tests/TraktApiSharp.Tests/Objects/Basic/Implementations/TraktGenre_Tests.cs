namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktGenre_Tests
    {
        [Fact]
        public void Test_TraktGenre_Implements_ITraktGenre_Interface()
        {
            typeof(TraktGenre).GetInterfaces().Should().Contain(typeof(ITraktGenre));
        }

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
            var jsonReader = new TraktGenreObjectJsonReader();
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

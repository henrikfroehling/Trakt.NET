namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowAlias_Tests
    {
        [Fact]
        public void Test_TraktShowAlias_Default_Constructor()
        {
            var showAlias = new TraktShowAlias();

            showAlias.Title.Should().BeNullOrEmpty();
            showAlias.CountryCode.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktShowAlias_From_Json()
        {
            var jsonReader = new ShowAliasObjectJsonReader();
            var showAlias = await jsonReader.ReadObjectAsync(JSON) as TraktShowAlias;

            showAlias.Should().NotBeNull();
            showAlias.Title.Should().Be("Game of Thrones- Das Lied von Eis und Feuer");
            showAlias.CountryCode.Should().Be("de");
        }

        private const string JSON =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""country"": ""de""
              }";
    }
}

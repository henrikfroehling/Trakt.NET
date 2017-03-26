namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.JsonReader.Get.Shows;
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
        public void Test_TraktShowAlias_From_Json()
        {
            var jsonReader = new TraktShowAliasObjectJsonReader();
            var showAlias = jsonReader.ReadObject(JSON);

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

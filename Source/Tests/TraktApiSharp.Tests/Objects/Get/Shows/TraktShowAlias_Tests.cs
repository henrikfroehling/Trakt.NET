namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows")]
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
            var showAlias = JsonConvert.DeserializeObject<TraktShowAlias>(JSON);

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

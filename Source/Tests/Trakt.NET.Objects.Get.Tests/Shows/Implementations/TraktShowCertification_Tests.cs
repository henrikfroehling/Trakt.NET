namespace TraktNet.Objects.Get.Tests.Shows.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.Implementations")]
    public class TraktShowCertification_Tests
    {
        [Fact]
        public void Test_TraktShowCertification_Default_Constructor()
        {
            var showCertification = new TraktShowCertification();

            showCertification.Certification.Should().BeNull();
            showCertification.CountryCode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowCertification_From_Json()
        {
            var jsonReader = new ShowCertificationObjectJsonReader();
            var showCertification = await jsonReader.ReadObjectAsync(JSON) as TraktShowCertification;

            showCertification.Should().NotBeNull();
            showCertification.Certification.Should().Be("TV-MA");
            showCertification.CountryCode.Should().Be("us");
        }

        private const string JSON =
            @"{
                ""certification"": ""TV-MA"",
                ""country"": ""us""
              }";
    }
}

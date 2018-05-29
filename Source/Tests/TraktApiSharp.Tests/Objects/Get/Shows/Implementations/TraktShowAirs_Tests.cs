namespace TraktApiSharp.Tests.Objects.Get.Shows.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.Implementations")]
    public class TraktShowAirs_Tests
    {
        [Fact]
        public void Test_TraktShowAirs_Default_Constructor()
        {
            var showAirs = new TraktShowAirs();

            showAirs.Day.Should().BeNullOrEmpty();
            showAirs.Time.Should().BeNullOrEmpty();
            showAirs.TimeZoneId.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Test_TraktShowAirs_From_Json()
        {
            var jsonReader = new ShowAirsObjectJsonReader();
            var showAirs = await jsonReader.ReadObjectAsync(JSON) as TraktShowAirs;

            showAirs.Should().NotBeNull();
            showAirs.Day.Should().Be("Sunday");
            showAirs.Time.Should().Be("21:00");
            showAirs.TimeZoneId.Should().Be("America/New_York");
        }

        private const string JSON =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";
    }
}

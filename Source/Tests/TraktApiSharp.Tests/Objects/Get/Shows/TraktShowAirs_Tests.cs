namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows")]
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
        public void Test_TraktShowAirs_From_Json()
        {
            var showAirs = JsonConvert.DeserializeObject<TraktShowAirs>(JSON);

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

namespace TraktNET.Json.Shows
{
    public sealed class TraktShowAirsTests
    {
        [Fact]
        public void TestTraktShowAirsConstructor()
        {
            var showAirs = new TraktShowAirs();

            showAirs.Day.Should().BeNull();
            showAirs.Time.Should().BeNull();
            showAirs.Timezone.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktShowAirsFromJson()
        {
            TraktShowAirs? showAirs = await TestUtility.DeserializeJsonAsync<TraktShowAirs>("Shows\\showairs.json");

            showAirs.Should().NotBeNull();

            showAirs!.Day.Should().Be(TraktDayOfWeek.Sunday);
            showAirs!.Time.Should().Be(TestUtility.ParseTime("21:00"));
            showAirs!.Timezone.Should().Be("America/New_York");
        }
    }
}

namespace TraktNET.Json.Shows
{
    public sealed class TraktShowAirsTests
    {
        [Fact]
        public void TestTraktShowAirsConstructor()
        {
            var showAirs = new TraktShowAirs();

            showAirs.Day.ShouldBeNull();
            showAirs.Time.ShouldBeNull();
            showAirs.Timezone.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktShowAirsFromJson()
        {
            TraktShowAirs? showAirs = await TraktTestUtility.DeserializeJsonAsync<TraktShowAirs>("Shows\\showairs.json");

            showAirs.ShouldNotBeNull();

            showAirs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            showAirs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            showAirs!.Time.ShouldBe("21:00");
#endif
            showAirs!.Timezone.ShouldBe("America/New_York");
        }
    }
}

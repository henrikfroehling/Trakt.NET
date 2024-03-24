namespace TraktNET.Enums
{
    public sealed class TraktShowStatusTests
    {
        [Fact]
        public void TestTraktShowStatusToJson()
        {
            TraktShowStatus.Unspecified.ToJson().Should().BeNull();
            TraktShowStatus.ReturningSeries.ToJson().Should().Be("returning_series");
            TraktShowStatus.Continuing.ToJson().Should().Be("continuing");
            TraktShowStatus.InProduction.ToJson().Should().Be("in_production");
            TraktShowStatus.Planned.ToJson().Should().Be("planned");
            TraktShowStatus.Upcoming.ToJson().Should().Be("upcoming");
            TraktShowStatus.Pilot.ToJson().Should().Be("pilot");
            TraktShowStatus.Canceled.ToJson().Should().Be("canceled");
            TraktShowStatus.Ended.ToJson().Should().Be("ended");
        }

        [Fact]
        public void TestTraktShowStatusFromJson()
        {
            "unspecified".ToTraktShowStatus().Should().Be(TraktShowStatus.Unspecified);
            "returning_series".ToTraktShowStatus().Should().Be(TraktShowStatus.ReturningSeries);
            "continuing".ToTraktShowStatus().Should().Be(TraktShowStatus.Continuing);
            "in_production".ToTraktShowStatus().Should().Be(TraktShowStatus.InProduction);
            "planned".ToTraktShowStatus().Should().Be(TraktShowStatus.Planned);
            "upcoming".ToTraktShowStatus().Should().Be(TraktShowStatus.Upcoming);
            "pilot".ToTraktShowStatus().Should().Be(TraktShowStatus.Pilot);
            "canceled".ToTraktShowStatus().Should().Be(TraktShowStatus.Canceled);
            "ended".ToTraktShowStatus().Should().Be(TraktShowStatus.Ended);

            string? nullValue = null;
            nullValue.ToTraktShowStatus().Should().Be(TraktShowStatus.Unspecified);
        }

        [Fact]
        public void TestTraktShowStatusDisplayName()
        {
            TraktShowStatus.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktShowStatus.ReturningSeries.DisplayName().Should().Be("Returning Series");
            TraktShowStatus.Continuing.DisplayName().Should().Be("Continuing");
            TraktShowStatus.InProduction.DisplayName().Should().Be("In Production");
            TraktShowStatus.Planned.DisplayName().Should().Be("Planned");
            TraktShowStatus.Upcoming.DisplayName().Should().Be("Upcoming");
            TraktShowStatus.Pilot.DisplayName().Should().Be("Pilot");
            TraktShowStatus.Canceled.DisplayName().Should().Be("Canceled");
            TraktShowStatus.Ended.DisplayName().Should().Be("Ended");
        }
    }
}

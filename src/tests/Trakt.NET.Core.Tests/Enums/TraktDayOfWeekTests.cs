namespace TraktNET.Enums
{
    public sealed class TraktDayOfWeekTests
    {
        [Fact]
        public void TestTraktDayOfWeekToJson()
        {
            TraktDayOfWeek.Unspecified.ToJson().Should().BeNull();
            TraktDayOfWeek.Monday.ToJson().Should().Be("Monday");
            TraktDayOfWeek.Tuesday.ToJson().Should().Be("Tuesday");
            TraktDayOfWeek.Wednesday.ToJson().Should().Be("Wednesday");
            TraktDayOfWeek.Thursday.ToJson().Should().Be("Thursday");
            TraktDayOfWeek.Friday.ToJson().Should().Be("Friday");
            TraktDayOfWeek.Saturday.ToJson().Should().Be("Saturday");
            TraktDayOfWeek.Sunday.ToJson().Should().Be("Sunday");
        }

        [Fact]
        public void TestTraktDayOfWeekFromJson()
        {
            "unspecified".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Unspecified);
            "Monday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Monday);
            "Tuesday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Tuesday);
            "Wednesday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Wednesday);
            "Thursday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Thursday);
            "Friday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Friday);
            "Saturday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Saturday);
            "Sunday".ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Sunday);

            string? nullValue = null;
            nullValue.ToTraktDayOfWeek().Should().Be(TraktDayOfWeek.Unspecified);
        }

        [Fact]
        public void TestTraktDayOfWeekDisplayName()
        {
            TraktDayOfWeek.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktDayOfWeek.Monday.DisplayName().Should().Be("Monday");
            TraktDayOfWeek.Tuesday.DisplayName().Should().Be("Tuesday");
            TraktDayOfWeek.Wednesday.DisplayName().Should().Be("Wednesday");
            TraktDayOfWeek.Thursday.DisplayName().Should().Be("Thursday");
            TraktDayOfWeek.Friday.DisplayName().Should().Be("Friday");
            TraktDayOfWeek.Saturday.DisplayName().Should().Be("Saturday");
            TraktDayOfWeek.Sunday.DisplayName().Should().Be("Sunday");
        }
    }
}

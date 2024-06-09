namespace TraktNET.Enums
{
    public sealed class TraktMovieStatusTests
    {
        [Fact]
        public void TestTraktMovieStatusToJson()
        {
            TraktMovieStatus.Unspecified.ToJson().Should().BeNull();
            TraktMovieStatus.Released.ToJson().Should().Be("released");
            TraktMovieStatus.InProduction.ToJson().Should().Be("in_production");
            TraktMovieStatus.PostProduction.ToJson().Should().Be("post_production");
            TraktMovieStatus.Planned.ToJson().Should().Be("planned");
            TraktMovieStatus.Rumored.ToJson().Should().Be("rumored");
            TraktMovieStatus.Canceled.ToJson().Should().Be("canceled");
        }

        [Fact]
        public void TestTraktMovieStatusFromJson()
        {
            "unspecified".ToTraktMovieStatus().Should().Be(TraktMovieStatus.Unspecified);
            "released".ToTraktMovieStatus().Should().Be(TraktMovieStatus.Released);
            "in_production".ToTraktMovieStatus().Should().Be(TraktMovieStatus.InProduction);
            "post_production".ToTraktMovieStatus().Should().Be(TraktMovieStatus.PostProduction);
            "planned".ToTraktMovieStatus().Should().Be(TraktMovieStatus.Planned);
            "rumored".ToTraktMovieStatus().Should().Be(TraktMovieStatus.Rumored);
            "canceled".ToTraktMovieStatus().Should().Be(TraktMovieStatus.Canceled);

            string? nullValue = null;
            nullValue.ToTraktMovieStatus().Should().Be(TraktMovieStatus.Unspecified);
        }

        [Fact]
        public void TestTraktMovieStatusDisplayName()
        {
            TraktMovieStatus.Unspecified.DisplayName().Should().Be("Unspecified");
            TraktMovieStatus.Released.DisplayName().Should().Be("Released");
            TraktMovieStatus.InProduction.DisplayName().Should().Be("In Production");
            TraktMovieStatus.PostProduction.DisplayName().Should().Be("Post Production");
            TraktMovieStatus.Planned.DisplayName().Should().Be("Planned");
            TraktMovieStatus.Rumored.DisplayName().Should().Be("Rumored");
            TraktMovieStatus.Canceled.DisplayName().Should().Be("Canceled");
        }
    }
}

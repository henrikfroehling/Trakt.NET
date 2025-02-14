namespace TraktNET.Enums
{
    public sealed class TMDBStillSizeTests
    {
        [Fact]
        public void TestTMDBStillSizeToJson()
        {
            TMDBStillSize.Unspecified.ToJson().ShouldBeNull();
            TMDBStillSize.Width82.ToJson().ShouldBe("w92");
            TMDBStillSize.Width185.ToJson().ShouldBe("w185");
            TMDBStillSize.Width300.ToJson().ShouldBe("w300");
            TMDBStillSize.Original.ToJson().ShouldBe("original");
        }

        [Fact]
        public void TestTMDBStillSizeFromJson()
        {
            "unspecified".ToTMDBStillSize().ShouldBe(TMDBStillSize.Unspecified);
            "w92".ToTMDBStillSize().ShouldBe(TMDBStillSize.Width82);
            "w185".ToTMDBStillSize().ShouldBe(TMDBStillSize.Width185);
            "w300".ToTMDBStillSize().ShouldBe(TMDBStillSize.Width300);
            "original".ToTMDBStillSize().ShouldBe(TMDBStillSize.Original);

            string? nullValue = null;
            nullValue.ToTMDBStillSize().ShouldBe(TMDBStillSize.Unspecified);
        }

        [Fact]
        public void TestTMDBStillSizeDisplayName()
        {
            TMDBStillSize.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBStillSize.Width82.DisplayName().ShouldBe("Width 92");
            TMDBStillSize.Width185.DisplayName().ShouldBe("Width 185");
            TMDBStillSize.Width300.DisplayName().ShouldBe("Width 300");
            TMDBStillSize.Original.DisplayName().ShouldBe("Original");
        }
    }
}

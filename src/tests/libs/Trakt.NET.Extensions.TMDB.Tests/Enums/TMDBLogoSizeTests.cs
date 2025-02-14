namespace TraktNET.Enums
{
    public sealed class TMDBLogoSizeTests
    {
        [Fact]
        public void TestTMDBLogoSizeToJson()
        {
            TMDBLogoSize.Unspecified.ToJson().ShouldBeNull();
            TMDBLogoSize.Width45.ToJson().ShouldBe("w45");
            TMDBLogoSize.Width92.ToJson().ShouldBe("w92");
            TMDBLogoSize.Width154.ToJson().ShouldBe("w154");
            TMDBLogoSize.Width185.ToJson().ShouldBe("w185");
            TMDBLogoSize.Width300.ToJson().ShouldBe("w300");
            TMDBLogoSize.Width500.ToJson().ShouldBe("w500");
            TMDBLogoSize.Original.ToJson().ShouldBe("original");
        }

        [Fact]
        public void TestTMDBLogoSizeFromJson()
        {
            "unspecified".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Unspecified);
            "w45".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width45);
            "w92".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width92);
            "w154".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width154);
            "w185".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width185);
            "w300".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width300);
            "w500".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Width500);
            "original".ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Original);

            string? nullValue = null;
            nullValue.ToTMDBLogoSize().ShouldBe(TMDBLogoSize.Unspecified);
        }

        [Fact]
        public void TestTMDBLogoSizeDisplayName()
        {
            TMDBLogoSize.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBLogoSize.Width45.DisplayName().ShouldBe("Width 45");
            TMDBLogoSize.Width92.DisplayName().ShouldBe("Width 92");
            TMDBLogoSize.Width154.DisplayName().ShouldBe("Width 154");
            TMDBLogoSize.Width185.DisplayName().ShouldBe("Width 185");
            TMDBLogoSize.Width300.DisplayName().ShouldBe("Width 300");
            TMDBLogoSize.Width500.DisplayName().ShouldBe("Width 500");
            TMDBLogoSize.Original.DisplayName().ShouldBe("Original");
        }
    }
}

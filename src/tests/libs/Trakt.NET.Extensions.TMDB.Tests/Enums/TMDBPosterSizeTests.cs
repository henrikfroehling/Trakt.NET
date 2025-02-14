namespace TraktNET.Enums
{
    public sealed class TMDBPosterSizeTests
    {
        [Fact]
        public void TestTMDBPosterSizeToJson()
        {
            TMDBPosterSize.Unspecified.ToJson().ShouldBeNull();
            TMDBPosterSize.Width92.ToJson().ShouldBe("w92");
            TMDBPosterSize.Width154.ToJson().ShouldBe("w154");
            TMDBPosterSize.Width185.ToJson().ShouldBe("w185");
            TMDBPosterSize.Width342.ToJson().ShouldBe("w342");
            TMDBPosterSize.Width500.ToJson().ShouldBe("w500");
            TMDBPosterSize.Width780.ToJson().ShouldBe("w780");
            TMDBPosterSize.Original.ToJson().ShouldBe("original");
        }

        [Fact]
        public void TestTMDBPosterSizeFromJson()
        {
            "unspecified".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Unspecified);
            "w92".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width92);
            "w154".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width154);
            "w185".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width185);
            "w342".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width342);
            "w500".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width500);
            "w780".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Width780);
            "original".ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Original);

            string? nullValue = null;
            nullValue.ToTMDBPosterSize().ShouldBe(TMDBPosterSize.Unspecified);
        }

        [Fact]
        public void TestTMDBPosterSizeDisplayName()
        {
            TMDBPosterSize.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBPosterSize.Width92.DisplayName().ShouldBe("Width 92");
            TMDBPosterSize.Width154.DisplayName().ShouldBe("Width 154");
            TMDBPosterSize.Width185.DisplayName().ShouldBe("Width 185");
            TMDBPosterSize.Width342.DisplayName().ShouldBe("Width 342");
            TMDBPosterSize.Width500.DisplayName().ShouldBe("Width 500");
            TMDBPosterSize.Width780.DisplayName().ShouldBe("Width 780");
            TMDBPosterSize.Original.DisplayName().ShouldBe("Original");
        }
    }
}

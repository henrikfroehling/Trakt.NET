namespace TraktNET.Enums
{
    public sealed class TMDBProfileSizeTests
    {
        [Fact]
        public void TestTMDBProfileSizeToJson()
        {
            TMDBProfileSize.Unspecified.ToJson().ShouldBeNull();
            TMDBProfileSize.Width45.ToJson().ShouldBe("w45");
            TMDBProfileSize.Width185.ToJson().ShouldBe("w185");
            TMDBProfileSize.Height632.ToJson().ShouldBe("h632");
            TMDBProfileSize.Original.ToJson().ShouldBe("original");
        }

        [Fact]
        public void TestTMDBProfileSizeFromJson()
        {
            "unspecified".ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Unspecified);
            "w45".ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Width45);
            "w185".ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Width185);
            "h632".ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Height632);
            "original".ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Original);

            string? nullValue = null;
            nullValue.ToTMDBProfileSize().ShouldBe(TMDBProfileSize.Unspecified);
        }

        [Fact]
        public void TestTMDBProfileSizeDisplayName()
        {
            TMDBProfileSize.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBProfileSize.Width45.DisplayName().ShouldBe("Width 45");
            TMDBProfileSize.Width185.DisplayName().ShouldBe("Width 185");
            TMDBProfileSize.Height632.DisplayName().ShouldBe("Height 632");
            TMDBProfileSize.Original.DisplayName().ShouldBe("Original");
        }
    }
}

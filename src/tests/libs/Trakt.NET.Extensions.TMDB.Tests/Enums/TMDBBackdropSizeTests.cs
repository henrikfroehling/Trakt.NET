namespace TraktNET.Enums
{
    public sealed class TMDBBackdropSizeTests
    {
        [Fact]
        public void TestTMDBBackdropSizeToJson()
        {
            TMDBBackdropSize.Unspecified.ToJson().ShouldBeNull();
            TMDBBackdropSize.Width300.ToJson().ShouldBe("w300");
            TMDBBackdropSize.Width780.ToJson().ShouldBe("w780");
            TMDBBackdropSize.Width1280.ToJson().ShouldBe("w1280");
            TMDBBackdropSize.Original.ToJson().ShouldBe("original");
        }

        [Fact]
        public void TestTMDBBackdropSizeFromJson()
        {
            "unspecified".ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Unspecified);
            "w300".ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Width300);
            "w780".ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Width780);
            "w1280".ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Width1280);
            "original".ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Original);

            string? nullValue = null;
            nullValue.ToTMDBBackdropSize().ShouldBe(TMDBBackdropSize.Unspecified);
        }

        [Fact]
        public void TestTMDBBackdropSizeDisplayName()
        {
            TMDBBackdropSize.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBBackdropSize.Width300.DisplayName().ShouldBe("Width 300");
            TMDBBackdropSize.Width780.DisplayName().ShouldBe("Width 780");
            TMDBBackdropSize.Width1280.DisplayName().ShouldBe("Width 1280");
            TMDBBackdropSize.Original.DisplayName().ShouldBe("Original");
        }
    }
}

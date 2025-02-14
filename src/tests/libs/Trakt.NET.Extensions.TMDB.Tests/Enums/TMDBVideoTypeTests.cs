namespace TraktNET.Enums
{
    public sealed class TMDBVideoTypeTests
    {
        [Fact]
        public void TestTMDBVideoTypeToJson()
        {
            TMDBVideoType.Unspecified.ToJson().ShouldBeNull();
            TMDBVideoType.Trailer.ToJson().ShouldBe("Trailer");
            TMDBVideoType.Teaser.ToJson().ShouldBe("Teaser");
            TMDBVideoType.Clip.ToJson().ShouldBe("Clip");
            TMDBVideoType.BehindTheScenes.ToJson().ShouldBe("Behind the Scenes");
            TMDBVideoType.Bloopers.ToJson().ShouldBe("Bloopers");
            TMDBVideoType.Featurette.ToJson().ShouldBe("Featurette");
            TMDBVideoType.OpeningCredits.ToJson().ShouldBe("Opening Credits");
        }

        [Fact]
        public void TestTMDBVideoTypeFromJson()
        {
            "unspecified".ToTMDBVideoType().ShouldBe(TMDBVideoType.Unspecified);
            "Trailer".ToTMDBVideoType().ShouldBe(TMDBVideoType.Trailer);
            "Teaser".ToTMDBVideoType().ShouldBe(TMDBVideoType.Teaser);
            "Clip".ToTMDBVideoType().ShouldBe(TMDBVideoType.Clip);
            "Behind the Scenes".ToTMDBVideoType().ShouldBe(TMDBVideoType.BehindTheScenes);
            "Bloopers".ToTMDBVideoType().ShouldBe(TMDBVideoType.Bloopers);
            "Featurette".ToTMDBVideoType().ShouldBe(TMDBVideoType.Featurette);
            "Opening Credits".ToTMDBVideoType().ShouldBe(TMDBVideoType.OpeningCredits);

            string? nullValue = null;
            nullValue.ToTMDBVideoType().ShouldBe(TMDBVideoType.Unspecified);
        }

        [Fact]
        public void TestTMDBVideoTypeDisplayName()
        {
            TMDBVideoType.Unspecified.DisplayName().ShouldBe("Unspecified");
            TMDBVideoType.Trailer.DisplayName().ShouldBe("Trailer");
            TMDBVideoType.Teaser.DisplayName().ShouldBe("Teaser");
            TMDBVideoType.Clip.DisplayName().ShouldBe("Clip");
            TMDBVideoType.BehindTheScenes.DisplayName().ShouldBe("Behind the Scenes");
            TMDBVideoType.Bloopers.DisplayName().ShouldBe("Bloopers");
            TMDBVideoType.Featurette.DisplayName().ShouldBe("Featurette");
            TMDBVideoType.OpeningCredits.DisplayName().ShouldBe("Opening Credits");
        }
    }
}

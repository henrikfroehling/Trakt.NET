namespace TraktNET.Json.General
{
    public sealed class TraktVideoTests
    {
        [Fact]
        public void TestTraktVideoConstructor()
        {
            var video = new TraktVideo();

            video.Title.ShouldBeNull();
            video.Url.ShouldBeNull();
            video.Site.ShouldBeNull();
            video.Type.ShouldBeNull();
            video.Size.ShouldBeNull();
            video.Official.ShouldBeNull();
            video.PublishedAt.ShouldBeNull();
            video.Country.ShouldBeNull();
            video.Language.ShouldBeNull();

            video.CultureName().ShouldBeEmpty();
            video.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktVideoFromJson()
        {
            TraktVideo? video = await TraktTestUtility.DeserializeJsonAsync<TraktVideo>("General\\video.json");

            video.ShouldNotBeNull();

            video!.Title.ShouldBe("Disney+ Promo");
            video!.Url.ShouldBe("https://youtube.com/watch?v=3RLT34SwtQc");
            video!.Site.ShouldBe("youtube");
            video!.Type.ShouldBe(TraktVideoType.Teaser);
            video!.Size.ShouldBe(1080U);
            video!.Official.ShouldBe(true);
            video!.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-08-03T18:00:02.000Z"));
            video!.Country.ShouldBe("us");
            video!.Language.ShouldBe("en");

            video!.CultureName().ShouldBe("en-US");
            video!.ToString().ShouldBe("Teaser: Disney+ Promo");
        }

        [Fact]
        public async Task TestTraktVideosFromJson()
        {
            IReadOnlyList<TraktVideo>? videos = await TraktTestUtility.DeserializeJsonListAsync<TraktVideo>("General\\videos.json");

            videos.ShouldNotBeNull();
            videos!.Count.ShouldBe(2);

            TraktVideo video = videos![0];

            video.ShouldNotBeNull();

            video.Title.ShouldBe("Disney+ Promo");
            video.Url.ShouldBe("https://youtube.com/watch?v=3RLT34SwtQc");
            video.Site.ShouldBe("youtube");
            video.Type.ShouldBe(TraktVideoType.Teaser);
            video.Size.ShouldBe(1080U);
            video.Official.ShouldBe(true);
            video.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-08-03T18:00:02.000Z"));
            video.Country.ShouldBe("us");
            video.Language.ShouldBe("en");

            video.CultureName().ShouldBe("en-US");
            video.ToString().ShouldBe("Teaser: Disney+ Promo");

            // --------------------------------------------------------------------------------------------

            video = videos![1];

            video.ShouldNotBeNull();

            video.Title.ShouldBe("Now Streaming on Disney+");
            video.Url.ShouldBe("https://youtube.com/watch?v=D3NpwOB69Ys");
            video.Site.ShouldBe("youtube");
            video.Type.ShouldBe(TraktVideoType.Teaser);
            video.Size.ShouldBe(1080U);
            video.Official.ShouldBe(true);
            video.PublishedAt.ShouldBe(TestUtility.ParseUTCDateTime("2023-08-02T16:00:17.000Z"));
            video.Country.ShouldBe("us");
            video.Language.ShouldBe("en");

            video.CultureName().ShouldBe("en-US");
            video.ToString().ShouldBe("Teaser: Now Streaming on Disney+");
        }
    }
}

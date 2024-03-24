namespace TraktNET.Json.Shows
{
    public sealed class TraktShowTests
    {
        [Fact]
        public void TestTraktShowConstructor()
        {
            var show = new TraktShow();

            show.Title.Should().BeNull();
            show.Year.Should().BeNull();
            show.Ids.Should().BeNull();
            show.Tagline.Should().BeNull();
            show.Overview.Should().BeNull();
            show.FirstAired.Should().BeNull();
            show.UpdatedAt.Should().BeNull();
            show.Airs.Should().BeNull();
            show.Runtime.Should().BeNull();
            show.Certification.Should().BeNull();
            show.Network.Should().BeNull();
            show.Country.Should().BeNull();
            show.Trailer.Should().BeNull();
            show.Homepage.Should().BeNull();
            show.Rating.Should().BeNull();
            show.Votes.Should().BeNull();
            show.CommentCount.Should().BeNull();
            show.Language.Should().BeNull();
            show.Languages.Should().BeNull();
            show.AvailableTranslations.Should().BeNull();
            show.Genres.Should().BeNull();
            show.AiredEpisodes.Should().BeNull();
            show.Status.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktShowFromJsonMinimal()
        {
            TraktShowMinimal? show = await TestUtility.DeserializeJsonAsync<TraktShowMinimal>("Shows\\show_minimal.json");

            show.Should().NotBeNull();

            show!.Title.Should().Be("Game of Thrones");
            show!.Year.Should().Be(2011U);

            show!.Ids.Should().NotBeNull();
            show!.Ids!.Trakt.Should().Be(1390U);
            show!.Ids!.Slug.Should().Be("game-of-thrones");
            show!.Ids!.TVDB.Should().Be(121361U);
            show!.Ids!.IMDB.Should().Be("tt0944947");
            show!.Ids!.TMDB.Should().Be(1399U);
            show!.Ids!.HasAnyID.Should().BeTrue();
            show!.Ids!.BestID.Should().Be("1390");
        }

        [Fact]
        public async Task TestTraktShowFromJson()
        {
            TraktShow? show = await TestUtility.DeserializeJsonAsync<TraktShow>("Shows\\show.json");

            show.Should().NotBeNull();

            show!.Title.Should().Be("Game of Thrones");
            show!.Year.Should().Be(2011U);

            show!.Ids.Should().NotBeNull();
            show!.Ids!.Trakt.Should().Be(1390U);
            show!.Ids!.Slug.Should().Be("game-of-thrones");
            show!.Ids!.TVDB.Should().Be(121361U);
            show!.Ids!.IMDB.Should().Be("tt0944947");
            show!.Ids!.TMDB.Should().Be(1399U);
            show!.Ids!.HasAnyID.Should().BeTrue();
            show!.Ids!.BestID.Should().Be("1390");

            show!.Tagline.Should().Be("Winter is coming.");
            show!.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            show!.FirstAired.Should().Be(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            show!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z"));

            show!.Airs.Should().NotBeNull();
            show!.Airs!.Day.Should().Be(TraktDayOfWeek.Sunday);
            show!.Airs!.Time.Should().Be(TestUtility.ParseTime("21:00"));
            show!.Airs!.Timezone.Should().Be("America/New_York");

            show!.Runtime.Should().Be(57U);
            show!.Certification.Should().Be("TV-MA");
            show!.Network.Should().Be("HBO");
            show!.Country.Should().Be("us");
            show!.Trailer.Should().Be("https://youtube.com/watch?v=KPLWWIOCOOQ");
            show!.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            show!.Rating.Should().Be(8.933884809616755f);
            show!.Votes.Should().Be(129108U);
            show!.CommentCount.Should().Be(414U);
            show!.Language.Should().Be("en");
            show!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            show!.AvailableTranslations.Should().NotBeNull().And.HaveCount(48).And.BeEquivalentTo([
                "ar", "be", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "eo", "es", "et", "fa", "fi",
                "fr", "he", "hr", "hu", "id", "is", "it", "ja", "ka", "ko", "lb", "lt", "lv", "ml", "nl",
                "no", "pl", "pt", "ro", "ru", "sk", "sl", "so", "sr", "sv", "ta", "th", "tr", "tw", "uk",
                "uz", "vi", "zh"
            ]);

            show!.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "fantasy", "drama", "action", "adventure"
            ]);

            show!.AiredEpisodes.Should().Be(73U);
            show!.Status.Should().Be(TraktShowStatus.Ended);
        }
    }
}

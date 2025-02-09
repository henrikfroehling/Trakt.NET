namespace TraktNET.Json.Shows
{
    public sealed class TraktShowTests
    {
        [Fact]
        public void TestTraktShowConstructor()
        {
            var show = new TraktShow();

            show.Title.ShouldBeNull();
            show.Year.ShouldBeNull();
            show.IDs.ShouldBeNull();
            show.Tagline.ShouldBeNull();
            show.Overview.ShouldBeNull();
            show.FirstAired.ShouldBeNull();
            show.UpdatedAt.ShouldBeNull();
            show.Airs.ShouldBeNull();
            show.Runtime.ShouldBeNull();
            show.Certification.ShouldBeNull();
            show.Network.ShouldBeNull();
            show.Country.ShouldBeNull();
            show.Trailer.ShouldBeNull();
            show.Homepage.ShouldBeNull();
            show.Rating.ShouldBeNull();
            show.Votes.ShouldBeNull();
            show.CommentCount.ShouldBeNull();
            show.Language.ShouldBeNull();
            show.Languages.ShouldBeNull();
            show.AvailableTranslations.ShouldBeNull();
            show.Genres.ShouldBeNull();
            show.AiredEpisodes.ShouldBeNull();
            show.Status.ShouldBeNull();

            show.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktShowFromJsonMinimal()
        {
            TraktShowMinimal? show = await TestUtility.DeserializeJsonAsync<TraktShowMinimal>("Shows\\show_minimal.json");

            show.ShouldNotBeNull();

            show!.Title.ShouldBe("Game of Thrones");
            show!.Year.ShouldBe(2011U);

            show!.IDs.ShouldNotBeNull();
            show!.IDs!.Trakt.ShouldBe(1390U);
            show!.IDs!.Slug.ShouldBe("game-of-thrones");
            show!.IDs!.TVDB.ShouldBe(121361U);
            show!.IDs!.IMDB.ShouldBe("tt0944947");
            show!.IDs!.TMDB.ShouldBe(1399U);
            show!.IDs!.HasAnyID.ShouldBe(true);
            show!.IDs!.BestID.ShouldBe("game-of-thrones");

            show!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktShowFromJsonMinimalWithImages()
        {
            TraktShowMinimal? show = await TestUtility.DeserializeJsonAsync<TraktShowMinimal>("Shows\\show_minimal_images.json");

            show.ShouldNotBeNull();

            show!.Title.ShouldBe("Game of Thrones");
            show!.Year.ShouldBe(2011U);

            show!.IDs.ShouldNotBeNull();
            show!.IDs!.Trakt.ShouldBe(1390U);
            show!.IDs!.Slug.ShouldBe("game-of-thrones");
            show!.IDs!.TVDB.ShouldBe(121361U);
            show!.IDs!.IMDB.ShouldBe("tt0944947");
            show!.IDs!.TMDB.ShouldBe(1399U);
            show!.IDs!.HasAnyID.ShouldBe(true);
            show!.IDs!.BestID.ShouldBe("game-of-thrones");

            show!.Images.ShouldNotBeNull();

            show!.Images!.Fanart.ShouldNotBeNull();
            show!.Images!.Fanart!.Count.ShouldBe(1);
            show!.Images!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/fanarts/medium/76d5df8aed.jpg.webp" ]);

            show!.Images!.Poster.ShouldNotBeNull();
            show!.Images!.Poster!.Count.ShouldBe(1);
            show!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/posters/thumb/93df9cd612.jpg.webp" ]);

            show!.Images!.Logo.ShouldNotBeNull();
            show!.Images!.Logo!.Count.ShouldBe(1);
            show!.Images!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/logos/medium/13b614ad43.png.webp" ]);

            show!.Images!.Clearart.ShouldNotBeNull();
            show!.Images!.Clearart!.Count.ShouldBe(1);
            show!.Images!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/cleararts/medium/5cbde9e647.png.webp" ]);

            show!.Images!.Banner.ShouldNotBeNull();
            show!.Images!.Banner!.Count.ShouldBe(1);
            show!.Images!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/banners/medium/9fefff703d.jpg.webp" ]);

            show!.Images!.Thumb.ShouldNotBeNull();
            show!.Images!.Thumb!.Count.ShouldBe(1);
            show!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/thumbs/medium/7beccbd5a1.jpg.webp" ]);

            show!.ToString().ShouldBe("Game of Thrones (2011)");
        }

        [Fact]
        public async Task TestTraktShowFromJsonFull()
        {
            TraktShow? show = await TestUtility.DeserializeJsonAsync<TraktShow>("Shows\\show_full.json");

            show.ShouldNotBeNull();

            show!.Title.ShouldBe("Game of Thrones");
            show!.Year.ShouldBe(2011U);

            show!.IDs.ShouldNotBeNull();
            show!.IDs!.Trakt.ShouldBe(1390U);
            show!.IDs!.Slug.ShouldBe("game-of-thrones");
            show!.IDs!.TVDB.ShouldBe(121361U);
            show!.IDs!.IMDB.ShouldBe("tt0944947");
            show!.IDs!.TMDB.ShouldBe(1399U);
            show!.IDs!.HasAnyID.ShouldBe(true);
            show!.IDs!.BestID.ShouldBe("game-of-thrones");

            show!.ToString().ShouldBe("Game of Thrones (2011)");

            show!.Tagline.ShouldBe("Winter is coming.");
            show!.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");
            show!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            show!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z"));

            show!.Airs.ShouldNotBeNull();
            show!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            show!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            show!.Airs!.Time.ShouldBe("21:00");
#endif
            show!.Airs!.Timezone.ShouldBe("America/New_York");

            show!.Runtime.ShouldBe(57U);
            show!.Certification.ShouldBe("TV-MA");
            show!.Network.ShouldBe("HBO");
            show!.Country.ShouldBe("us");
            show!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            show!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            show!.Rating.ShouldBe(8.933884809616755f);
            show!.Votes.ShouldBe(129108U);
            show!.CommentCount.ShouldBe(414U);
            show!.Language.ShouldBe("en");
            show!.Languages.ShouldNotBeNull();
            show!.Languages!.Count.ShouldBe(1);
            show!.Languages!.ShouldBe(["en"], Case.Sensitive);

            show!.AvailableTranslations.ShouldNotBeNull();
            show!.AvailableTranslations!.Count.ShouldBe(48);
            show!.AvailableTranslations!.ShouldBe([
                "ar", "be", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "eo", "es", "et", "fa", "fi",
                "fr", "he", "hr", "hu", "id", "is", "it", "ja", "ka", "ko", "lb", "lt", "lv", "ml", "nl",
                "no", "pl", "pt", "ro", "ru", "sk", "sl", "so", "sr", "sv", "ta", "th", "tr", "tw", "uk",
                "uz", "vi", "zh"
            ], Case.Sensitive);

            show!.Genres.ShouldNotBeNull();
            show!.Genres!.Count.ShouldBe(4);
            show!.Genres!.ShouldBe([
                "fantasy", "drama", "action", "adventure"
            ], Case.Sensitive);

            show!.AiredEpisodes.ShouldBe(73U);
            show!.Status.ShouldBe(TraktShowStatus.Ended);
        }

        [Fact]
        public async Task TestTraktShowFromJsonFullWithImages()
        {
            TraktShow? show = await TestUtility.DeserializeJsonAsync<TraktShow>("Shows\\show_full_images.json");

            show.ShouldNotBeNull();

            show!.Title.ShouldBe("Game of Thrones");
            show!.Year.ShouldBe(2011U);

            show!.IDs.ShouldNotBeNull();
            show!.IDs!.Trakt.ShouldBe(1390U);
            show!.IDs!.Slug.ShouldBe("game-of-thrones");
            show!.IDs!.TVDB.ShouldBe(121361U);
            show!.IDs!.IMDB.ShouldBe("tt0944947");
            show!.IDs!.TMDB.ShouldBe(1399U);
            show!.IDs!.HasAnyID.ShouldBe(true);
            show!.IDs!.BestID.ShouldBe("game-of-thrones");

            show!.ToString().ShouldBe("Game of Thrones (2011)");

            show!.Tagline.ShouldBe("Winter is coming.");
            show!.Overview.ShouldBe("Seven noble families fight for control of the mythical land of Westeros.");
            show!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            show!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:26:48.000Z"));

            show!.Airs.ShouldNotBeNull();
            show!.Airs!.Day.ShouldBe(TraktDayOfWeek.Sunday);
#if NET7_0_OR_GREATER
            show!.Airs!.Time.ShouldBe(TestUtility.ParseTime("21:00"));
#else
            show!.Airs!.Time.ShouldBe("21:00");
#endif
            show!.Airs!.Timezone.ShouldBe("America/New_York");

            show!.Runtime.ShouldBe(57U);
            show!.Certification.ShouldBe("TV-MA");
            show!.Network.ShouldBe("HBO");
            show!.Country.ShouldBe("us");
            show!.Trailer.ShouldBe("https://youtube.com/watch?v=KPLWWIOCOOQ");
            show!.Homepage.ShouldBe("http://www.hbo.com/game-of-thrones");
            show!.Rating.ShouldBe(8.933884809616755f);
            show!.Votes.ShouldBe(129108U);
            show!.CommentCount.ShouldBe(414U);
            show!.Language.ShouldBe("en");
            show!.Languages.ShouldNotBeNull();
            show!.Languages!.Count.ShouldBe(1);
            show!.Languages!.ShouldBe(["en"], Case.Sensitive);

            show!.AvailableTranslations.ShouldNotBeNull();
            show!.AvailableTranslations!.Count.ShouldBe(48);
            show!.AvailableTranslations!.ShouldBe([
                "ar", "be", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "eo", "es", "et", "fa", "fi",
                "fr", "he", "hr", "hu", "id", "is", "it", "ja", "ka", "ko", "lb", "lt", "lv", "ml", "nl",
                "no", "pl", "pt", "ro", "ru", "sk", "sl", "so", "sr", "sv", "ta", "th", "tr", "tw", "uk",
                "uz", "vi", "zh"
            ], Case.Sensitive);

            show!.Genres.ShouldNotBeNull();
            show!.Genres!.Count.ShouldBe(4);
            show!.Genres!.ShouldBe([
                "fantasy", "drama", "action", "adventure"
            ], Case.Sensitive);

            show!.AiredEpisodes.ShouldBe(73U);
            show!.Status.ShouldBe(TraktShowStatus.Ended);

            show!.Images.ShouldNotBeNull();

            show!.Images!.Fanart.ShouldNotBeNull();
            show!.Images!.Fanart!.Count.ShouldBe(1);
            show!.Images!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/fanarts/medium/76d5df8aed.jpg.webp" ]);

            show!.Images!.Poster.ShouldNotBeNull();
            show!.Images!.Poster!.Count.ShouldBe(1);
            show!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/posters/thumb/93df9cd612.jpg.webp" ]);

            show!.Images!.Logo.ShouldNotBeNull();
            show!.Images!.Logo!.Count.ShouldBe(1);
            show!.Images!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/logos/medium/13b614ad43.png.webp" ]);

            show!.Images!.Clearart.ShouldNotBeNull();
            show!.Images!.Clearart!.Count.ShouldBe(1);
            show!.Images!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/cleararts/medium/5cbde9e647.png.webp" ]);

            show!.Images!.Banner.ShouldNotBeNull();
            show!.Images!.Banner!.Count.ShouldBe(1);
            show!.Images!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/banners/medium/9fefff703d.jpg.webp" ]);

            show!.Images!.Thumb.ShouldNotBeNull();
            show!.Images!.Thumb!.Count.ShouldBe(1);
            show!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/shows/000/001/390/thumbs/medium/7beccbd5a1.jpg.webp" ]);
        }
    }
}

namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieTests
    {
        [Fact]
        public void TestTraktMovieConstructor()
        {
            var movie = new TraktMovie();

            movie.Title.ShouldBeNull();
            movie.Year.ShouldBeNull();
            movie.IDs.ShouldBeNull();
            movie.Tagline.ShouldBeNull();
            movie.Overview.ShouldBeNull();
            movie.Released.ShouldBeNull();
            movie.Runtime.ShouldBeNull();
            movie.Country.ShouldBeNull();
            movie.Trailer.ShouldBeNull();
            movie.Homepage.ShouldBeNull();
            movie.Status.ShouldBeNull();
            movie.Rating.ShouldBeNull();
            movie.Votes.ShouldBeNull();
            movie.CommentCount.ShouldBeNull();
            movie.UpdatedAt.ShouldBeNull();
            movie.Language.ShouldBeNull();
            movie.Languages.ShouldBeNull();
            movie.AvailableTranslations.ShouldBeNull();
            movie.Genres.ShouldBeNull();
            movie.Certification.ShouldBeNull();

            movie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMovieFromJsonMinimal()
        {
            TraktMovieMinimal? movie = await TestUtility.DeserializeJsonAsync<TraktMovieMinimal>("Movies\\movie_minimal.json");

            movie.ShouldNotBeNull();

            movie!.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie!.Year.ShouldBe(2023U);

            movie!.IDs!.Trakt.ShouldBe(293990U);
            movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movie!.IDs!.IMDB.ShouldBe("tt6791350");
            movie!.IDs!.TMDB.ShouldBe(447365U);
            movie!.IDs!.HasAnyID.ShouldBe(true);
            movie!.IDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");

            movie!.ToString().ShouldBe("Guardians of the Galaxy Volume 3 (2023)");
        }

        [Fact]
        public async Task TestTraktMovieFromJsonMinimalWithImages()
        {
            TraktMovieMinimal? movie = await TestUtility.DeserializeJsonAsync<TraktMovieMinimal>("Movies\\movie_minimal_images.json");

            movie.ShouldNotBeNull();

            movie!.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie!.Year.ShouldBe(2023U);

            movie!.IDs!.Trakt.ShouldBe(293990U);
            movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movie!.IDs!.IMDB.ShouldBe("tt6791350");
            movie!.IDs!.TMDB.ShouldBe(447365U);
            movie!.IDs!.HasAnyID.ShouldBe(true);
            movie!.IDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");

            movie!.Images.ShouldNotBeNull();

            movie!.Images!.Fanart.ShouldNotBeNull();
            movie!.Images!.Fanart!.Count.ShouldBe(1);
            movie!.Images!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/fanarts/medium/2ea7854adf.jpg.webp" ]);

            movie!.Images!.Poster.ShouldNotBeNull();
            movie!.Images!.Poster!.Count.ShouldBe(1);
            movie!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/posters/thumb/61ceb0624b.jpg.webp" ]);

            movie!.Images!.Logo.ShouldNotBeNull();
            movie!.Images!.Logo!.Count.ShouldBe(1);
            movie!.Images!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/logos/medium/9021d3352d.png.webp" ]);

            movie!.Images!.Clearart.ShouldNotBeNull();
            movie!.Images!.Clearart!.Count.ShouldBe(1);
            movie!.Images!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/cleararts/medium/719bb7c638.png.webp" ]);

            movie!.Images!.Banner.ShouldNotBeNull();
            movie!.Images!.Banner!.Count.ShouldBe(1);
            movie!.Images!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/banners/medium/aadecf57bf.jpg.webp" ]);

            movie!.Images!.Thumb.ShouldNotBeNull();
            movie!.Images!.Thumb!.Count.ShouldBe(1);
            movie!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/thumbs/medium/6d944d9545.jpg.webp" ]);

            movie!.ToString().ShouldBe("Guardians of the Galaxy Volume 3 (2023)");
        }

        [Fact]
        public async Task TestTraktMovieFromJsonFull()
        {
            TraktMovie? movie = await TestUtility.DeserializeJsonAsync<TraktMovie>("Movies\\movie_full.json");

            movie.ShouldNotBeNull();

            movie!.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie!.Year.ShouldBe(2023U);

            movie!.IDs!.Trakt.ShouldBe(293990U);
            movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movie!.IDs!.IMDB.ShouldBe("tt6791350");
            movie!.IDs!.TMDB.ShouldBe(447365U);
            movie!.IDs!.HasAnyID.ShouldBe(true);
            movie!.IDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");

            movie!.ToString().ShouldBe("Guardians of the Galaxy Volume 3 (2023)");

            movie!.Tagline.ShouldBe("Once more with feeling.");

            movie!.Overview.ShouldBe("Peter Quill, still reeling from the loss of Gamora, must rally his team around him to defend the "
                + "universe along with protecting one of their own. A mission that, if not completed successfully, could quite possibly "
                + "lead to the end of the Guardians as we know them.");

#if NET7_0_OR_GREATER
            movie!.Released.ShouldBe(TestUtility.ParseDate("2023-05-05"));
#else
            movie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2023-05-05T00:00:00.000Z"));
#endif
            movie!.Runtime.ShouldBe(150U);
            movie!.Country.ShouldBe("us");
            movie!.Trailer.ShouldBe("https://youtube.com/watch?v=AAE5VZktooM");
            movie!.Homepage.ShouldBe("http://www.marvel.com/movies/guardians-of-the-galaxy-volume-3");
            movie!.Status.ShouldBe(TraktMovieStatus.Released);
            movie!.Rating.ShouldBe(7.976602658788774f);
            movie!.Votes.ShouldBe(16925U);
            movie!.CommentCount.ShouldBe(170U);
            movie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T08:06:45.000Z"));
            movie!.Language.ShouldBe("en");
            movie!.Languages.ShouldNotBeNull();
            movie!.Languages!.Count.ShouldBe(1);
            movie!.Languages!.ShouldBe(["en"], Case.Sensitive);

            movie!.AvailableTranslations.ShouldNotBeNull();
            movie!.AvailableTranslations!.Count.ShouldBe(39);
            movie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "eo", "es", "fa", "fi", "fr", "he", "hr",
                "hu", "id", "it", "ja", "ka", "ko", "lt", "lv", "my", "nl", "no", "pl", "pt", "ro", "ru",
                "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            movie!.Genres.ShouldNotBeNull();
            movie!.Genres!.Count.ShouldBe(4);
            movie!.Genres!.ShouldBe([
                "science-fiction", "superhero", "action", "adventure"
            ], Case.Sensitive);

            movie!.Certification.ShouldBe("PG-13");
        }

        [Fact]
        public async Task TestTraktMovieFromJsonFullWithImages()
        {
            TraktMovie? movie = await TestUtility.DeserializeJsonAsync<TraktMovie>("Movies\\movie_full_images.json");

            movie.ShouldNotBeNull();

            movie!.Title.ShouldBe("Guardians of the Galaxy Volume 3");
            movie!.Year.ShouldBe(2023U);

            movie!.IDs!.Trakt.ShouldBe(293990U);
            movie!.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movie!.IDs!.IMDB.ShouldBe("tt6791350");
            movie!.IDs!.TMDB.ShouldBe(447365U);
            movie!.IDs!.HasAnyID.ShouldBe(true);
            movie!.IDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");

            movie!.ToString().ShouldBe("Guardians of the Galaxy Volume 3 (2023)");

            movie!.Tagline.ShouldBe("Once more with feeling.");

            movie!.Overview.ShouldBe("Peter Quill, still reeling from the loss of Gamora, must rally his team around him to defend the "
                + "universe along with protecting one of their own. A mission that, if not completed successfully, could quite possibly "
                + "lead to the end of the Guardians as we know them.");

#if NET7_0_OR_GREATER
            movie!.Released.ShouldBe(TestUtility.ParseDate("2023-05-05"));
#else
            movie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2023-05-05T00:00:00.000Z"));
#endif
            movie!.Runtime.ShouldBe(150U);
            movie!.Country.ShouldBe("us");
            movie!.Trailer.ShouldBe("https://youtube.com/watch?v=AAE5VZktooM");
            movie!.Homepage.ShouldBe("http://www.marvel.com/movies/guardians-of-the-galaxy-volume-3");
            movie!.Status.ShouldBe(TraktMovieStatus.Released);
            movie!.Rating.ShouldBe(7.976602658788774f);
            movie!.Votes.ShouldBe(16925U);
            movie!.CommentCount.ShouldBe(170U);
            movie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T08:06:45.000Z"));
            movie!.Language.ShouldBe("en");
            movie!.Languages.ShouldNotBeNull();
            movie!.Languages!.Count.ShouldBe(1);
            movie!.Languages!.ShouldBe(["en"], Case.Sensitive);

            movie!.AvailableTranslations.ShouldNotBeNull();
            movie!.AvailableTranslations!.Count.ShouldBe(39);
            movie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "eo", "es", "fa", "fi", "fr", "he", "hr",
                "hu", "id", "it", "ja", "ka", "ko", "lt", "lv", "my", "nl", "no", "pl", "pt", "ro", "ru",
                "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            movie!.Genres.ShouldNotBeNull();
            movie!.Genres!.Count.ShouldBe(4);
            movie!.Genres!.ShouldBe([
                "science-fiction", "superhero", "action", "adventure"
            ], Case.Sensitive);

            movie!.Certification.ShouldBe("PG-13");

            movie!.Images.ShouldNotBeNull();

            movie!.Images!.Fanart.ShouldNotBeNull();
            movie!.Images!.Fanart!.Count.ShouldBe(1);
            movie!.Images!.Fanart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/fanarts/medium/2ea7854adf.jpg.webp" ]);

            movie!.Images!.Poster.ShouldNotBeNull();
            movie!.Images!.Poster!.Count.ShouldBe(1);
            movie!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/posters/thumb/61ceb0624b.jpg.webp" ]);

            movie!.Images!.Logo.ShouldNotBeNull();
            movie!.Images!.Logo!.Count.ShouldBe(1);
            movie!.Images!.Logo!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/logos/medium/9021d3352d.png.webp" ]);

            movie!.Images!.Clearart.ShouldNotBeNull();
            movie!.Images!.Clearart!.Count.ShouldBe(1);
            movie!.Images!.Clearart!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/cleararts/medium/719bb7c638.png.webp" ]);

            movie!.Images!.Banner.ShouldNotBeNull();
            movie!.Images!.Banner!.Count.ShouldBe(1);
            movie!.Images!.Banner!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/banners/medium/aadecf57bf.jpg.webp" ]);

            movie!.Images!.Thumb.ShouldNotBeNull();
            movie!.Images!.Thumb!.Count.ShouldBe(1);
            movie!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/movies/000/293/990/thumbs/medium/6d944d9545.jpg.webp" ]);
        }
    }
}

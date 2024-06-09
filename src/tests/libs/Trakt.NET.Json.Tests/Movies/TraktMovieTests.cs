namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieTests
    {
        [Fact]
        public void TestTraktMovieConstructor()
        {
            var movie = new TraktMovie();

            movie.Title.Should().BeNull();
            movie.Year.Should().BeNull();
            movie.Ids.Should().BeNull();
            movie.Tagline.Should().BeNull();
            movie.Overview.Should().BeNull();
            movie.Released.Should().BeNull();
            movie.Runtime.Should().BeNull();
            movie.Country.Should().BeNull();
            movie.Trailer.Should().BeNull();
            movie.Homepage.Should().BeNull();
            movie.Status.Should().BeNull();
            movie.Rating.Should().BeNull();
            movie.Votes.Should().BeNull();
            movie.CommentCount.Should().BeNull();
            movie.UpdatedAt.Should().BeNull();
            movie.Language.Should().BeNull();
            movie.Languages.Should().BeNull();
            movie.AvailableTranslations.Should().BeNull();
            movie.Genres.Should().BeNull();
            movie.Certification.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktMovieFromJsonMinimal()
        {
            TraktMovieMinimal? movie = await TestUtility.DeserializeJsonAsync<TraktMovieMinimal>("Movies\\movie_minimal.json");

            movie.Should().NotBeNull();

            movie!.Title.Should().Be("Guardians of the Galaxy Volume 3");
            movie!.Year.Should().Be(2023U);

            movie!.Ids!.Trakt.Should().Be(293990U);
            movie!.Ids!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
            movie!.Ids!.IMDB.Should().Be("tt6791350");
            movie!.Ids!.TMDB.Should().Be(447365U);
            movie!.Ids!.HasAnyID.Should().BeTrue();
            movie!.Ids!.BestID.Should().Be("293990");
        }

        [Fact]
        public async Task TestTraktMovieFromJson()
        {
            TraktMovie? movie = await TestUtility.DeserializeJsonAsync<TraktMovie>("Movies\\movie.json");

            movie.Should().NotBeNull();

            movie!.Title.Should().Be("Guardians of the Galaxy Volume 3");
            movie!.Year.Should().Be(2023U);

            movie!.Ids!.Trakt.Should().Be(293990U);
            movie!.Ids!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
            movie!.Ids!.IMDB.Should().Be("tt6791350");
            movie!.Ids!.TMDB.Should().Be(447365U);
            movie!.Ids!.HasAnyID.Should().BeTrue();
            movie!.Ids!.BestID.Should().Be("293990");

            movie!.Tagline.Should().Be("Once more with feeling.");

            movie!.Overview.Should().Be("Peter Quill, still reeling from the loss of Gamora, must rally his team around him to defend the "
                + "universe along with protecting one of their own. A mission that, if not completed successfully, could quite possibly "
                + "lead to the end of the Guardians as we know them.");

            movie!.Released.Should().Be(TestUtility.ParseDate("2023-05-05"));
            movie!.Runtime.Should().Be(150U);
            movie!.Country.Should().Be("us");
            movie!.Trailer.Should().Be("https://youtube.com/watch?v=AAE5VZktooM");
            movie!.Homepage.Should().Be("http://www.marvel.com/movies/guardians-of-the-galaxy-volume-3");
            movie!.Status.Should().Be(TraktMovieStatus.Released);
            movie!.Rating.Should().Be(7.976602658788774f);
            movie!.Votes.Should().Be(16925U);
            movie!.CommentCount.Should().Be(170U);
            movie!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-23T08:06:45.000Z"));
            movie!.Language.Should().Be("en");
            movie!.Languages.Should().NotBeNull().And.HaveCount(1).And.BeEquivalentTo(["en"]);

            movie!.AvailableTranslations.Should().NotBeNull().And.HaveCount(39).And.BeEquivalentTo([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "eo", "es", "fa", "fi", "fr", "he", "hr",
                "hu", "id", "it", "ja", "ka", "ko", "lt", "lv", "my", "nl", "no", "pl", "pt", "ro", "ru",
                "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ]);

            movie!.Genres.Should().NotBeNull().And.HaveCount(4).And.BeEquivalentTo([
                "science-fiction", "superhero", "action", "adventure"
            ]);

            movie!.Certification.Should().Be("PG-13");
        }
    }
}

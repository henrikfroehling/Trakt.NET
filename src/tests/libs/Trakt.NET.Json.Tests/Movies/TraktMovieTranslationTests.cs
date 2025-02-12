namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieTranslationTests
    {
        [Fact]
        public void TestTraktMovieTranslationConstructor()
        {
            var movieTranslation = new TraktMovieTranslation();

            movieTranslation.Title.ShouldBeNull();
            movieTranslation.Overview.ShouldBeNull();
            movieTranslation.Tagline.ShouldBeNull();
            movieTranslation.Language.ShouldBeNull();
            movieTranslation.Country.ShouldBeNull();

            movieTranslation.ToString().ShouldBe("no title set");
        }

        [Fact]
        public async Task TestTraktMovieTranslationFromJson()
        {
            TraktMovieTranslation? movieTranslation = await TraktTestUtility.DeserializeJsonAsync<TraktMovieTranslation>("Movies\\movietranslation.json");

            movieTranslation.ShouldNotBeNull();

            movieTranslation!.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieTranslation!.Overview.ShouldBe("Star-Lord, encara recuperant-se de la pèrdua de Gamora, ha de reunir...");
            movieTranslation!.Tagline.ShouldBe("Ho donaran tot.");
            movieTranslation!.Language.ShouldBe("ca");
            movieTranslation!.Country.ShouldBe("es");

            movieTranslation!.ToString().ShouldBe("ca-ES=Guardians of the Galaxy Vol. 3");
        }

        [Fact]
        public async Task TestTraktMovieTranslationsFromJson()
        {
            IReadOnlyList<TraktMovieTranslation>? movieTranslations = await TraktTestUtility.DeserializeJsonListAsync<TraktMovieTranslation>("Movies\\movietranslations.json");

            movieTranslations.ShouldNotBeNull();
            movieTranslations!.Count.ShouldBe(2);

            TraktMovieTranslation movieTranslation = movieTranslations![0];

            movieTranslation.ShouldNotBeNull();

            movieTranslation.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieTranslation.Overview.ShouldBe("Star-Lord, encara recuperant-se de la pèrdua de Gamora, ha de reunir...");
            movieTranslation.Tagline.ShouldBe("Ho donaran tot.");
            movieTranslation.Language.ShouldBe("ca");
            movieTranslation.Country.ShouldBe("es");

            movieTranslation.ToString().ShouldBe("ca-ES=Guardians of the Galaxy Vol. 3");

            // --------------------------------------------------------------------------------------------

            movieTranslation = movieTranslations![1];

            movieTranslation.ShouldNotBeNull();

            movieTranslation.Title.ShouldBe("Strážci Galaxie: Volume 3");
            movieTranslation.Overview.ShouldBe("Oblíbená parta vesmírných ztroskotanců se zabydluje na Kdovíkde.");
            movieTranslation.Tagline.ShouldBe("Ještě jednou a s citem");
            movieTranslation.Language.ShouldBe("cs");
            movieTranslation.Country.ShouldBe("cz");

            movieTranslation.ToString().ShouldBe("cs-CZ=Strážci Galaxie: Volume 3");
        }
    }
}

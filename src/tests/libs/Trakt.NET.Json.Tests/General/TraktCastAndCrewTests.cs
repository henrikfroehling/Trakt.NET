namespace TraktNET.Json.General
{
    public sealed class TraktCastAndCrewTests
    {
        [Fact]
        public void TestTraktCastAndCrewConstructor()
        {
            var castAndCrew = new TraktCastAndCrew();

            castAndCrew.Cast.ShouldBeNull();
            castAndCrew.Crew.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCastAndCrewFromJson()
        {
            TraktCastAndCrew? castAndCrew = await TraktTestUtility.DeserializeJsonAsync<TraktCastAndCrew>("General\\castandcrew.json");

            castAndCrew.ShouldNotBeNull();

            castAndCrew!.Cast.ShouldNotBeNull();
            castAndCrew!.Cast!.Count.ShouldBe(2);
            castAndCrew!.Cast![0].ShouldNotBeNull();
            castAndCrew!.Cast![1].ShouldNotBeNull();

            castAndCrew!.Cast[0].Characters.ShouldNotBeNull();
            castAndCrew!.Cast[0].Characters!.Count.ShouldBe(2);
            castAndCrew!.Cast[0].Characters!.ShouldBe(["Peter Quill", "Star-Lord"], Case.Sensitive);
            castAndCrew!.Cast[0].Person.ShouldNotBeNull();
            castAndCrew!.Cast[0].Person!.Name.ShouldBe("Chris Pratt");
            castAndCrew!.Cast[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Cast[0].Person!.IDs!.Trakt.ShouldBe(422885U);
            castAndCrew!.Cast[0].Person!.IDs!.Slug.ShouldBe("chris-pratt");
            castAndCrew!.Cast[0].Person!.IDs!.IMDB.ShouldBe("nm0695435");
            castAndCrew!.Cast[0].Person!.IDs!.TMDB.ShouldBe(73457U);

            castAndCrew!.Cast[1].Characters.ShouldNotBeNull();
            castAndCrew!.Cast[1].Characters!.Count.ShouldBe(1);
            castAndCrew!.Cast[1].Characters!.ShouldBe(["Gamora"], Case.Sensitive);
            castAndCrew!.Cast[1].Person.ShouldNotBeNull();
            castAndCrew!.Cast[1].Person!.Name.ShouldBe("Zoe Saldaña");
            castAndCrew!.Cast[1].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Cast[1].Person!.IDs!.Trakt.ShouldBe(475U);
            castAndCrew!.Cast[1].Person!.IDs!.Slug.ShouldBe("zoe-saldana");
            castAndCrew!.Cast[1].Person!.IDs!.IMDB.ShouldBe("nm0757855");
            castAndCrew!.Cast[1].Person!.IDs!.TMDB.ShouldBe(8691U);

            castAndCrew!.Crew.ShouldNotBeNull();

            castAndCrew!.Crew.Sound.ShouldNotBeNull();
            castAndCrew!.Crew.Sound!.Count.ShouldBe(1);
            castAndCrew!.Crew.Sound![0].ShouldNotBeNull();
            castAndCrew!.Crew.Sound[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Sound[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Sound[0].Jobs!.ShouldBe(["Original Music Composer"], Case.Sensitive);
            castAndCrew!.Crew.Sound[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Sound[0].Person!.Name.ShouldBe("John Murphy");
            castAndCrew!.Crew.Sound[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Sound[0].Person!.IDs!.Trakt.ShouldBe(1005U);
            castAndCrew!.Crew.Sound[0].Person!.IDs!.Slug.ShouldBe("john-murphy");
            castAndCrew!.Crew.Sound[0].Person!.IDs!.IMDB.ShouldBe("nm0614373");
            castAndCrew!.Crew.Sound[0].Person!.IDs!.TMDB.ShouldBe(960U);

            castAndCrew!.Crew.Production.ShouldNotBeNull();
            castAndCrew!.Crew.Production!.Count.ShouldBe(1);
            castAndCrew!.Crew.Production![0].ShouldNotBeNull();
            castAndCrew!.Crew.Production[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Production[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Production[0].Jobs!.ShouldBe(["Casting"], Case.Sensitive);
            castAndCrew!.Crew.Production[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Production[0].Person!.Name.ShouldBe("Sarah Halley Finn");
            castAndCrew!.Crew.Production[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Production[0].Person!.IDs!.Trakt.ShouldBe(3223U);
            castAndCrew!.Crew.Production[0].Person!.IDs!.Slug.ShouldBe("sarah-halley-finn");
            castAndCrew!.Crew.Production[0].Person!.IDs!.IMDB.ShouldBe("nm0278168");
            castAndCrew!.Crew.Production[0].Person!.IDs!.TMDB.ShouldBe(7232U);

            castAndCrew!.Crew.Editing.ShouldNotBeNull();
            castAndCrew!.Crew.Editing!.Count.ShouldBe(1);
            castAndCrew!.Crew.Editing![0].ShouldNotBeNull();
            castAndCrew!.Crew.Editing[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Editing[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Editing[0].Jobs!.ShouldBe(["Editor"], Case.Sensitive);
            castAndCrew!.Crew.Editing[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Editing[0].Person!.Name.ShouldBe("Tatiana S. Riegel");
            castAndCrew!.Crew.Editing[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Editing[0].Person!.IDs!.Trakt.ShouldBe(3527U);
            castAndCrew!.Crew.Editing[0].Person!.IDs!.Slug.ShouldBe("tatiana-s-riegel");
            castAndCrew!.Crew.Editing[0].Person!.IDs!.IMDB.ShouldBe("nm0726186");
            castAndCrew!.Crew.Editing[0].Person!.IDs!.TMDB.ShouldBe(33685U);

            castAndCrew!.Crew.Art.ShouldNotBeNull();
            castAndCrew!.Crew.Art!.Count.ShouldBe(1);
            castAndCrew!.Crew.Art![0].ShouldNotBeNull();
            castAndCrew!.Crew.Art[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Art[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Art[0].Jobs!.ShouldBe(["Set Decoration"], Case.Sensitive);
            castAndCrew!.Crew.Art[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Art[0].Person!.Name.ShouldBe("Rosemary Brandenburg");
            castAndCrew!.Crew.Art[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Art[0].Person!.IDs!.Trakt.ShouldBe(6020U);
            castAndCrew!.Crew.Art[0].Person!.IDs!.Slug.ShouldBe("rosemary-brandenburg");
            castAndCrew!.Crew.Art[0].Person!.IDs!.IMDB.ShouldBe("nm0104599");
            castAndCrew!.Crew.Art[0].Person!.IDs!.TMDB.ShouldBe(13588U);

            castAndCrew!.Crew.CostumeAndMakeUp.ShouldNotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp!.Count.ShouldBe(1);
            castAndCrew!.Crew.CostumeAndMakeUp![0].ShouldNotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.CostumeAndMakeUp[0].Jobs!.ShouldBe(["Costume Design"], Case.Sensitive);
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.Name.ShouldBe("Judianna Makovsky");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.IDs!.Trakt.ShouldBe(8106U);
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.IDs!.Slug.ShouldBe("judianna-makovsky");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.IDs!.IMDB.ShouldBe("nm0538721");
            castAndCrew!.Crew.CostumeAndMakeUp[0].Person!.IDs!.TMDB.ShouldBe(10970U);

            castAndCrew!.Crew.Crew.ShouldNotBeNull();
            castAndCrew!.Crew.Crew!.Count.ShouldBe(1);
            castAndCrew!.Crew.Crew![0].ShouldNotBeNull();
            castAndCrew!.Crew.Crew[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Crew[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Crew[0].Jobs!.ShouldBe(["Thanks"], Case.Sensitive);
            castAndCrew!.Crew.Crew[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Crew[0].Person!.Name.ShouldBe("Mike Mignola");
            castAndCrew!.Crew.Crew[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Crew[0].Person!.IDs!.Trakt.ShouldBe(8710U);
            castAndCrew!.Crew.Crew[0].Person!.IDs!.Slug.ShouldBe("mike-mignola");
            castAndCrew!.Crew.Crew[0].Person!.IDs!.IMDB.ShouldBe("nm0586005");
            castAndCrew!.Crew.Crew[0].Person!.IDs!.TMDB.ShouldBe(66266U);

            castAndCrew!.Crew.Writing.ShouldNotBeNull();
            castAndCrew!.Crew.Writing!.Count.ShouldBe(1);
            castAndCrew!.Crew.Writing![0].ShouldNotBeNull();
            castAndCrew!.Crew.Writing[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Writing[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Writing[0].Jobs!.ShouldBe(["Characters"], Case.Sensitive);
            castAndCrew!.Crew.Writing[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Writing[0].Person!.Name.ShouldBe("Larry Lieber");
            castAndCrew!.Crew.Writing[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Writing[0].Person!.IDs!.Trakt.ShouldBe(15622U);
            castAndCrew!.Crew.Writing[0].Person!.IDs!.Slug.ShouldBe("larry-lieber");
            castAndCrew!.Crew.Writing[0].Person!.IDs!.IMDB.ShouldBe("nm1293367");
            castAndCrew!.Crew.Writing[0].Person!.IDs!.TMDB.ShouldBe(18876U);

            castAndCrew!.Crew.Camera.ShouldNotBeNull();
            castAndCrew!.Crew.Camera!.Count.ShouldBe(1);
            castAndCrew!.Crew.Camera![0].ShouldNotBeNull();
            castAndCrew!.Crew.Camera[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Camera[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Camera[0].Jobs!.ShouldBe(["Director of Photography"], Case.Sensitive);
            castAndCrew!.Crew.Camera[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Camera[0].Person!.Name.ShouldBe("Henry Braham");
            castAndCrew!.Crew.Camera[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Camera[0].Person!.IDs!.Trakt.ShouldBe(19744U);
            castAndCrew!.Crew.Camera[0].Person!.IDs!.Slug.ShouldBe("henry-braham");
            castAndCrew!.Crew.Camera[0].Person!.IDs!.IMDB.ShouldBe("nm0103956");
            castAndCrew!.Crew.Camera[0].Person!.IDs!.TMDB.ShouldBe(23422U);

            castAndCrew!.Crew.VisualEffects.ShouldNotBeNull();
            castAndCrew!.Crew.VisualEffects!.Count.ShouldBe(1);
            castAndCrew!.Crew.VisualEffects![0].ShouldNotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.VisualEffects[0].Jobs!.ShouldBe(["Visual Effects Supervisor"], Case.Sensitive);
            castAndCrew!.Crew.VisualEffects[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Person!.Name.ShouldBe("Theo Bialek");
            castAndCrew!.Crew.VisualEffects[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.VisualEffects[0].Person!.IDs!.Trakt.ShouldBe(22793U);
            castAndCrew!.Crew.VisualEffects[0].Person!.IDs!.Slug.ShouldBe("theo-bialek");
            castAndCrew!.Crew.VisualEffects[0].Person!.IDs!.IMDB.ShouldBe("nm1322273");
            castAndCrew!.Crew.VisualEffects[0].Person!.IDs!.TMDB.ShouldBe(42275U);

            castAndCrew!.Crew.Directing.ShouldNotBeNull();
            castAndCrew!.Crew.Directing!.Count.ShouldBe(1);
            castAndCrew!.Crew.Directing![0].ShouldNotBeNull();
            castAndCrew!.Crew.Directing[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Directing[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Directing[0].Jobs!.ShouldBe(["Script Supervisor"], Case.Sensitive);
            castAndCrew!.Crew.Directing[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Directing[0].Person!.Name.ShouldBe("Kera Dacy");
            castAndCrew!.Crew.Directing[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Directing[0].Person!.IDs!.Trakt.ShouldBe(155049U);
            castAndCrew!.Crew.Directing[0].Person!.IDs!.Slug.ShouldBe("kera-dacy");
            castAndCrew!.Crew.Directing[0].Person!.IDs!.IMDB.ShouldBeNull();
            castAndCrew!.Crew.Directing[0].Person!.IDs!.TMDB.ShouldBe(230505U);

            castAndCrew!.Crew.Lighting.ShouldNotBeNull();
            castAndCrew!.Crew.Lighting!.Count.ShouldBe(1);
            castAndCrew!.Crew.Lighting![0].ShouldNotBeNull();
            castAndCrew!.Crew.Lighting[0].Jobs.ShouldNotBeNull();
            castAndCrew!.Crew.Lighting[0].Jobs!.Count.ShouldBe(1);
            castAndCrew!.Crew.Lighting[0].Jobs!.ShouldBe(["Chief Lighting Technician"], Case.Sensitive);
            castAndCrew!.Crew.Lighting[0].Person.ShouldNotBeNull();
            castAndCrew!.Crew.Lighting[0].Person!.Name.ShouldBe("Dan Cornwall");
            castAndCrew!.Crew.Lighting[0].Person!.IDs.ShouldNotBeNull();
            castAndCrew!.Crew.Lighting[0].Person!.IDs!.Trakt.ShouldBe(486318U);
            castAndCrew!.Crew.Lighting[0].Person!.IDs!.Slug.ShouldBe("dan-cornwall");
            castAndCrew!.Crew.Lighting[0].Person!.IDs!.IMDB.ShouldBe("nm0180473");
            castAndCrew!.Crew.Lighting[0].Person!.IDs!.TMDB.ShouldBe(1403412U);
        }
    }
}

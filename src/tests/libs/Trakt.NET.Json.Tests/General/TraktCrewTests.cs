namespace TraktNET.Json.General
{
    public sealed class TraktCrewTests
    {
        [Fact]
        public void TestTraktCrewConstructor()
        {
            var crew = new TraktCrew();

            crew.Sound.ShouldBeNull();
            crew.Production.ShouldBeNull();
            crew.Editing.ShouldBeNull();
            crew.Art.ShouldBeNull();
            crew.CostumeAndMakeUp.ShouldBeNull();
            crew.Crew.ShouldBeNull();
            crew.Writing.ShouldBeNull();
            crew.Camera.ShouldBeNull();
            crew.VisualEffects.ShouldBeNull();
            crew.Directing.ShouldBeNull();
            crew.Lighting.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCrewFromJson()
        {
            TraktCrew? crew = await TraktTestUtility.DeserializeJsonAsync<TraktCrew>("General\\crew.json");

            crew.ShouldNotBeNull();

            crew!.Sound.ShouldNotBeNull();
            crew!.Sound!.Count.ShouldBe(1);
            crew!.Sound![0].ShouldNotBeNull();
            crew!.Sound[0].Jobs.ShouldNotBeNull();
            crew!.Sound[0].Jobs!.Count.ShouldBe(1);
            crew!.Sound[0].Jobs!.ShouldBe(["Original Music Composer"], Case.Sensitive);
            crew!.Sound[0].Person.ShouldNotBeNull();
            crew!.Sound[0].Person!.Name.ShouldBe("John Murphy");
            crew!.Sound[0].Person!.IDs.ShouldNotBeNull();
            crew!.Sound[0].Person!.IDs!.Trakt.ShouldBe(1005U);
            crew!.Sound[0].Person!.IDs!.Slug.ShouldBe("john-murphy");
            crew!.Sound[0].Person!.IDs!.IMDB.ShouldBe("nm0614373");
            crew!.Sound[0].Person!.IDs!.TMDB.ShouldBe(960U);

            crew!.Production.ShouldNotBeNull();
            crew!.Production!.Count.ShouldBe(1);
            crew!.Production![0].ShouldNotBeNull();
            crew!.Production[0].Jobs.ShouldNotBeNull();
            crew!.Production[0].Jobs!.Count.ShouldBe(1);
            crew!.Production[0].Jobs!.ShouldBe(["Casting"], Case.Sensitive);
            crew!.Production[0].Person.ShouldNotBeNull();
            crew!.Production[0].Person!.Name.ShouldBe("Sarah Halley Finn");
            crew!.Production[0].Person!.IDs.ShouldNotBeNull();
            crew!.Production[0].Person!.IDs!.Trakt.ShouldBe(3223U);
            crew!.Production[0].Person!.IDs!.Slug.ShouldBe("sarah-halley-finn");
            crew!.Production[0].Person!.IDs!.IMDB.ShouldBe("nm0278168");
            crew!.Production[0].Person!.IDs!.TMDB.ShouldBe(7232U);

            crew!.Editing.ShouldNotBeNull();
            crew!.Editing!.Count.ShouldBe(1);
            crew!.Editing![0].ShouldNotBeNull();
            crew!.Editing[0].Jobs.ShouldNotBeNull();
            crew!.Editing[0].Jobs!.Count.ShouldBe(1);
            crew!.Editing[0].Jobs!.ShouldBe(["Editor"], Case.Sensitive);
            crew!.Editing[0].Person.ShouldNotBeNull();
            crew!.Editing[0].Person!.Name.ShouldBe("Tatiana S. Riegel");
            crew!.Editing[0].Person!.IDs.ShouldNotBeNull();
            crew!.Editing[0].Person!.IDs!.Trakt.ShouldBe(3527U);
            crew!.Editing[0].Person!.IDs!.Slug.ShouldBe("tatiana-s-riegel");
            crew!.Editing[0].Person!.IDs!.IMDB.ShouldBe("nm0726186");
            crew!.Editing[0].Person!.IDs!.TMDB.ShouldBe(33685U);

            crew!.Art.ShouldNotBeNull();
            crew!.Art!.Count.ShouldBe(1);
            crew!.Art![0].ShouldNotBeNull();
            crew!.Art[0].Jobs.ShouldNotBeNull();
            crew!.Art[0].Jobs!.Count.ShouldBe(1);
            crew!.Art[0].Jobs!.ShouldBe(["Set Decoration"], Case.Sensitive);
            crew!.Art[0].Person.ShouldNotBeNull();
            crew!.Art[0].Person!.Name.ShouldBe("Rosemary Brandenburg");
            crew!.Art[0].Person!.IDs.ShouldNotBeNull();
            crew!.Art[0].Person!.IDs!.Trakt.ShouldBe(6020U);
            crew!.Art[0].Person!.IDs!.Slug.ShouldBe("rosemary-brandenburg");
            crew!.Art[0].Person!.IDs!.IMDB.ShouldBe("nm0104599");
            crew!.Art[0].Person!.IDs!.TMDB.ShouldBe(13588U);

            crew!.CostumeAndMakeUp.ShouldNotBeNull();
            crew!.CostumeAndMakeUp!.Count.ShouldBe(1);
            crew!.CostumeAndMakeUp![0].ShouldNotBeNull();
            crew!.CostumeAndMakeUp[0].Jobs.ShouldNotBeNull();
            crew!.CostumeAndMakeUp[0].Jobs!.Count.ShouldBe(1);
            crew!.CostumeAndMakeUp[0].Jobs!.ShouldBe(["Costume Design"], Case.Sensitive);
            crew!.CostumeAndMakeUp[0].Person.ShouldNotBeNull();
            crew!.CostumeAndMakeUp[0].Person!.Name.ShouldBe("Judianna Makovsky");
            crew!.CostumeAndMakeUp[0].Person!.IDs.ShouldNotBeNull();
            crew!.CostumeAndMakeUp[0].Person!.IDs!.Trakt.ShouldBe(8106U);
            crew!.CostumeAndMakeUp[0].Person!.IDs!.Slug.ShouldBe("judianna-makovsky");
            crew!.CostumeAndMakeUp[0].Person!.IDs!.IMDB.ShouldBe("nm0538721");
            crew!.CostumeAndMakeUp[0].Person!.IDs!.TMDB.ShouldBe(10970U);

            crew!.Crew.ShouldNotBeNull();
            crew!.Crew!.Count.ShouldBe(1);
            crew!.Crew![0].ShouldNotBeNull();
            crew!.Crew[0].Jobs.ShouldNotBeNull();
            crew!.Crew[0].Jobs!.Count.ShouldBe(1);
            crew!.Crew[0].Jobs!.ShouldBe(["Thanks"], Case.Sensitive);
            crew!.Crew[0].Person.ShouldNotBeNull();
            crew!.Crew[0].Person!.Name.ShouldBe("Mike Mignola");
            crew!.Crew[0].Person!.IDs.ShouldNotBeNull();
            crew!.Crew[0].Person!.IDs!.Trakt.ShouldBe(8710U);
            crew!.Crew[0].Person!.IDs!.Slug.ShouldBe("mike-mignola");
            crew!.Crew[0].Person!.IDs!.IMDB.ShouldBe("nm0586005");
            crew!.Crew[0].Person!.IDs!.TMDB.ShouldBe(66266U);

            crew!.Writing.ShouldNotBeNull();
            crew!.Writing!.Count.ShouldBe(1);
            crew!.Writing![0].ShouldNotBeNull();
            crew!.Writing[0].Jobs.ShouldNotBeNull();
            crew!.Writing[0].Jobs!.Count.ShouldBe(1);
            crew!.Writing[0].Jobs!.ShouldBe(["Characters"], Case.Sensitive);
            crew!.Writing[0].Person.ShouldNotBeNull();
            crew!.Writing[0].Person!.Name.ShouldBe("Larry Lieber");
            crew!.Writing[0].Person!.IDs.ShouldNotBeNull();
            crew!.Writing[0].Person!.IDs!.Trakt.ShouldBe(15622U);
            crew!.Writing[0].Person!.IDs!.Slug.ShouldBe("larry-lieber");
            crew!.Writing[0].Person!.IDs!.IMDB.ShouldBe("nm1293367");
            crew!.Writing[0].Person!.IDs!.TMDB.ShouldBe(18876U);

            crew!.Camera.ShouldNotBeNull();
            crew!.Camera!.Count.ShouldBe(1);
            crew!.Camera![0].ShouldNotBeNull();
            crew!.Camera[0].Jobs.ShouldNotBeNull();
            crew!.Camera[0].Jobs!.Count.ShouldBe(1);
            crew!.Camera[0].Jobs!.ShouldBe(["Director of Photography"], Case.Sensitive);
            crew!.Camera[0].Person.ShouldNotBeNull();
            crew!.Camera[0].Person!.Name.ShouldBe("Henry Braham");
            crew!.Camera[0].Person!.IDs.ShouldNotBeNull();
            crew!.Camera[0].Person!.IDs!.Trakt.ShouldBe(19744U);
            crew!.Camera[0].Person!.IDs!.Slug.ShouldBe("henry-braham");
            crew!.Camera[0].Person!.IDs!.IMDB.ShouldBe("nm0103956");
            crew!.Camera[0].Person!.IDs!.TMDB.ShouldBe(23422U);

            crew!.VisualEffects.ShouldNotBeNull();
            crew!.VisualEffects!.Count.ShouldBe(1);
            crew!.VisualEffects![0].ShouldNotBeNull();
            crew!.VisualEffects[0].Jobs.ShouldNotBeNull();
            crew!.VisualEffects[0].Jobs!.Count.ShouldBe(1);
            crew!.VisualEffects[0].Jobs!.ShouldBe(["Visual Effects Supervisor"], Case.Sensitive);
            crew!.VisualEffects[0].Person.ShouldNotBeNull();
            crew!.VisualEffects[0].Person!.Name.ShouldBe("Theo Bialek");
            crew!.VisualEffects[0].Person!.IDs.ShouldNotBeNull();
            crew!.VisualEffects[0].Person!.IDs!.Trakt.ShouldBe(22793U);
            crew!.VisualEffects[0].Person!.IDs!.Slug.ShouldBe("theo-bialek");
            crew!.VisualEffects[0].Person!.IDs!.IMDB.ShouldBe("nm1322273");
            crew!.VisualEffects[0].Person!.IDs!.TMDB.ShouldBe(42275U);

            crew!.Directing.ShouldNotBeNull();
            crew!.Directing!.Count.ShouldBe(1);
            crew!.Directing![0].ShouldNotBeNull();
            crew!.Directing[0].Jobs.ShouldNotBeNull();
            crew!.Directing[0].Jobs!.Count.ShouldBe(1);
            crew!.Directing[0].Jobs!.ShouldBe(["Script Supervisor"], Case.Sensitive);
            crew!.Directing[0].Person.ShouldNotBeNull();
            crew!.Directing[0].Person!.Name.ShouldBe("Kera Dacy");
            crew!.Directing[0].Person!.IDs.ShouldNotBeNull();
            crew!.Directing[0].Person!.IDs!.Trakt.ShouldBe(155049U);
            crew!.Directing[0].Person!.IDs!.Slug.ShouldBe("kera-dacy");
            crew!.Directing[0].Person!.IDs!.IMDB.ShouldBeNull();
            crew!.Directing[0].Person!.IDs!.TMDB.ShouldBe(230505U);

            crew!.Lighting.ShouldNotBeNull();
            crew!.Lighting!.Count.ShouldBe(1);
            crew!.Lighting![0].ShouldNotBeNull();
            crew!.Lighting[0].Jobs.ShouldNotBeNull();
            crew!.Lighting[0].Jobs!.Count.ShouldBe(1);
            crew!.Lighting[0].Jobs!.ShouldBe(["Chief Lighting Technician"], Case.Sensitive);
            crew!.Lighting[0].Person.ShouldNotBeNull();
            crew!.Lighting[0].Person!.Name.ShouldBe("Dan Cornwall");
            crew!.Lighting[0].Person!.IDs.ShouldNotBeNull();
            crew!.Lighting[0].Person!.IDs!.Trakt.ShouldBe(486318U);
            crew!.Lighting[0].Person!.IDs!.Slug.ShouldBe("dan-cornwall");
            crew!.Lighting[0].Person!.IDs!.IMDB.ShouldBe("nm0180473");
            crew!.Lighting[0].Person!.IDs!.TMDB.ShouldBe(1403412U);
        }
    }
}

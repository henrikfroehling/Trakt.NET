namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CrewObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().BeNull();

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().BeNull();

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().BeNull();

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().BeNull();

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().BeNull();

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().BeNull();

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().BeNull();

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().BeNull();

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().BeNull();

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().BeNull();

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().BeNull();

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().BeNull();

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().BeNull();

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().BeNull();

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().BeNull();

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().BeNull();

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().BeNull();

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().BeNull();

                traktCrew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = traktCrew.Editing.ToArray();

                editingCrew[0].Should().NotBeNull();
                editingCrew[0].Job.Should().Be("Editor");
                editingCrew[0].Person.Should().NotBeNull();
                editingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                editingCrew[0].Person.Ids.Should().NotBeNull();
                editingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                editingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                editingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                editingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                editingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                editingCrew[1].Should().NotBeNull();
                editingCrew[1].Job.Should().Be("Editor");
                editingCrew[1].Person.Should().NotBeNull();
                editingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                editingCrew[1].Person.Ids.Should().NotBeNull();
                editingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                editingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                editingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                editingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                editingCrew[1].Person.Ids.TvRage.Should().Be(55720U);
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = traktCrew.Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                productionCrew[1].Should().NotBeNull();
                productionCrew[1].Job.Should().Be("Producer");
                productionCrew[1].Person.Should().NotBeNull();
                productionCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                productionCrew[1].Person.Ids.Should().NotBeNull();
                productionCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                productionCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                productionCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                productionCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                productionCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = traktCrew.Art.ToArray();

                artCrew[0].Should().NotBeNull();
                artCrew[0].Job.Should().Be("Artist");
                artCrew[0].Person.Should().NotBeNull();
                artCrew[0].Person.Name.Should().Be("Bryan Cranston");
                artCrew[0].Person.Ids.Should().NotBeNull();
                artCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                artCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                artCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                artCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                artCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                artCrew[1].Should().NotBeNull();
                artCrew[1].Job.Should().Be("Artist");
                artCrew[1].Person.Should().NotBeNull();
                artCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                artCrew[1].Person.Ids.Should().NotBeNull();
                artCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                artCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                artCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                artCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                artCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crew = traktCrew.Crew.ToArray();

                crew[0].Should().NotBeNull();
                crew[0].Job.Should().Be("Crew Member");
                crew[0].Person.Should().NotBeNull();
                crew[0].Person.Name.Should().Be("Bryan Cranston");
                crew[0].Person.Ids.Should().NotBeNull();
                crew[0].Person.Ids.Trakt.Should().Be(297737U);
                crew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crew[0].Person.Ids.TvRage.Should().Be(1797U);

                crew[1].Should().NotBeNull();
                crew[1].Job.Should().Be("Crew Member");
                crew[1].Person.Should().NotBeNull();
                crew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crew[1].Person.Ids.Should().NotBeNull();
                crew[1].Person.Ids.Trakt.Should().Be(9486U);
                crew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = traktCrew.CostumeAndMakeup.ToArray();

                costumeAndMakeupCrew[0].Should().NotBeNull();
                costumeAndMakeupCrew[0].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[0].Person.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Name.Should().Be("Bryan Cranston");
                costumeAndMakeupCrew[0].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                costumeAndMakeupCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                costumeAndMakeupCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                costumeAndMakeupCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                costumeAndMakeupCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                costumeAndMakeupCrew[1].Should().NotBeNull();
                costumeAndMakeupCrew[1].Job.Should().Be("Make-Up Artist");
                costumeAndMakeupCrew[1].Person.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                costumeAndMakeupCrew[1].Person.Ids.Should().NotBeNull();
                costumeAndMakeupCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                costumeAndMakeupCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                costumeAndMakeupCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                costumeAndMakeupCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                costumeAndMakeupCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = traktCrew.Directing.ToArray();

                directingCrew[0].Should().NotBeNull();
                directingCrew[0].Job.Should().Be("Director");
                directingCrew[0].Person.Should().NotBeNull();
                directingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                directingCrew[0].Person.Ids.Should().NotBeNull();
                directingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                directingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                directingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                directingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                directingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                directingCrew[1].Should().NotBeNull();
                directingCrew[1].Job.Should().Be("Director");
                directingCrew[1].Person.Should().NotBeNull();
                directingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                directingCrew[1].Person.Ids.Should().NotBeNull();
                directingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                directingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                directingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                directingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                directingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = traktCrew.Writing.ToArray();

                writingCrew[0].Should().NotBeNull();
                writingCrew[0].Job.Should().Be("Writer");
                writingCrew[0].Person.Should().NotBeNull();
                writingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                writingCrew[0].Person.Ids.Should().NotBeNull();
                writingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                writingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                writingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                writingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                writingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                writingCrew[1].Should().NotBeNull();
                writingCrew[1].Job.Should().Be("Writer");
                writingCrew[1].Person.Should().NotBeNull();
                writingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                writingCrew[1].Person.Ids.Should().NotBeNull();
                writingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                writingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                writingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                writingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                writingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = traktCrew.Sound.ToArray();

                soundCrew[0].Should().NotBeNull();
                soundCrew[0].Job.Should().Be("Sound Designer");
                soundCrew[0].Person.Should().NotBeNull();
                soundCrew[0].Person.Name.Should().Be("Bryan Cranston");
                soundCrew[0].Person.Ids.Should().NotBeNull();
                soundCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                soundCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                soundCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                soundCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                soundCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                soundCrew[1].Should().NotBeNull();
                soundCrew[1].Job.Should().Be("Sound Designer");
                soundCrew[1].Person.Should().NotBeNull();
                soundCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                soundCrew[1].Person.Ids.Should().NotBeNull();
                soundCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                soundCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                soundCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                soundCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                soundCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = traktCrew.Camera.ToArray();

                cameraCrew[0].Should().NotBeNull();
                cameraCrew[0].Job.Should().Be("Camera");
                cameraCrew[0].Person.Should().NotBeNull();
                cameraCrew[0].Person.Name.Should().Be("Bryan Cranston");
                cameraCrew[0].Person.Ids.Should().NotBeNull();
                cameraCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                cameraCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                cameraCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                cameraCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                cameraCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                cameraCrew[1].Should().NotBeNull();
                cameraCrew[1].Job.Should().Be("Camera");
                cameraCrew[1].Person.Should().NotBeNull();
                cameraCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                cameraCrew[1].Person.Ids.Should().NotBeNull();
                cameraCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                cameraCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                cameraCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                cameraCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                cameraCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = traktCrew.Lighting.ToArray();

                lightingCrew[0].Should().NotBeNull();
                lightingCrew[0].Job.Should().Be("Light Technician");
                lightingCrew[0].Person.Should().NotBeNull();
                lightingCrew[0].Person.Name.Should().Be("Bryan Cranston");
                lightingCrew[0].Person.Ids.Should().NotBeNull();
                lightingCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                lightingCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                lightingCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                lightingCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                lightingCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                lightingCrew[1].Should().NotBeNull();
                lightingCrew[1].Job.Should().Be("Light Technician");
                lightingCrew[1].Person.Should().NotBeNull();
                lightingCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                lightingCrew[1].Person.Ids.Should().NotBeNull();
                lightingCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                lightingCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                lightingCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                lightingCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                lightingCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = traktCrew.VisualEffects.ToArray();

                vfxCrew[0].Should().NotBeNull();
                vfxCrew[0].Job.Should().Be("VFX Artist");
                vfxCrew[0].Person.Should().NotBeNull();
                vfxCrew[0].Person.Name.Should().Be("Bryan Cranston");
                vfxCrew[0].Person.Ids.Should().NotBeNull();
                vfxCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                vfxCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                vfxCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                vfxCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                vfxCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                vfxCrew[1].Should().NotBeNull();
                vfxCrew[1].Job.Should().Be("VFX Artist");
                vfxCrew[1].Person.Should().NotBeNull();
                vfxCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                vfxCrew[1].Person.Ids.Should().NotBeNull();
                vfxCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                vfxCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                vfxCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                vfxCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                vfxCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);

                traktCrew.Should().NotBeNull();

                traktCrew.Production.Should().BeNull();
                traktCrew.Art.Should().BeNull();
                traktCrew.Crew.Should().BeNull();
                traktCrew.CostumeAndMakeup.Should().BeNull();
                traktCrew.Directing.Should().BeNull();
                traktCrew.Writing.Should().BeNull();
                traktCrew.Sound.Should().BeNull();
                traktCrew.Camera.Should().BeNull();
                traktCrew.Lighting.Should().BeNull();
                traktCrew.VisualEffects.Should().BeNull();
                traktCrew.Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CrewObjectJsonReader();

            var traktCrew = await jsonReader.ReadObjectAsync(default(Stream));
            traktCrew.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CrewObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCrew = await jsonReader.ReadObjectAsync(stream);
                traktCrew.Should().BeNull();
            }
        }
    }
}

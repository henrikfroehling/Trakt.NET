namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class TraktCastAndCrewObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().NotBeNull().And.HaveCount(2);
                var castMemberItems = castAndCrew.Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Character.Should().Be("Joe Brody");
                castMemberItems[0].Person.Should().NotBeNull();
                castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
                castMemberItems[0].Person.Ids.Should().NotBeNull();
                castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
                castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
                castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
                castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

                castMemberItems[1].Should().NotBeNull();
                castMemberItems[1].Character.Should().Be("Jules Winfield");
                castMemberItems[1].Person.Should().NotBeNull();
                castMemberItems[1].Person.Name.Should().Be("Samuel L.Jackson");
                castMemberItems[1].Person.Ids.Should().NotBeNull();
                castMemberItems[1].Person.Ids.Trakt.Should().Be(9486U);
                castMemberItems[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                castMemberItems[1].Person.Ids.Imdb.Should().Be("nm0000168");
                castMemberItems[1].Person.Ids.Tmdb.Should().Be(2231U);
                castMemberItems[1].Person.Ids.TvRage.Should().Be(55720U);

                castAndCrew.Crew.Should().NotBeNull();
                var crew = castAndCrew.Crew;

                crew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = crew.Production.ToArray();

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

                crew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = crew.Art.ToArray();

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

                crew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crewCrew = crew.Crew.ToArray();

                crewCrew[0].Should().NotBeNull();
                crewCrew[0].Job.Should().Be("Crew Member");
                crewCrew[0].Person.Should().NotBeNull();
                crewCrew[0].Person.Name.Should().Be("Bryan Cranston");
                crewCrew[0].Person.Ids.Should().NotBeNull();
                crewCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                crewCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crewCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crewCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crewCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crewCrew[1].Should().NotBeNull();
                crewCrew[1].Job.Should().Be("Crew Member");
                crewCrew[1].Person.Should().NotBeNull();
                crewCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crewCrew[1].Person.Ids.Should().NotBeNull();
                crewCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                crewCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crewCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crewCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crewCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = crew.CostumeAndMakeup.ToArray();

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

                crew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = crew.Directing.ToArray();

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

                crew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = crew.Writing.ToArray();

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

                crew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = crew.Sound.ToArray();

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

                crew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = crew.Camera.ToArray();

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

                crew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = crew.Lighting.ToArray();

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

                crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = crew.VisualEffects.ToArray();

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

                crew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = crew.Editing.ToArray();

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
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().BeNull();

                castAndCrew.Crew.Should().NotBeNull();
                var crew = castAndCrew.Crew;

                crew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = crew.Production.ToArray();

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

                crew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = crew.Art.ToArray();

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

                crew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crewCrew = crew.Crew.ToArray();

                crewCrew[0].Should().NotBeNull();
                crewCrew[0].Job.Should().Be("Crew Member");
                crewCrew[0].Person.Should().NotBeNull();
                crewCrew[0].Person.Name.Should().Be("Bryan Cranston");
                crewCrew[0].Person.Ids.Should().NotBeNull();
                crewCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                crewCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crewCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crewCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crewCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crewCrew[1].Should().NotBeNull();
                crewCrew[1].Job.Should().Be("Crew Member");
                crewCrew[1].Person.Should().NotBeNull();
                crewCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crewCrew[1].Person.Ids.Should().NotBeNull();
                crewCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                crewCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crewCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crewCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crewCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = crew.CostumeAndMakeup.ToArray();

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

                crew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = crew.Directing.ToArray();

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

                crew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = crew.Writing.ToArray();

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

                crew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = crew.Sound.ToArray();

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

                crew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = crew.Camera.ToArray();

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

                crew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = crew.Lighting.ToArray();

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

                crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = crew.VisualEffects.ToArray();

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

                crew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = crew.Editing.ToArray();

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
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().NotBeNull().And.HaveCount(2);
                var castMemberItems = castAndCrew.Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Character.Should().Be("Joe Brody");
                castMemberItems[0].Person.Should().NotBeNull();
                castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
                castMemberItems[0].Person.Ids.Should().NotBeNull();
                castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
                castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
                castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
                castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

                castMemberItems[1].Should().NotBeNull();
                castMemberItems[1].Character.Should().Be("Jules Winfield");
                castMemberItems[1].Person.Should().NotBeNull();
                castMemberItems[1].Person.Name.Should().Be("Samuel L.Jackson");
                castMemberItems[1].Person.Ids.Should().NotBeNull();
                castMemberItems[1].Person.Ids.Trakt.Should().Be(9486U);
                castMemberItems[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                castMemberItems[1].Person.Ids.Imdb.Should().Be("nm0000168");
                castMemberItems[1].Person.Ids.Tmdb.Should().Be(2231U);
                castMemberItems[1].Person.Ids.TvRage.Should().Be(55720U);

                castAndCrew.Crew.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().BeNull();

                castAndCrew.Crew.Should().NotBeNull();
                var crew = castAndCrew.Crew;

                crew.Production.Should().NotBeNull().And.HaveCount(2);
                var productionCrew = crew.Production.ToArray();

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

                crew.Art.Should().NotBeNull().And.HaveCount(2);
                var artCrew = crew.Art.ToArray();

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

                crew.Crew.Should().NotBeNull().And.HaveCount(2);
                var crewCrew = crew.Crew.ToArray();

                crewCrew[0].Should().NotBeNull();
                crewCrew[0].Job.Should().Be("Crew Member");
                crewCrew[0].Person.Should().NotBeNull();
                crewCrew[0].Person.Name.Should().Be("Bryan Cranston");
                crewCrew[0].Person.Ids.Should().NotBeNull();
                crewCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                crewCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                crewCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                crewCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                crewCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crewCrew[1].Should().NotBeNull();
                crewCrew[1].Job.Should().Be("Crew Member");
                crewCrew[1].Person.Should().NotBeNull();
                crewCrew[1].Person.Name.Should().Be("Samuel L.Jackson");
                crewCrew[1].Person.Ids.Should().NotBeNull();
                crewCrew[1].Person.Ids.Trakt.Should().Be(9486U);
                crewCrew[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                crewCrew[1].Person.Ids.Imdb.Should().Be("nm0000168");
                crewCrew[1].Person.Ids.Tmdb.Should().Be(2231U);
                crewCrew[1].Person.Ids.TvRage.Should().Be(55720U);

                crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
                var costumeAndMakeupCrew = crew.CostumeAndMakeup.ToArray();

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

                crew.Directing.Should().NotBeNull().And.HaveCount(2);
                var directingCrew = crew.Directing.ToArray();

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

                crew.Writing.Should().NotBeNull().And.HaveCount(2);
                var writingCrew = crew.Writing.ToArray();

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

                crew.Sound.Should().NotBeNull().And.HaveCount(2);
                var soundCrew = crew.Sound.ToArray();

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

                crew.Camera.Should().NotBeNull().And.HaveCount(2);
                var cameraCrew = crew.Camera.ToArray();

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

                crew.Lighting.Should().NotBeNull().And.HaveCount(2);
                var lightingCrew = crew.Lighting.ToArray();

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

                crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
                var vfxCrew = crew.VisualEffects.ToArray();

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

                crew.Editing.Should().NotBeNull().And.HaveCount(2);
                var editingCrew = crew.Editing.ToArray();

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
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().NotBeNull().And.HaveCount(2);
                var castMemberItems = castAndCrew.Cast.ToArray();

                castMemberItems[0].Should().NotBeNull();
                castMemberItems[0].Character.Should().Be("Joe Brody");
                castMemberItems[0].Person.Should().NotBeNull();
                castMemberItems[0].Person.Name.Should().Be("Bryan Cranston");
                castMemberItems[0].Person.Ids.Should().NotBeNull();
                castMemberItems[0].Person.Ids.Trakt.Should().Be(297737U);
                castMemberItems[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                castMemberItems[0].Person.Ids.Imdb.Should().Be("nm0186505");
                castMemberItems[0].Person.Ids.Tmdb.Should().Be(17419U);
                castMemberItems[0].Person.Ids.TvRage.Should().Be(1797U);

                castMemberItems[1].Should().NotBeNull();
                castMemberItems[1].Character.Should().Be("Jules Winfield");
                castMemberItems[1].Person.Should().NotBeNull();
                castMemberItems[1].Person.Name.Should().Be("Samuel L.Jackson");
                castMemberItems[1].Person.Ids.Should().NotBeNull();
                castMemberItems[1].Person.Ids.Trakt.Should().Be(9486U);
                castMemberItems[1].Person.Ids.Slug.Should().Be("samuel-l-jackson");
                castMemberItems[1].Person.Ids.Imdb.Should().Be("nm0000168");
                castMemberItems[1].Person.Ids.Tmdb.Should().Be(2231U);
                castMemberItems[1].Person.Ids.TvRage.Should().Be(55720U);

                castAndCrew.Crew.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);

                castAndCrew.Should().NotBeNull();
                castAndCrew.Cast.Should().BeNull();
                castAndCrew.Crew.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            var castAndCrew = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            castAndCrew.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCastAndCrewObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktCastAndCrewObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var castAndCrew = await traktJsonReader.ReadObjectAsync(jsonReader);
                castAndCrew.Should().BeNull();
            }
        }
    }
}

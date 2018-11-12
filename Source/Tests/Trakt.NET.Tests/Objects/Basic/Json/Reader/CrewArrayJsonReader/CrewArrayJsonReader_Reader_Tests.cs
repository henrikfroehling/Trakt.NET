namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CrewArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCrews.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

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

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

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

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

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

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().BeNull();

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().Be("Producer");
                productionCrew[0].Person.Should().BeNull();

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

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

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().BeNull();
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

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

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

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

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().BeNull();
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktCrews.Should().NotBeNull();
                ITraktCrew[] crews = traktCrews.ToArray();

                crews[0].Production.Should().NotBeNull().And.HaveCount(2);
                ITraktCrewMember[] productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().BeNull();
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crews[0].Art.Should().BeNull();
                crews[0].Crew.Should().BeNull();
                crews[0].CostumeAndMakeup.Should().BeNull();
                crews[0].Directing.Should().BeNull();
                crews[0].Writing.Should().BeNull();
                crews[0].Sound.Should().BeNull();
                crews[0].Camera.Should().BeNull();
                crews[0].Lighting.Should().BeNull();
                crews[0].VisualEffects.Should().BeNull();
                crews[0].Editing.Should().BeNull();

                crews[1].Production.Should().NotBeNull().And.HaveCount(2);
                productionCrew = crews[0].Production.ToArray();

                productionCrew[0].Should().NotBeNull();
                productionCrew[0].Job.Should().BeNull();
                productionCrew[0].Person.Should().NotBeNull();
                productionCrew[0].Person.Name.Should().Be("Bryan Cranston");
                productionCrew[0].Person.Ids.Should().NotBeNull();
                productionCrew[0].Person.Ids.Trakt.Should().Be(297737U);
                productionCrew[0].Person.Ids.Slug.Should().Be("bryan-cranston");
                productionCrew[0].Person.Ids.Imdb.Should().Be("nm0186505");
                productionCrew[0].Person.Ids.Tmdb.Should().Be(17419U);
                productionCrew[0].Person.Ids.TvRage.Should().Be(1797U);

                crews[1].Art.Should().BeNull();
                crews[1].Crew.Should().BeNull();
                crews[1].CostumeAndMakeup.Should().BeNull();
                crews[1].Directing.Should().BeNull();
                crews[1].Writing.Should().BeNull();
                crews[1].Sound.Should().BeNull();
                crews[1].Camera.Should().BeNull();
                crews[1].Lighting.Should().BeNull();
                crews[1].VisualEffects.Should().BeNull();
                crews[1].Editing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new CrewArrayJsonReader();
            IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktCrews.Should().BeNull();
        }

        [Fact]
        public async Task Test_CrewArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new CrewArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktCrew> traktCrews = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktCrews.Should().BeNull();
            }
        }
    }
}

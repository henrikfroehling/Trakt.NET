namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowCastAndCrewObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowCastAndCrewObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ShowCastAndCrewObjectJsonReader();

            var traktShowCastAndCrew = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowCastAndCrew.Cast.First().Characters.First().Should().Be("Daenerys Targaryen");
            traktShowCastAndCrew.Cast.First().Person.Name.Should().Be("Emilia Clarke");
            traktShowCastAndCrew.Cast.First().Person.Age.Should().Be(0);
            traktShowCastAndCrew.Cast.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.Cast.First().Person.Ids.Trakt.Should().Be(436511u);
            traktShowCastAndCrew.Cast.First().Person.Ids.Slug.Should().Be("emilia-clarke");
            traktShowCastAndCrew.Cast.First().Person.Ids.Imdb.Should().Be("nm3592338");
            traktShowCastAndCrew.Cast.First().Person.Ids.Tmdb.Should().Be(1223786u);
            traktShowCastAndCrew.Cast.First().Person.Ids.TvRage.Should().BeNull();
            traktShowCastAndCrew.GuestStars.First().Characters.First().Should().Be("Samwell Tarly");
            traktShowCastAndCrew.GuestStars.First().Person.Name.Should().Be("John Bradley");
            traktShowCastAndCrew.GuestStars.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.GuestStars.First().Person.Ids.Trakt.Should().Be(413734u);
            traktShowCastAndCrew.GuestStars.First().Person.Ids.Slug.Should().Be("john-bradley-ff703964-4593-4530-a7f6-c83a7f367e88");
            traktShowCastAndCrew.GuestStars.First().Person.Ids.Imdb.Should().Be("nm4263213");
            traktShowCastAndCrew.GuestStars.First().Person.Ids.Tmdb.Should().Be(1010135u);
            traktShowCastAndCrew.GuestStars.First().Person.Ids.TvRage.Should().BeNull();
            traktShowCastAndCrew.Crew.Editing.First().Jobs.First().Should().Be("Editor");
            traktShowCastAndCrew.Crew.Editing.First().Person.Name.Should().Be("Martin Nicholson");
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.Trakt.Should().Be(66119u);
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.Slug.Should().Be("martin-nicholson");
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.Imdb.Should().Be("nm0629882");
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.Tmdb.Should().Be(81827u);
            traktShowCastAndCrew.Crew.Editing.First().Person.Ids.TvRage.Should().BeNull();
            traktShowCastAndCrew.Crew.Directing.First().Jobs.First().Should().Be("Director");
            traktShowCastAndCrew.Crew.Directing.First().Person.Name.Should().Be("Daniel Minahan");
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.Trakt.Should().Be(77501u);
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.Slug.Should().Be("daniel-minahan");
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.Imdb.Should().Be("nm0590889");
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.Tmdb.Should().Be(88743u);
            traktShowCastAndCrew.Crew.Directing.First().Person.Ids.TvRage.Should().Be(28917u);
            traktShowCastAndCrew.Crew.Camera.First().Jobs.First().Should().Be("Director of Photography");
            traktShowCastAndCrew.Crew.Camera.First().Person.Name.Should().Be("Matthew Jensen");
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.Trakt.Should().Be(90466u);
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.Slug.Should().Be("matthew-jensen");
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.Imdb.Should().Be("nm0421608");
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.Tmdb.Should().Be(94545u);
            traktShowCastAndCrew.Crew.Camera.First().Person.Ids.TvRage.Should().BeNull();
            traktShowCastAndCrew.Crew.Writing.First().Jobs.First().Should().Be("Writer");
            traktShowCastAndCrew.Crew.Writing.First().Person.Name.Should().Be("George R. R. Martin");
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.Trakt.Should().Be(448663u);
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.Slug.Should().Be("george-r-r-martin-448663");
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.Imdb.Should().Be("nm0552333");
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.Tmdb.Should().Be(237053u);
            traktShowCastAndCrew.Crew.Writing.First().Person.Ids.TvRage.Should().Be(79951u);
        }
    }
}

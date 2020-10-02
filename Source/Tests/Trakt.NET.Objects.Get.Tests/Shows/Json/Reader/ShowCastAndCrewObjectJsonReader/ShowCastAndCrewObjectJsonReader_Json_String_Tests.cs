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

            traktShowCastAndCrew.Should().NotBeNull();
            traktShowCastAndCrew.Cast.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewCast = traktShowCastAndCrew.Cast.ToArray();

            traktShowCastAndCrewCast.Should().NotBeNull();
            traktShowCastAndCrewCast[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Daenerys Targaryen");
            traktShowCastAndCrewCast[0].Person.Name.Should().Be("Emilia Clarke");
            traktShowCastAndCrewCast[0].Person.Age.Should().Be(0);
            traktShowCastAndCrewCast[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewCast[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewCast[0].Person.Ids.Trakt.Should().Be(436511u);
            traktShowCastAndCrewCast[0].Person.Ids.Slug.Should().Be("emilia-clarke");
            traktShowCastAndCrewCast[0].Person.Ids.Imdb.Should().Be("nm3592338");
            traktShowCastAndCrewCast[0].Person.Ids.Tmdb.Should().Be(1223786u);
            traktShowCastAndCrewCast[0].Person.Ids.TvRage.Should().BeNull();

            traktShowCastAndCrew.GuestStars.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewGuestStars = traktShowCastAndCrew.GuestStars.ToArray();

            traktShowCastAndCrewGuestStars[0].Characters.Should().NotBeNull().And.HaveCount(1).And.Contain("Samwell Tarly");
            traktShowCastAndCrewGuestStars[0].Person.Name.Should().Be("John Bradley");
            traktShowCastAndCrewGuestStars[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewGuestStars[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewGuestStars[0].Person.Ids.Trakt.Should().Be(413734u);
            traktShowCastAndCrewGuestStars[0].Person.Ids.Slug.Should().Be("john-bradley-ff703964-4593-4530-a7f6-c83a7f367e88");
            traktShowCastAndCrewGuestStars[0].Person.Ids.Imdb.Should().Be("nm4263213");
            traktShowCastAndCrewGuestStars[0].Person.Ids.Tmdb.Should().Be(1010135u);
            traktShowCastAndCrewGuestStars[0].Person.Ids.TvRage.Should().BeNull();

            traktShowCastAndCrew.Crew.Should().NotBeNull();
            traktShowCastAndCrew.Crew.Editing.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewCrewEditing = traktShowCastAndCrew.Crew.Editing.ToArray();

            traktShowCastAndCrewCrewEditing[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Editor");
            traktShowCastAndCrewCrewEditing[0].Person.Should().NotBeNull();
            traktShowCastAndCrewCrewEditing[0].Person.Name.Should().Be("Martin Nicholson");
            traktShowCastAndCrewCrewEditing[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewCrewEditing[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewCrewEditing[0].Person.Ids.Trakt.Should().Be(66119u);
            traktShowCastAndCrewCrewEditing[0].Person.Ids.Slug.Should().Be("martin-nicholson");
            traktShowCastAndCrewCrewEditing[0].Person.Ids.Imdb.Should().Be("nm0629882");
            traktShowCastAndCrewCrewEditing[0].Person.Ids.Tmdb.Should().Be(81827u);
            traktShowCastAndCrewCrewEditing[0].Person.Ids.TvRage.Should().BeNull();

            traktShowCastAndCrew.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewCrewDirecting = traktShowCastAndCrew.Crew.Directing.ToArray();

            traktShowCastAndCrewCrewDirecting[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director");
            traktShowCastAndCrewCrewDirecting[0].Person.Should().NotBeNull();
            traktShowCastAndCrewCrewDirecting[0].Person.Name.Should().Be("Daniel Minahan");
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.Trakt.Should().Be(77501u);
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.Slug.Should().Be("daniel-minahan");
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.Imdb.Should().Be("nm0590889");
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.Tmdb.Should().Be(88743u);
            traktShowCastAndCrewCrewDirecting[0].Person.Ids.TvRage.Should().Be(28917u);

            traktShowCastAndCrew.Crew.Camera.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewCrewCamera = traktShowCastAndCrew.Crew.Camera.ToArray();

            traktShowCastAndCrewCrewCamera[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Director of Photography");
            traktShowCastAndCrewCrewCamera[0].Person.Should().NotBeNull();
            traktShowCastAndCrewCrewCamera[0].Person.Name.Should().Be("Matthew Jensen");
            traktShowCastAndCrewCrewCamera[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewCrewCamera[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewCrewCamera[0].Person.Ids.Trakt.Should().Be(90466u);
            traktShowCastAndCrewCrewCamera[0].Person.Ids.Slug.Should().Be("matthew-jensen");
            traktShowCastAndCrewCrewCamera[0].Person.Ids.Imdb.Should().Be("nm0421608");
            traktShowCastAndCrewCrewCamera[0].Person.Ids.Tmdb.Should().Be(94545u);
            traktShowCastAndCrewCrewCamera[0].Person.Ids.TvRage.Should().BeNull();

            traktShowCastAndCrew.Crew.Writing.Should().NotBeNull().And.HaveCount(1);
            var traktShowCastAndCrewCrewWriting = traktShowCastAndCrew.Crew.Writing.ToArray();

            traktShowCastAndCrewCrewWriting[0].Jobs.Should().NotBeNull().And.HaveCount(1).And.Contain("Writer");
            traktShowCastAndCrewCrewWriting[0].Person.Should().NotBeNull();
            traktShowCastAndCrewCrewWriting[0].Person.Name.Should().Be("George R. R. Martin");
            traktShowCastAndCrewCrewWriting[0].Person.Ids.Should().NotBeNull();
            traktShowCastAndCrewCrewWriting[0].Person.Ids.HasAnyId.Should().BeTrue();
            traktShowCastAndCrewCrewWriting[0].Person.Ids.Trakt.Should().Be(448663u);
            traktShowCastAndCrewCrewWriting[0].Person.Ids.Slug.Should().Be("george-r-r-martin-448663");
            traktShowCastAndCrewCrewWriting[0].Person.Ids.Imdb.Should().Be("nm0552333");
            traktShowCastAndCrewCrewWriting[0].Person.Ids.Tmdb.Should().Be(237053u);
            traktShowCastAndCrewCrewWriting[0].Person.Ids.TvRage.Should().Be(79951u);
        }
    }
}

namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeason>();

            var traktSeasons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktSeasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_SeasonArrayJsonReader_ReadArray_From_Json_String_Minimal_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeason>();

            var traktSeasons = await jsonReader.ReadArrayAsync(MINIMAL_JSON_COMPLETE);
            traktSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var seasons = traktSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Ids.Should().NotBeNull();
            seasons[0].Ids.Trakt.Should().Be(61430U);
            seasons[0].Ids.Tvdb.Should().Be(279121U);
            seasons[0].Ids.Tmdb.Should().Be(60523U);
            seasons[0].Ids.TvRage.Should().Be(36939U);
            seasons[0].Rating.Should().NotHaveValue();
            seasons[0].Votes.Should().NotHaveValue();
            seasons[0].TotalEpisodesCount.Should().NotHaveValue();
            seasons[0].AiredEpisodesCount.Should().NotHaveValue();
            seasons[0].Overview.Should().BeNullOrEmpty();
            seasons[0].FirstAired.Should().NotHaveValue();
            seasons[0].Network.Should().BeNull();
            seasons[0].Episodes.Should().BeNull();

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Ids.Should().NotBeNull();
            seasons[1].Ids.Trakt.Should().Be(3964U);
            seasons[1].Ids.Tvdb.Should().Be(473271U);
            seasons[1].Ids.Tmdb.Should().Be(3625U);
            seasons[1].Ids.TvRage.Should().Be(36940U);
            seasons[1].Rating.Should().NotHaveValue();
            seasons[1].Votes.Should().NotHaveValue();
            seasons[1].TotalEpisodesCount.Should().NotHaveValue();
            seasons[1].AiredEpisodesCount.Should().NotHaveValue();
            seasons[1].Overview.Should().BeNullOrEmpty();
            seasons[1].FirstAired.Should().NotHaveValue();
            seasons[1].Network.Should().BeNull();
            seasons[1].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonArrayJsonReader_ReadArray_From_Json_String_Full_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeason>();

            var traktSeasons = await jsonReader.ReadArrayAsync(FULL_JSON_COMPLETE);
            traktSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var seasons = traktSeasons.ToArray();

            seasons[0].Should().NotBeNull();
            seasons[0].Number.Should().Be(1);
            seasons[0].Ids.Should().NotBeNull();
            seasons[0].Ids.Trakt.Should().Be(61430U);
            seasons[0].Ids.Tvdb.Should().Be(279121U);
            seasons[0].Ids.Tmdb.Should().Be(60523U);
            seasons[0].Ids.TvRage.Should().Be(36939U);
            seasons[0].Rating.Should().Be(8.57053f);
            seasons[0].Votes.Should().Be(794);
            seasons[0].TotalEpisodesCount.Should().Be(10);
            seasons[0].AiredEpisodesCount.Should().Be(10);
            seasons[0].Overview.Should().Be("Trouble is brewing in the Seven Kingdoms of Westeros. For the driven inhabitants of this visionary world, control of Westeros' Iron Throne holds the lure of great power. But in a land where the seasons can last a lifetime, winter is coming...and beyond the Great Wall that protects them, an ancient evil has returned. In Season One, the story centers on three primary areas: the Stark and the Lannister families, whose designs on controlling the throne threaten a tenuous peace; the dragon princess Daenerys, heir to the former dynasty, who waits just over the Narrow Sea with her malevolent brother Viserys; and the Great Wall--a massive barrier of ice where a forgotten danger is stirring.");
            seasons[0].FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            seasons[0].Network.Should().Be("The CW");
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();

            // ------------------------------------------------------------

            seasons[1].Should().NotBeNull();
            seasons[1].Number.Should().Be(2);
            seasons[1].Ids.Should().NotBeNull();
            seasons[1].Ids.Trakt.Should().Be(3964U);
            seasons[1].Ids.Tvdb.Should().Be(473271U);
            seasons[1].Ids.Tmdb.Should().Be(3625U);
            seasons[1].Ids.TvRage.Should().Be(36940U);
            seasons[1].Rating.Should().Be(9.10629f);
            seasons[1].Votes.Should().Be(1590);
            seasons[1].TotalEpisodesCount.Should().Be(10);
            seasons[1].AiredEpisodesCount.Should().Be(10);
            seasons[1].Overview.Should().Be("The cold winds of winter are rising in Westeros...war is coming...and five kings continue their savage quest for control of the all-powerful Iron Throne. With winter fast approaching, the coveted Iron Throne is occupied by the cruel Joffrey, counseled by his conniving mother Cersei and uncle Tyrion. But the Lannister hold on the Throne is under assault on many fronts. Meanwhile, a new leader is rising among the wildings outside the Great Wall, adding new perils for Jon Snow and the order of the Night's Watch.");
            seasons[1].FirstAired.Should().Be(DateTime.Parse("2012-04-02T01:00:00.000Z").ToUniversalTime());
            seasons[1].Network.Should().Be("The CW");
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(2);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("The North Remembers");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73650U);
            episodes[0].Ids.Tvdb.Should().Be(4161693U);
            episodes[0].Ids.Imdb.Should().Be("tt1971833");
            episodes[0].Ids.Tmdb.Should().Be(63066U);
            episodes[0].Ids.TvRage.Should().Be(1065074755U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(2);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Night Lands");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(73651U);
            episodes[1].Ids.Tvdb.Should().Be(4245771U);
            episodes[1].Ids.Imdb.Should().Be("tt2069318");
            episodes[1].Ids.Tmdb.Should().Be(974430U);
            episodes[1].Ids.TvRage.Should().Be(1065150289U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeason>();

            var traktSeasons = await jsonReader.ReadArrayAsync(default(string));
            traktSeasons.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeason>();

            var traktSeasons = await jsonReader.ReadArrayAsync(string.Empty);
            traktSeasons.Should().BeNull();
        }
    }
}

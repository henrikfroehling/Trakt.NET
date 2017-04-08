namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ITraktShowCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().BeNull();

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().BeNull();
            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().BeNull();
            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().BeNull();
            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().BeNull();

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().BeNull();
            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().BeNull();

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();

            traktShowCollectionProgress.NextEpisode.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowCollectionProgress.NextEpisode.Number.Should().Be(3);
            traktShowCollectionProgress.NextEpisode.Title.Should().Be("Water");
            traktShowCollectionProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowCollectionProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowCollectionProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowCollectionProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowCollectionProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowCollectionProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().Be(2);
            traktShowCollectionProgress.Completed.Should().Be(2);
            traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowCollectionProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowCollectionProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowCollectionProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowCollectionProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktShowCollectionProgress.Should().NotBeNull();

            traktShowCollectionProgress.Aired.Should().BeNull();
            traktShowCollectionProgress.Completed.Should().BeNull();
            traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
            traktShowCollectionProgress.Seasons.Should().BeNull();
            traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
            traktShowCollectionProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(default(string));
            traktShowCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktShowCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowCollectionProgress.Should().BeNull();
        }
    }
}

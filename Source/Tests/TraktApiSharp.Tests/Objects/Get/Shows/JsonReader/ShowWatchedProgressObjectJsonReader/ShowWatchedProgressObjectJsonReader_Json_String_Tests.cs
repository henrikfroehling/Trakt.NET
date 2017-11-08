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
    public partial class ShowWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().BeNull();

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().BeNull();

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().BeNull();

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().BeNull();

            traktShowWatchedProgress.LastEpisode.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.LastEpisode.Number.Should().Be(2);
            traktShowWatchedProgress.LastEpisode.Title.Should().Be("Storm");
            traktShowWatchedProgress.LastEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
            traktShowWatchedProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
            traktShowWatchedProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
            traktShowWatchedProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
            traktShowWatchedProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().NotBeNull().And.HaveCount(2);

            var seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(8);
            seasons[0].Completed.Should().Be(2);
            seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            seasons = traktShowWatchedProgress.Seasons.ToArray();

            seasons[1].Number.Should().Be(2);
            seasons[1].Aired.Should().Be(8);
            seasons[1].Completed.Should().Be(2);
            seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodes = seasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            traktShowWatchedProgress.HiddenSeasons.Should().NotBeNull().And.HaveCount(1);

            var hiddenSeasons = traktShowWatchedProgress.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(0);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().Be(252213354U);

            traktShowWatchedProgress.NextEpisode.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.SeasonNumber.Should().Be(1);
            traktShowWatchedProgress.NextEpisode.Number.Should().Be(3);
            traktShowWatchedProgress.NextEpisode.Title.Should().Be("Water");
            traktShowWatchedProgress.NextEpisode.Ids.Should().NotBeNull();
            traktShowWatchedProgress.NextEpisode.Ids.Trakt.Should().Be(62315U);
            traktShowWatchedProgress.NextEpisode.Ids.Tvdb.Should().Be(4849873U);
            traktShowWatchedProgress.NextEpisode.Ids.Imdb.Should().Be("tt0203244");
            traktShowWatchedProgress.NextEpisode.Ids.Tmdb.Should().Be(525363U);
            traktShowWatchedProgress.NextEpisode.Ids.TvRage.Should().Be(26414562U);

            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
            traktShowWatchedProgress.LastEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(default(string));
            traktShowWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowWatchedProgress.Should().BeNull();
        }
    }
}

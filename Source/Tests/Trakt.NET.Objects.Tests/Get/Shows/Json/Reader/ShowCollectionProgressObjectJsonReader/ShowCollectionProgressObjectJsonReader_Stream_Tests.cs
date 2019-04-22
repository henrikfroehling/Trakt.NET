namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktShowCollectionProgress.Should().NotBeNull();

                traktShowCollectionProgress.Aired.Should().Be(2);
                traktShowCollectionProgress.Completed.Should().BeNull();
                traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
                traktShowCollectionProgress.Seasons.Should().BeNull();
                traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
                traktShowCollectionProgress.NextEpisode.Should().BeNull();
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktShowCollectionProgress.Should().NotBeNull();

                traktShowCollectionProgress.Aired.Should().BeNull();
                traktShowCollectionProgress.Completed.Should().Be(2);
                traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
                traktShowCollectionProgress.Seasons.Should().BeNull();
                traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
                traktShowCollectionProgress.NextEpisode.Should().BeNull();
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktShowCollectionProgress.Should().NotBeNull();

                traktShowCollectionProgress.Aired.Should().BeNull();
                traktShowCollectionProgress.Completed.Should().BeNull();
                traktShowCollectionProgress.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
                traktShowCollectionProgress.Seasons.Should().BeNull();
                traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
                traktShowCollectionProgress.NextEpisode.Should().BeNull();
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktShowCollectionProgress.Should().NotBeNull();

                traktShowCollectionProgress.Aired.Should().BeNull();
                traktShowCollectionProgress.Completed.Should().BeNull();
                traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
                traktShowCollectionProgress.Seasons.Should().BeNull();
                traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
                traktShowCollectionProgress.NextEpisode.Should().BeNull();

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.SeasonNumber.Should().Be(1);
                traktShowCollectionProgress.LastEpisode.Number.Should().Be(2);
                traktShowCollectionProgress.LastEpisode.Title.Should().Be("Storm");
                traktShowCollectionProgress.LastEpisode.Ids.Should().NotBeNull();
                traktShowCollectionProgress.LastEpisode.Ids.Trakt.Should().Be(62316U);
                traktShowCollectionProgress.LastEpisode.Ids.Tvdb.Should().Be(4849875U);
                traktShowCollectionProgress.LastEpisode.Ids.Imdb.Should().Be("tt0203245");
                traktShowCollectionProgress.LastEpisode.Ids.Tmdb.Should().Be(525364U);
                traktShowCollectionProgress.LastEpisode.Ids.TvRage.Should().Be(26414563U);
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

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

                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktShowCollectionProgress.Should().NotBeNull();

                traktShowCollectionProgress.Aired.Should().BeNull();
                traktShowCollectionProgress.Completed.Should().BeNull();
                traktShowCollectionProgress.LastCollectedAt.Should().BeNull();
                traktShowCollectionProgress.Seasons.Should().BeNull();
                traktShowCollectionProgress.HiddenSeasons.Should().BeNull();
                traktShowCollectionProgress.NextEpisode.Should().BeNull();
                traktShowCollectionProgress.LastEpisode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktShowCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowCollectionProgressObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ShowCollectionProgressObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktShowCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);
                traktShowCollectionProgress.Should().BeNull();
            }
        }
    }
}

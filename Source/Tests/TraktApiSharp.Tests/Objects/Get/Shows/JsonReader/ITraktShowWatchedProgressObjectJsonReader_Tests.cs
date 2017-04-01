namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Shows")]
    public class ITraktShowWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktShowWatchedProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktShowWatchedProgress>));
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_COMPLETE);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_1);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_2);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_3);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_4);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_5);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_6);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().Be(2);
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().Be(2);
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_10);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_11);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_12);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_1);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_2);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_3);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_4);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_5);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_6);

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
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_7);

            traktShowWatchedProgress.Should().NotBeNull();

            traktShowWatchedProgress.Aired.Should().BeNull();
            traktShowWatchedProgress.Completed.Should().BeNull();
            traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
            traktShowWatchedProgress.Seasons.Should().BeNull();
            traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
            traktShowWatchedProgress.NextEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(default(string));
            traktShowWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(string.Empty);
            traktShowWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktShowWatchedProgress.Should().NotBeNull();

                traktShowWatchedProgress.Aired.Should().Be(2);
                traktShowWatchedProgress.Completed.Should().BeNull();
                traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
                traktShowWatchedProgress.Seasons.Should().BeNull();
                traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
                traktShowWatchedProgress.NextEpisode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktShowWatchedProgress.Should().NotBeNull();

                traktShowWatchedProgress.Aired.Should().BeNull();
                traktShowWatchedProgress.Completed.Should().Be(2);
                traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
                traktShowWatchedProgress.Seasons.Should().BeNull();
                traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
                traktShowWatchedProgress.NextEpisode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktShowWatchedProgress.Should().NotBeNull();

                traktShowWatchedProgress.Aired.Should().BeNull();
                traktShowWatchedProgress.Completed.Should().BeNull();
                traktShowWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
                traktShowWatchedProgress.Seasons.Should().BeNull();
                traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
                traktShowWatchedProgress.NextEpisode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

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
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktShowWatchedProgress.Should().NotBeNull();

                traktShowWatchedProgress.Aired.Should().BeNull();
                traktShowWatchedProgress.Completed.Should().BeNull();
                traktShowWatchedProgress.LastWatchedAt.Should().BeNull();
                traktShowWatchedProgress.Seasons.Should().BeNull();
                traktShowWatchedProgress.HiddenSeasons.Should().BeNull();
                traktShowWatchedProgress.NextEpisode.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            var traktShowWatchedProgress = jsonReader.ReadObject(default(JsonTextReader));
            traktShowWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktShowWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktShowWatchedProgress = traktJsonReader.ReadObject(jsonReader);
                traktShowWatchedProgress.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""aired"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""aired"": 2
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""completed"": 2
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ai"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""aired"": 2,
                ""com"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""lca"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""sea"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hid_sea"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""next_episode"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""aired"": 2,
                ""completed"": 2,
                ""last_watched_at"": ""2015-03-21T19:03:58.000Z"",
                ""seasons"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hidden_seasons"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""nextep"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""ai"": 2,
                ""com"": 2,
                ""lca"": ""2015-03-21T19:03:58.000Z"",
                ""sea"": [
                  {
                    ""number"": 1,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  },
                  {
                    ""number"": 2,
                    ""aired"": 8,
                    ""completed"": 2,
                    ""episodes"": [
                      {
                        ""number"": 1,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      },
                      {
                        ""number"": 2,
                        ""completed"": true,
                        ""last_watched_at"": ""2015-03-21T19:03:58.000Z""
                      }
                    ]
                  }
                ],
                ""hid_sea"": [
                  {
                    ""number"": 0,
                    ""ids"": {
                      ""trakt"": 3051,
                      ""tvdb"": 498968,
                      ""tmdb"": 53334,
                      ""tvrage"": 252213354
                    }
                  }
                ],
                ""nextep"": {
                  ""season"": 1,
                  ""number"": 3,
                  ""title"": ""Water"",
                  ""ids"": {
                    ""trakt"": 62315,
                    ""tvdb"": 4849873,
                    ""imdb"": ""tt0203244"",
                    ""tmdb"": 525363,
                    ""tvrage"": 26414562
                  }
                }
              }";
    }
}

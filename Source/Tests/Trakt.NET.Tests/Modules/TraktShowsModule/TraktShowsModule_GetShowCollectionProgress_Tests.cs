namespace TraktNet.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_COLLECTION_PROGRESS_URI = $"shows/{SHOW_ID}/progress/collection";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_SHOW_COLLECTION_PROGRESS_URI,
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_Hidden()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?hidden={ProgressHidden}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, PROGRESS_HIDDEN);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_Hidden_And_Specials()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?hidden={ProgressHidden}&specials={ProgressSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, PROGRESS_HIDDEN, PROGRESS_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_Hidden_And_CountSpecials()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?hidden={ProgressHidden}&count_specials={ProgressCountSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, PROGRESS_HIDDEN, null, PROGRESS_COUNT_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_Specials()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?specials={ProgressSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, null, PROGRESS_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_Specials_And_CountSpecials()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?specials={ProgressSpecials}&count_specials={ProgressCountSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, null, PROGRESS_SPECIALS, PROGRESS_COUNT_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_With_CountSpecials()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?count_specials={ProgressCountSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, null, null, PROGRESS_COUNT_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowCollectionProgress_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_SHOW_COLLECTION_PROGRESS_URI}?hidden={ProgressHidden}&specials={ProgressSpecials}&count_specials={ProgressCountSpecials}",
                SHOW_COLLECTION_PROGRESS_JSON);

            TraktResponse<ITraktShowCollectionProgress> response =
                await client.Shows.GetShowCollectionProgressAsync(SHOW_ID, PROGRESS_HIDDEN, PROGRESS_SPECIALS, PROGRESS_COUNT_SPECIALS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCollectionProgress responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            ITraktSeasonCollectionProgress[] seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            ITraktEpisodeCollectionProgress[] episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            ITraktSeason[] hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_COLLECTION_PROGRESS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowCollectionProgress_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_SHOW_COLLECTION_PROGRESS_URI,
                SHOW_COLLECTION_PROGRESS_JSON);

            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act = () => client.Shows.GetShowCollectionProgressAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowCollectionProgressAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowCollectionProgressAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}

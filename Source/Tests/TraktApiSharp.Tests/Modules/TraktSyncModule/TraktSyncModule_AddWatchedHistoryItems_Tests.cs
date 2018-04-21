namespace TraktApiSharp.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Implementations;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        [Fact]
        public async Task Test_TraktSyncModule_AddWatchedHistoryItems()
        {
            var historyPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncHistoryPostShowEpisode>()
                                {
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            string postJson = await TestUtility.SerializeObject<ITraktSyncHistoryPost>(historyPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/history", postJson, HISTORY_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(historyPost).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Added.Should().NotBeNull();
            responseValue.Added.Movies.Should().Be(2);
            responseValue.Added.Episodes.Should().Be(72);
            responseValue.Added.Shows.Should().NotHaveValue();
            responseValue.Added.Seasons.Should().NotHaveValue();

            responseValue.NotFound.Should().NotBeNull();
            responseValue.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = responseValue.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            responseValue.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            responseValue.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItemsExceptions()
        {
            var historyPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            const string uri = "sync/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(historyPost);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_AddWatchedHistoryItemsArgumentExceptions()
        {
            Func<Task<TraktResponse<ITraktSyncHistoryPostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(new TraktSyncHistoryPost());
            act.Should().Throw<ArgumentException>();

            var collectionPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>(),
                Shows = new List<TraktSyncHistoryPostShow>(),
                Episodes = new List<TraktSyncHistoryPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(collectionPost);
            act.Should().Throw<ArgumentException>();
        }
    }
}

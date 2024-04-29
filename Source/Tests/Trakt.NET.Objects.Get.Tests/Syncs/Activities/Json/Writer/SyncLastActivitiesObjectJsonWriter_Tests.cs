namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonWriter")]
    public class SyncLastActivitiesObjectJsonWriter_Tests
    {
        private readonly DateTime ALL_AT = DateTime.UtcNow;
        private readonly DateTime BLOCKED_AT = DateTime.UtcNow.AddMinutes(5);
        private readonly DateTime COLLECTED_AT = DateTime.UtcNow.AddMinutes(10);
        private readonly DateTime COMMENTED_AT = DateTime.UtcNow.AddMinutes(15);
        private readonly DateTime FAVORITED_AT = DateTime.UtcNow.AddMinutes(20);
        private readonly DateTime FOLLOWED_AT = DateTime.UtcNow.AddMinutes(25);
        private readonly DateTime FOLLOWING_AT = DateTime.UtcNow.AddMinutes(30);
        private readonly DateTime HIDDEN_AT = DateTime.UtcNow.AddMinutes(35);
        private readonly DateTime LIKED_AT = DateTime.UtcNow.AddMinutes(40);
        private readonly DateTime PAUSED_AT = DateTime.UtcNow.AddMinutes(45);
        private readonly DateTime PENDING_AT = DateTime.UtcNow.AddMinutes(50);
        private readonly DateTime RATED_AT = DateTime.UtcNow.AddMinutes(55);
        private readonly DateTime RECOMMENDATIONS_AT = DateTime.UtcNow.AddMinutes(60);
        private readonly DateTime REQUESTED_AT = DateTime.UtcNow.AddMinutes(65);
        private readonly DateTime SETTINGS_AT = DateTime.UtcNow.AddMinutes(70);
        private readonly DateTime UPDATED_AT = DateTime.UtcNow.AddMinutes(75);
        private readonly DateTime WATCHED_AT = DateTime.UtcNow.AddMinutes(80);
        private readonly DateTime WATCHLISTED_AT = DateTime.UtcNow.AddMinutes(85);

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Exceptions()
        {
            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Empty()
        {
            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(new TraktSyncLastActivities());
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_All_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                All = ALL_AT
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"all\":\"{ALL_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Movies_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Movies = new TraktSyncMoviesLastActivities
                {
                    WatchedAt = WATCHED_AT,
                    CollectedAt = COLLECTED_AT,
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    FavoritedAt = FAVORITED_AT,
                    RecommendationsAt = RECOMMENDATIONS_AT,
                    CommentedAt = COMMENTED_AT,
                    PausedAt = PAUSED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"movies\":{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Episodes_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Episodes = new TraktSyncEpisodesLastActivities
                {
                    WatchedAt = WATCHED_AT,
                    CollectedAt = COLLECTED_AT,
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    CommentedAt = COMMENTED_AT,
                    PausedAt = PAUSED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"episodes\":{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Shows_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Shows = new TraktSyncShowsLastActivities
                {
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    FavoritedAt = FAVORITED_AT,
                    RecommendationsAt = RECOMMENDATIONS_AT,
                    CommentedAt = COMMENTED_AT,
                    HiddenAt = HIDDEN_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"shows\":{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Seasons_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Seasons = new TraktSyncSeasonsLastActivities
                {
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    CommentedAt = COMMENTED_AT,
                    HiddenAt = HIDDEN_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"seasons\":{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Comments_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Comments = new TraktSyncCommentsLastActivities
                {
                    LikedAt = LIKED_AT,
                    BlockedAt = BLOCKED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"comments\":{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"blocked_at\":\"{BLOCKED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Lists_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Lists = new TraktSyncListsLastActivities
                {
                    LikedAt = LIKED_AT,
                    UpdatedAt = UPDATED_AT,
                    CommentedAt = COMMENTED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"lists\":{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Watchlist_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Watchlist = new TraktSyncWatchlistLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"watchlist\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Favorites_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Favorites = new TraktSyncFavoritesLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"favorites\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Recommendations_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Recommendations = new TraktSyncRecommendationsLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"recommendations\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Collaborations_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Collaborations = new TraktSyncCollaborationsLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"collaborations\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_Account_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                Account = new TraktSyncAccountLastActivities
                {
                    SettingsAt = SETTINGS_AT,
                    FollowedAt = FOLLOWED_AT,
                    FollowingAt = FOLLOWING_AT,
                    PendingAt = PENDING_AT,
                    RequestedAt = REQUESTED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"account\":{{\"settings_at\":\"{SETTINGS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"followed_at\":\"{FOLLOWED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"following_at\":\"{FOLLOWING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"pending_at\":\"{PENDING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"requested_at\":\"{REQUESTED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Only_SavedFilters_Property()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                SavedFilters = new TraktSyncSavedFiltersLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"saved_filters\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }

        [Fact]
        public async Task Test_SyncLastActivitiesObjectJsonWriter_Complete()
        {
            ITraktSyncLastActivities syncLastActivities = new TraktSyncLastActivities
            {
                All = ALL_AT,
                Movies = new TraktSyncMoviesLastActivities
                {
                    WatchedAt = WATCHED_AT,
                    CollectedAt = COLLECTED_AT,
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    FavoritedAt = FAVORITED_AT,
                    RecommendationsAt = RECOMMENDATIONS_AT,
                    CommentedAt = COMMENTED_AT,
                    PausedAt = PAUSED_AT
                },
                Episodes = new TraktSyncEpisodesLastActivities
                {
                    WatchedAt = WATCHED_AT,
                    CollectedAt = COLLECTED_AT,
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    CommentedAt = COMMENTED_AT,
                    PausedAt = PAUSED_AT
                },
                Shows = new TraktSyncShowsLastActivities
                {
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    FavoritedAt = FAVORITED_AT,
                    RecommendationsAt = RECOMMENDATIONS_AT,
                    CommentedAt = COMMENTED_AT,
                    HiddenAt = HIDDEN_AT
                },
                Seasons = new TraktSyncSeasonsLastActivities
                {
                    RatedAt = RATED_AT,
                    WatchlistedAt = WATCHLISTED_AT,
                    CommentedAt = COMMENTED_AT,
                    HiddenAt = HIDDEN_AT
                },
                Comments = new TraktSyncCommentsLastActivities
                {
                    LikedAt = LIKED_AT,
                    BlockedAt = BLOCKED_AT
                },
                Lists = new TraktSyncListsLastActivities
                {
                    LikedAt = LIKED_AT,
                    UpdatedAt = UPDATED_AT,
                    CommentedAt = COMMENTED_AT
                },
                Watchlist = new TraktSyncWatchlistLastActivities
                {
                    UpdatedAt = UPDATED_AT
                },
                Favorites = new TraktSyncFavoritesLastActivities
                {
                    UpdatedAt = UPDATED_AT
                },
                Recommendations = new TraktSyncRecommendationsLastActivities
                {
                    UpdatedAt = UPDATED_AT
                },
                Collaborations = new TraktSyncCollaborationsLastActivities
                {
                    UpdatedAt = UPDATED_AT
                },
                Account = new TraktSyncAccountLastActivities
                {
                    SettingsAt = SETTINGS_AT,
                    FollowedAt = FOLLOWED_AT,
                    FollowingAt = FOLLOWING_AT,
                    PendingAt = PENDING_AT,
                    RequestedAt = REQUESTED_AT
                },
                SavedFilters = new TraktSyncSavedFiltersLastActivities
                {
                    UpdatedAt = UPDATED_AT
                }
            };

            var traktJsonWriter = new SyncLastActivitiesObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(syncLastActivities);
            json.Should().Be($"{{\"all\":\"{ALL_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"movies\":{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"episodes\":{{\"watched_at\":\"{WATCHED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"paused_at\":\"{PAUSED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"shows\":{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"favorited_at\":\"{FAVORITED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"recommendations_at\":\"{RECOMMENDATIONS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"seasons\":{{\"rated_at\":\"{RATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"watchlisted_at\":\"{WATCHLISTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"hidden_at\":\"{HIDDEN_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"comments\":{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"blocked_at\":\"{BLOCKED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"lists\":{{\"liked_at\":\"{LIKED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"commented_at\":\"{COMMENTED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"watchlist\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"favorites\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"recommendations\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"collaborations\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"account\":{{\"settings_at\":\"{SETTINGS_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"followed_at\":\"{FOLLOWED_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"following_at\":\"{FOLLOWING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"pending_at\":\"{PENDING_AT.ToTraktLongDateTimeString()}\"," +
                             $"\"requested_at\":\"{REQUESTED_AT.ToTraktLongDateTimeString()}\"}}," +
                             $"\"saved_filters\":{{\"updated_at\":\"{UPDATED_AT.ToTraktLongDateTimeString()}\"}}}}");
        }
    }
}

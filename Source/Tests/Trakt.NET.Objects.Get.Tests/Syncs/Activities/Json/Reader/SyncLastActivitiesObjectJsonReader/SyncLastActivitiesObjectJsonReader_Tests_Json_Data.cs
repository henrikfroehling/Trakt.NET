namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    public partial class SyncLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""a"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""mov"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""epi"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""sho"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""sea"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""com"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lis"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""wat"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""fa"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""rec"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""col"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""acc"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""saved_filters"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_13 =
            @"{
                ""all"": ""2023-06-30T13:38:37.000Z"",
                ""movies"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""watchlist"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""favorites"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""recommendations"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""collaborations"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""account"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""sav"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";

        private const string JSON_NOT_VALID_14 =
            @"{
                ""a"": ""2023-06-30T13:38:37.000Z"",
                ""mov"": {
                  ""watched_at"": ""2023-06-11T20:00:28.000Z"",
                  ""collected_at"": ""2015-02-18T12:54:39.000Z"",
                  ""rated_at"": ""2016-11-07T03:11:00.000Z"",
                  ""watchlisted_at"": ""2023-06-04T13:48:29.000Z"",
                  ""favorited_at"": ""2021-04-07T22:07:11.000Z"",
                  ""recommendations_at"": ""2021-04-07T22:07:11.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""epi"": {
                  ""watched_at"": ""2023-06-30T13:38:37.000Z"",
                  ""collected_at"": ""2016-11-09T23:16:22.000Z"",
                  ""rated_at"": ""2015-02-18T12:54:39.000Z"",
                  ""watchlisted_at"": ""2015-02-18T12:54:39.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""paused_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""sho"": {
                  ""rated_at"": ""2022-06-25T23:46:52.000Z"",
                  ""watchlisted_at"": ""2023-06-22T16:39:23.000Z"",
                  ""favorited_at"": ""2021-06-28T00:13:46.000Z"",
                  ""recommendations_at"": ""2021-06-28T00:13:46.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2022-12-20T19:34:50.000Z""
                },
                ""sea"": {
                  ""rated_at"": ""2022-06-25T23:46:39.000Z"",
                  ""watchlisted_at"": ""2022-10-06T17:42:50.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z"",
                  ""hidden_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""com"": {
                  ""liked_at"": ""2015-02-18T12:54:39.000Z"",
                  ""blocked_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""lis"": {
                  ""liked_at"": ""2022-06-28T21:32:53.000Z"",
                  ""updated_at"": ""2022-10-14T21:47:15.000Z"",
                  ""commented_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""wat"": {
                  ""updated_at"": ""2023-06-22T16:39:23.000Z""
                },
                ""fav"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""rec"": {
                  ""updated_at"": ""2022-05-14T19:04:12.000Z""
                },
                ""col"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""acc"": {
                  ""settings_at"": ""2023-06-26T18:08:03.000Z"",
                  ""followed_at"": ""2020-12-14T14:12:28.000Z"",
                  ""following_at"": ""2015-02-18T12:54:39.000Z"",
                  ""pending_at"": ""2015-02-18T12:54:39.000Z"",
                  ""requested_at"": ""2015-02-18T12:54:39.000Z""
                },
                ""sav"": {
                  ""updated_at"": ""2015-02-18T12:54:39.000Z""
                }
              }";
    }
}

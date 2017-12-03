namespace TraktApiSharp.Tests.Objects.Get.Watched.Json.Reader
{
    public partial class WatchedShowEpisodeArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""number"": 1
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""plays"": 1
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""num"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""pl"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""number"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""lwa"": ""2014-10-12T17:00:54.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""num"": 1,
                  ""plays"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 2,
                  ""pl"": 1,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                },
                {
                  ""number"": 3,
                  ""plays"": 1,
                  ""lwa"": ""2014-10-12T17:00:54.000Z""
                }
              ]";
    }
}

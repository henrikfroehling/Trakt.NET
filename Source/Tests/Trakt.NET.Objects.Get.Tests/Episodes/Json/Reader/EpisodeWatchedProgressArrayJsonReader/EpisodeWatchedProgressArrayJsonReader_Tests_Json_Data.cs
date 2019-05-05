namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    public partial class EpisodeWatchedProgressArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""number"": 1
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""completed"": true
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""nu"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""com"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""watat"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""nu"": 1,
                  ""completed"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""com"": true,
                  ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""wat"": ""2011-04-18T01:00:00.000Z""
                }
              ]";
    }
}

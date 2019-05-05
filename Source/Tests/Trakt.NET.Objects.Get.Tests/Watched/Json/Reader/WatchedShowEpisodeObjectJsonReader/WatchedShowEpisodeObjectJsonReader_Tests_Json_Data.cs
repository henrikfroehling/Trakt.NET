namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    public partial class WatchedShowEpisodeObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""number"": 1,
                ""plays"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""plays"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 1,
                ""plays"": 1
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 1
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""plays"": 1
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""num"": 1,
                ""plays"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 1,
                ""pl"": 1,
                ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 1,
                ""plays"": 1,
                ""lwa"": ""2014-10-12T17:00:54.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""num"": 1,
                ""pl"": 1,
                ""lwa"": ""2014-10-12T17:00:54.000Z""
              }";
    }
}

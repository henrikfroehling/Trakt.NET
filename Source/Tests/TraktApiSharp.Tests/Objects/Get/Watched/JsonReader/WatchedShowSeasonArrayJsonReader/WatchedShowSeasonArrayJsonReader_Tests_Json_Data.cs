namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    public partial class WatchedShowSeasonArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""number"": 1,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""num"": 1,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""number"": 1,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""eps"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""num"": 1,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""eps"": [
                    {
                      ""number"": 1,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    },
                    {
                      ""number"": 2,
                      ""plays"": 1,
                      ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                    }
                  ]
                }
              ]";
    }
}

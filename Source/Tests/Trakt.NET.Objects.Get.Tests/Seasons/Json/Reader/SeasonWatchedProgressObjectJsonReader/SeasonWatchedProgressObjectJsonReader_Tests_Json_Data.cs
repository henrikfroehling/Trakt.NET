namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    public partial class SeasonWatchedProgressObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nu"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 2,
                ""ti"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""air"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""com"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""number"": 2,
                ""title"": ""The first Hodor."",
                ""aired"": 3,
                ""completed"": 2,
                ""epi"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""nu"": 2,
                ""ti"": ""The first Hodor."",
                ""air"": 3,
                ""com"": 2,
                ""epi"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";
    }
}

namespace TraktNet.Tests.Objects.Get.Episodes.Json.Reader
{
    public partial class EpisodeCollectionProgressObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 2,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 2,
                ""completed"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 2
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""completed"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""n"": 2,
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 2,
                ""co"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""cl"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""n"": 2,
                ""co"": true,
                ""cl"": ""2011-04-18T01:00:00.000Z""
              }";
    }
}

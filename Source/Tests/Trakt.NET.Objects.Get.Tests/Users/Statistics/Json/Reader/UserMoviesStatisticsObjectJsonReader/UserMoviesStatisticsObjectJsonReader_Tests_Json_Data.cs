namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    public partial class UserMoviesStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""plays"": 552,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""plays"": 552
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""watched"": 534
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""minutes"": 17330
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""collected"": 117
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""ratings"": 64
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""pl"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""plays"": 552,
                ""w"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""min"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""col"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ra"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""com"": 14
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""pl"": 552,
                ""w"": 534,
                ""min"": 17330,
                ""col"": 117,
                ""ra"": 64,
                ""com"": 14
              }";
    }
}

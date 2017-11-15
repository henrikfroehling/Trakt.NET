namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json
{
    public partial class UserShowsStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watched"": 534,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""comments"": 14
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""ratings"": 64
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watched"": 534
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""collected"": 117
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""ratings"": 64
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wat"": 534,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watched"": 534,
                ""col"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""ra"": 64,
                ""comments"": 14
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""ratings"": 64,
                ""com"": 14
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""wat"": 534,
                ""col"": 117,
                ""ra"": 64,
                ""com"": 14
              }";
    }
}

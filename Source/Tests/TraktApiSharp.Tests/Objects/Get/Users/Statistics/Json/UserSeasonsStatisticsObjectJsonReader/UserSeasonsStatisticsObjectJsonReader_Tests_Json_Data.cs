namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json
{
    public partial class UserSeasonsStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""ratings"": 6,
                ""comments"": 1
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""comments"": 1
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""ratings"": 6
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ra"": 6,
                ""comments"": 1
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""ratings"": 6,
                ""com"": 1
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ra"": 6,
                ""com"": 1
              }";
    }
}

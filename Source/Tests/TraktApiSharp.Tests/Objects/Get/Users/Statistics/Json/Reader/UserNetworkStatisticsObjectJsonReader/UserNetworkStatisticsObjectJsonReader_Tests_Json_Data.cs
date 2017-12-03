namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    public partial class UserNetworkStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""friends"": 1,
                ""followers"": 4,
                ""following"": 11
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""followers"": 4,
                ""following"": 11
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""friends"": 1,
                ""following"": 11
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""friends"": 1,
                ""followers"": 4
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""friends"": 1
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""followers"": 4
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""following"": 11
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""fr"": 1,
                ""followers"": 4,
                ""following"": 11
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""friends"": 1,
                ""fo"": 4,
                ""following"": 11
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""friends"": 1,
                ""followers"": 4,
                ""follow"": 11
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""fr"": 1,
                ""fo"": 4,
                ""follow"": 11
              }";
    }
}

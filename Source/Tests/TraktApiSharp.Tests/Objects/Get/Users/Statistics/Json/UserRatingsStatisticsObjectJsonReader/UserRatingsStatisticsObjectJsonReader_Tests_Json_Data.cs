namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json
{
    public partial class UserRatingsStatisticsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""total"": 9257,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""total"": 9257
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tot"": 9257,
                ""distribution"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""total"": 9257,
                ""distri"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""tot"": 9257,
                ""distri"": {
                  ""1"": 78,
                  ""2"": 45,
                  ""3"": 55,
                  ""4"": 96,
                  ""5"": 183,
                  ""6"": 545,
                  ""7"": 1361,
                  ""8"": 2259,
                  ""9"": 1772,
                  ""10"": 2863
                }
              }";
    }
}

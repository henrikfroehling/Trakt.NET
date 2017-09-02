namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    public partial class ShowAirsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""day"": ""Sunday"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""day"": ""Sunday""
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""time"": ""21:00""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""d"": ""Sunday"",
                ""time"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""day"": ""Sunday"",
                ""t"": ""21:00"",
                ""timezone"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""day"": ""Sunday"",
                ""time"": ""21:00"",
                ""tz"": ""America/New_York""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""d"": ""Sunday"",
                ""t"": ""21:00"",
                ""tz"": ""America/New_York""
              }";
    }
}

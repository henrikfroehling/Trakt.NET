namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class SharingTextObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]"",
                ""rated"": ""[item] [stars]""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watched"": ""I just watched [item]"",
                ""rated"": ""[item] [stars]""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""rated"": ""[item] [stars]""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wa"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]"",
                ""rated"": ""[item] [stars]""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watd"": ""I just watched [item]"",
                ""rated"": ""[item] [stars]""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]"",
                ""ra"": ""[item] [stars]""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""wa"": ""I'm watching [item]"",
                ""watd"": ""I just watched [item]"",
                ""ra"": ""[item] [stars]""
              }";
    }
}

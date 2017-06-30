namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    public partial class TraktSharingTextObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""watched"": ""I just watched [item]""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watching"": ""I'm watching [item]""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wa"": ""I'm watching [item]"",
                ""watched"": ""I just watched [item]""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watching"": ""I'm watching [item]"",
                ""watd"": ""I just watched [item]""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""wa"": ""I'm watching [item]"",
                ""watd"": ""I just watched [item]""
              }";
    }
}

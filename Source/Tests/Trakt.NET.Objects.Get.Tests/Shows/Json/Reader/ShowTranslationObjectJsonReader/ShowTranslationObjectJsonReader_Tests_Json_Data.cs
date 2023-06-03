namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    public partial class ShowTranslationObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""language"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""country"": ""us""
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones"",
                ""ov"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""la"": ""de"",
                ""country"": ""us""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""title"": ""Game of Thrones"",
                ""overview"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""language"": ""de"",
                ""co"": ""us""
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""ti"": ""Game of Thrones"",
                ""ov"": ""Die Handlung ist in einer fiktiven Welt angesiedelt..."",
                ""la"": ""de"",
                ""co"": ""us""
              }";
    }
}

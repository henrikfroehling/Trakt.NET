namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    public partial class ShowAliasObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""country"": ""de""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""country"": ""de""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ti"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""country"": ""de""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""title"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""co"": ""de""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""ti"": ""Game of Thrones- Das Lied von Eis und Feuer"",
                ""co"": ""de""
              }";
    }
}

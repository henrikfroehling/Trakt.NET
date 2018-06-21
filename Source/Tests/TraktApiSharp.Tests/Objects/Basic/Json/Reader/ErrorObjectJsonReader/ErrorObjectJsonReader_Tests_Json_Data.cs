namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class ErrorObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""error"": ""trakt error"",
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""error"": ""trakt error""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""error"": ""trakt error"",
                ""err_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""err"": ""trakt error"",
                ""error_description"": ""trakt error description""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""err"": ""trakt error"",
                ""err_description"": ""trakt error description""
              }";
    }
}

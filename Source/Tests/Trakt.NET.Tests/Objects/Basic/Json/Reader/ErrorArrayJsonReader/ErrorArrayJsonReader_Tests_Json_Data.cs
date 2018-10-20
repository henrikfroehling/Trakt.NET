namespace TraktNet.Tests.Objects.Basic.Json.Reader.ErrorArrayJsonReader
{
    public partial class ErrorArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                },
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                },
                {
                  ""error"": ""trakt error""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""error"": ""trakt error""
                },
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""err"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                },
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""error"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                },
                {
                  ""err"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""err"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                },
                {
                  ""erreror"": ""trakt error"",
                  ""error_description"": ""trakt error description""
                }
              ]";
    }
}

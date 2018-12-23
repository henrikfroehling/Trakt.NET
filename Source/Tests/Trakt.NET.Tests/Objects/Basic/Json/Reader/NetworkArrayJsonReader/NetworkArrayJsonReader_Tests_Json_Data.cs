namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class NetworkArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                    ""name"": ""ABC(US)""
                },
                {
                    ""name"": ""The CW""
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                    ""name"": ""ABC(US)""
                },
                {
                    ""na"": ""The CW""
                }
              ]";
    }
}

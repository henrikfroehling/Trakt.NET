namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    public partial class NetworkObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""ABC(US)""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""na"": ""ABC(US)""
              }";
    }
}

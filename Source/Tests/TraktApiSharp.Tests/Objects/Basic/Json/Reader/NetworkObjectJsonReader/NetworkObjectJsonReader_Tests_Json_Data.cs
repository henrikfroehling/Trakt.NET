namespace TraktNet.Tests.Objects.Basic.Json.Reader
{
    public partial class NetworkObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""network"": ""ABC(US)""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""nw"": ""ABC(US)""
              }";
    }
}

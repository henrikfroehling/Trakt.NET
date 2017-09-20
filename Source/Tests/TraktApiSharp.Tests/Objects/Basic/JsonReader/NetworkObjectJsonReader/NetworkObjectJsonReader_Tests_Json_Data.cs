namespace TraktApiSharp.Tests.Objects.Basic.JsonReader.NetworkObjectJsonReader
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

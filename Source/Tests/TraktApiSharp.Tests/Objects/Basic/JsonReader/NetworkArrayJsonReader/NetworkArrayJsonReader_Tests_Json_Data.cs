namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    public partial class NetworkArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                    ""network"": ""ABC(US)""
                },
                {
                    ""network"": ""The CW""
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                    ""network"": ""ABC(US)""
                },
                {
                    ""nw"": ""The CW""
                }
              ]";
    }
}

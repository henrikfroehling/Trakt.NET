namespace TraktNET.SourceGeneration.Requests
{
    public sealed class TraktGetRequestGeneratorTests
    {
        [Fact]
        public Task TestGenerateGetRequest()
        {
            string source = """
                using TraktNET;
                
                namespace SourceGeneraterTestNamespace
                {
                    [TraktGetRequest("notes")]
                    public sealed partial class TestGetRequest
                    {
                    }
                }
                """;

            return TestHelper.Verify<TraktGetRequestSourceGenerator>("Requests", "SourceGeneration.GetRequest", source, RequestTestType.GetRequest);
        }
    }
}

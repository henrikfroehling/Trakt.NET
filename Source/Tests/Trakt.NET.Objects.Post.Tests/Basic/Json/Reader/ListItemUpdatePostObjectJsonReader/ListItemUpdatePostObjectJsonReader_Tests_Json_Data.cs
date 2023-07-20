namespace TraktNet.Objects.Post.Tests.Basic.Json.Reader
{
    public partial class ListItemUpdatePostObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""notes"": ""This is a great movie!""
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""not"": ""This is a great movie!""
              }";
    }
}

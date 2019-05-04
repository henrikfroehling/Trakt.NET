namespace Trakt.NET.Objects.Tests.Post.Users.Json.Reader
{
    public partial class UserCustomListsReorderPostObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rank"": [
                  823,
                  224,
                  88768,
                  356456,
                  245,
                  2,
                  890
                ]
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""ra"": [
                  823,
                  224,
                  88768,
                  356456,
                  245,
                  2,
                  890
                ]
              }";
    }
}

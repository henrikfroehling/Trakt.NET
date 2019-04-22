namespace TraktNet.Objects.Tests.Post.Checkins.Responses.Json.Reader
{
    public partial class CheckinPostErrorResponseObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""expires_at"": ""2016-04-01T12:44:40Z"",
              }";

        private const string JSON_NOT_VALID =
            @"{
                ""ea"": ""2016-04-01T12:44:40Z"",
              }";
    }
}

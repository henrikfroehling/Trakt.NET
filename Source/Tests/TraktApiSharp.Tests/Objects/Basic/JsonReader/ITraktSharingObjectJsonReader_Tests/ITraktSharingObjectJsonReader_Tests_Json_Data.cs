namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    public partial class ITraktSharingObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""facebook"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""facebook"": true
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""twitter"": true
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""google"": true
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tumblr"": true
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""fb"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""facebook"": true,
                ""tw"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""go"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tb"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""md"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""facebook"": true,
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""sl"": true
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""fb"": true,
                ""tw"": true,
                ""go"": true,
                ""tb"": true,
                ""md"": true,
                ""sl"": true
              }";
    }
}

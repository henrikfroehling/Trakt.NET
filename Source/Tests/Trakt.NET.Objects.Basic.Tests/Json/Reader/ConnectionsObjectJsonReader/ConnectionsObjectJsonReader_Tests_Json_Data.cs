namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class ConnectionsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""twitter"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""apple"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tw"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""twitter"": true,
                ""go"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tbl"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""med"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""sl"": true,
                ""facebook"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""fb"": true,
                ""apple"": true
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apl"": true
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""tw"": true,
                ""go"": true,
                ""tbl"": true,
                ""med"": true,
                ""sl"": true,
                ""fb"": true,
                ""apl"": true
              }";
    }
}

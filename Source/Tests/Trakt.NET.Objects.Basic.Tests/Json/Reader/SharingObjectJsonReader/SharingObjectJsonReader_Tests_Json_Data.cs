namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class SharingObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""twitter"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""slack"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""twitter"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""google"": true
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""tumblr"": true
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""medium"": true
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tw"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""twitter"": true,
                ""goo"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tmbl"": true,
                ""medium"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""med"": true,
                ""slack"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""sl"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""tw"": true,
                ""goo"": true,
                ""tmbl"": true,
                ""med"": true,
                ""sl"": true
              }";
    }
}

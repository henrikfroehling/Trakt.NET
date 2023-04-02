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
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""twitter"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""dropbox"": true
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tw"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""twitter"": true,
                ""gg"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tbl"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""md"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""sl"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""fb"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""app"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mas"": true,
                ""microsoft"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""mic"": true,
                ""dropbox"": true
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""twitter"": true,
                ""google"": true,
                ""tumblr"": true,
                ""medium"": true,
                ""slack"": true,
                ""facebook"": true,
                ""apple"": true,
                ""mastodon"": true,
                ""microsoft"": true,
                ""db"": true
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
                ""tw"": true,
                ""gg"": true,
                ""tbl"": true,
                ""md"": true,
                ""sl"": true,
                ""fb"": true,
                ""app"": true,
                ""mas"": true,
                ""mic"": true,
                ""db"": true
              }";
    }
}

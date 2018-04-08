namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    public partial class TraktCommentsModule_Tests
    {
        private const string COMMENT_JSON =
            @"{
                ""id"": 76957,
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""parent_id"": 0,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""replies"": 1,
                ""likes"": 2,
                ""user_rating"": 7.3,
                ""user"": {
                  ""username"": ""WalterBishopj"",
                  ""private"": false,
                  ""name"": ""Walter"",
                  ""vip"": false,
                  ""vip_ep"": false
                }
              }";

        private const string COMMENT_REPLIES_JSON =
            @"[
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 76957,
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""parent_id"": 0,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""WalterBishopj"",
                    ""private"": false,
                    ""name"": ""Walter"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string COMMENT_POST_RESPONSE_JSON =
            @"{
                ""id"": 190,
                ""parent_id"": 0,
                ""created_at"": ""2014-08-04T06:46:01.996Z"",
                ""comment"": ""Oh, I wasn't really listening."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 0,
                ""likes"": 0,
                ""user_rating"": null,
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false
                },
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""tumblr"": false,
                  ""medium"": true
                }
              }";
    }
}

namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CommentArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3
                },
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""i"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""id"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""iid"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""i"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                },
                {
                  ""iid"": 76957,
                  ""parent_id"": 1234,
                  ""created_at"": ""2016-04-01T12:44:40Z"",
                  ""updated_at"": ""2016-04-03T08:23:38Z"",
                  ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 2,
                  ""user_rating"": 7.3,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              ]";
    }
}

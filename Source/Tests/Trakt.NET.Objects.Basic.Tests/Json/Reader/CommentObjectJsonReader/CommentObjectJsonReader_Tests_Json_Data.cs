﻿namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CommentObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""id"": 76957,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
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
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""i"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""id"": 76957,
                ""pi"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""ca"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""ua"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""com"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""sp"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""rev"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""rep"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""like"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""us"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
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
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_stats"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
                ""i"": 76957,
                ""pi"": 1234,
                ""ca"": ""2016-04-01T12:44:40Z"",
                ""ua"": ""2016-04-03T08:23:38Z"",
                ""com"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""sp"": false,
                ""rev"": false,
                ""rep"": 1,
                ""like"": 2,
                ""us"": {
                  ""rating"": 8,
                  ""play_count"": 1,
                  ""completed_count"": 1
                },
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";
    }
}

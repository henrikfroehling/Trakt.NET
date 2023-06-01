namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        private const string TYPE_COMMENT_JSON_COMPLETE =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""comment"",
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_1 =
            @"{
                ""type"": ""comment"",
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_3 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""comment""
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_4 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z""
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""comment""
              }";

        private const string TYPE_COMMENT_JSON_INCOMPLETE_6 =
            @"{
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_NOT_VALID_1 =
            @"{
                ""la"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""comment"",
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""ty"": ""comment"",
                ""comment"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_NOT_VALID_3 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""comment"",
                ""com"": {
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
                }
              }";

        private const string TYPE_COMMENT_JSON_NOT_VALID_4 =
            @"{
                ""la"": ""2015-03-30T23:18:42.000Z"",
                ""ty"": ""comment"",
                ""com"": {
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
                }
              }";

        // ===================================================================================

        private const string TYPE_LIST_JSON_COMPLETE =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_1 =
            @"{
                ""type"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_2 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_3 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""list""
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_4 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z""
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_5 =
            @"{
                ""type"": ""list""
              }";

        private const string TYPE_LIST_JSON_INCOMPLETE_6 =
            @"{
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_1 =
            @"{
                ""la"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_2 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""ty"": ""list"",
                ""list"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_3 =
            @"{
                ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                ""type"": ""list"",
                ""li"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";

        private const string TYPE_LIST_JSON_NOT_VALID_4 =
            @"{
                ""la"": ""2015-03-30T23:18:42.000Z"",
                ""ty"": ""list"",
                ""li"": {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": false,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 1,
                  ""likes"": 2,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  },
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""sean""
                    }
                  }
                }
              }";
    }
}

namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    public partial class ListObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""name"": ""Star Wars in machete order"",
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
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
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
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
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
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
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
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
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
                ""updated_at"": ""2014-11-09T17:00:54.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
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
                }
              }";

        private const string JSON_INCOMPLETE_15 =
            @"{
                ""name"": ""Star Wars in machete order""
              }";

        private const string JSON_INCOMPLETE_16 =
            @"{
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI.""
              }";

        private const string JSON_INCOMPLETE_17 =
            @"{
                ""privacy"": ""public""
              }";

        private const string JSON_INCOMPLETE_18 =
            @"{
                ""display_numbers"": true
              }";

        private const string JSON_INCOMPLETE_19 =
            @"{
                ""allow_comments"": false
              }";

        private const string JSON_INCOMPLETE_20 =
            @"{
                ""sort_by"": ""rank""
              }";

        private const string JSON_INCOMPLETE_21 =
            @"{
                ""sort_how"": ""asc""
              }";

        private const string JSON_INCOMPLETE_22 =
            @"{
                ""created_at"": ""2014-10-11T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_23 =
            @"{
                ""updated_at"": ""2014-11-09T17:00:54.000Z""
              }";

        private const string JSON_INCOMPLETE_24 =
            @"{
                ""item_count"": 5
              }";

        private const string JSON_INCOMPLETE_25 =
            @"{
                ""comment_count"": 1
              }";

        private const string JSON_INCOMPLETE_26 =
            @"{
                ""likes"": 2
              }";

        private const string JSON_INCOMPLETE_27 =
            @"{
                ""ids"": {
                  ""trakt"": 55,
                  ""slug"": ""star-wars-in-machete-order""
                }
              }";

        private const string JSON_INCOMPLETE_28 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nm"": ""Star Wars in machete order"",
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""des"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""pri"": ""public"",
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""dn"": true,
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""ac"": false,
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sb"": ""rank"",
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
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sh"": ""asc"",
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
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""ca"": ""2014-10-11T17:00:54.000Z"",
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
              }";

        private const string JSON_NOT_VALID_9 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
                ""ua"": ""2014-11-09T17:00:54.000Z"",
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
              }";

        private const string JSON_NOT_VALID_10 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""privacy"": ""public"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
                ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                ""ic"": 5,
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
              }";

        private const string JSON_NOT_VALID_11 =
            @"{
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
                ""cc"": 1,
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
              }";

        private const string JSON_NOT_VALID_12 =
            @"{
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
                ""like"": 2,
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
              }";

        private const string JSON_NOT_VALID_13 =
            @"{
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
                ""id"": {
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
              }";

        private const string JSON_NOT_VALID_14 =
            @"{
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
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";

        private const string JSON_NOT_VALID_15 =
            @"{
                ""nm"": ""Star Wars in machete order"",
                ""des"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                ""pri"": ""public"",
                ""dn"": true,
                ""ac"": false,
                ""sb"": ""rank"",
                ""sh"": ""asc"",
                ""ca"": ""2014-10-11T17:00:54.000Z"",
                ""ua"": ""2014-11-09T17:00:54.000Z"",
                ""ic"": 5,
                ""cc"": 1,
                ""like"": 2,
                ""id"": {
                  ""trakt"": 55,
                  ""slug"": ""star-wars-in-machete-order""
                },
                ""usr"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                }
              }";
    }
}

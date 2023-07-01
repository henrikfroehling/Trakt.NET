namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    public partial class ListObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
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

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_15 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_INCOMPLETE_16 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nm"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""des"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""pri"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""sl"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_5 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""ty"": ""personal"",
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

        private const string JSON_NOT_VALID_6 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_7 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_8 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_9 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_10 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_11 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_12 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_13 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_14 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
                ""display_numbers"": true,
                ""allow_comments"": false,
                ""sort_by"": ""rank"",
                ""sort_how"": ""asc"",
                ""created_at"": ""2014-10-11T17:00:54.000Z"",
                ""updated_at"": ""2014-11-09T17:00:54.000Z"",
                ""item_count"": 5,
                ""comment_count"": 1,
                ""lk"": 2,
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

        private const string JSON_NOT_VALID_15 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_16 =
            @"{
                ""name"": ""Star Wars in machete order"",
                ""description"": ""Next time you want to introduce someone to Star Wars..."",
                ""privacy"": ""public"",
                ""share_link"": ""https://trakt.tv/lists/55"",
                ""type"": ""personal"",
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

        private const string JSON_NOT_VALID_17 =
            @"{
                ""nm"": ""Star Wars in machete order"",
                ""des"": ""Next time you want to introduce someone to Star Wars..."",
                ""pri"": ""public"",
                ""sl"": ""https://trakt.tv/lists/55"",
                ""ty"": ""personal"",
                ""dn"": true,
                ""ac"": false,
                ""sb"": ""rank"",
                ""sh"": ""asc"",
                ""ca"": ""2014-10-11T17:00:54.000Z"",
                ""ua"": ""2014-11-09T17:00:54.000Z"",
                ""ic"": 5,
                ""cc"": 1,
                ""lk"": 2,
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

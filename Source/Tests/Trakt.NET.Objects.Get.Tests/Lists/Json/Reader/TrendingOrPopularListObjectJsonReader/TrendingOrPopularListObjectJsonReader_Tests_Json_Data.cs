namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    public partial class TrendingOrPopularListObjectJsonReader_Tests_Json_Data
    {
        private const string JSON_COMPLETE =
            @"{
                ""like_count"": 5,
                ""comment_count"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""comment_count"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""like_count"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""like_count"": 5,
                ""comment_count"": 5
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""lc"": 5,
                ""comment_count"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""like_count"": 5,
                ""cc"": 5,
                ""list"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""like_count"": 5,
                ""comment_count"": 5,
                ""li"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""lc"": 5,
                ""cc"": 5,
                ""li"": {
                  ""name"": ""Incredible Thoughts"",
                  ""description"": ""How could my brain conceive them?"",
                  ""privacy"": ""public"",
                  ""share_link"": ""https://trakt.tv/lists/1337"",
                  ""type"": ""personal"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 50,
                  ""comment_count"": 10,
                  ""likes"": 99,
                  ""ids"": {
                    ""trakt"": 1337,
                    ""slug"": ""incredible-thoughts""
                  },
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              }";
    }
}

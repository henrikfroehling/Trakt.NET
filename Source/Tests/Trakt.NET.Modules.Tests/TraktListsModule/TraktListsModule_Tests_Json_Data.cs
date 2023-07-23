namespace TraktNet.Modules.Tests.TraktListsModule
{
    using TraktNet.Enums;
    using TraktNet.Parameters;

    public partial class TraktListsModule_Tests
    {
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int ITEM_COUNT = 2;
        private const string LIST_ID = "55";
        private const uint TRAKT_LIST_ID = 55;
        private const string LIST_SLUG = "incredible-thoughts";
        private readonly TraktListItemType LIST_ITEM_TYPE = TraktListItemType.Movie;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private const int LIST_ITEM_COUNT = 5;
        private const int LIST_LIKES_COUNT = 2;
        private const int LIST_COMMENTS_ITEM_COUNT = 2;
        private readonly TraktCommentSortOrder COMMENT_SORT_ORDER = TraktCommentSortOrder.Likes;
        private const uint LIST_COMMENTS_LIMIT = 4;

        private const string SINGLE_LIST_JSON =
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

        private const string LIST_ITEMS_JSON =
            @"[
                {
                  ""rank"": ""1"",
                  ""listed_at"": ""2014-06-16T06:07:12.000Z"",
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""Star Wars: Episode IV - A New Hope"",
                    ""year"": 1977,
                    ""ids"": {
                      ""trakt"": 12,
                      ""slug"": ""star-wars-episode-iv-a-new-hope-1977"",
                      ""imdb"": ""tt0076759"",
                      ""tmdb"": 11
                    }
                  }
                },
                {
                  ""rank"": ""2"",
                  ""listed_at"": ""2014-06-16T06:07:12.000Z"",
                  ""type"": ""show"",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402,
                      ""tvrage"": null
                    }
                  }
                },
                {
                  ""rank"": ""3"",
                  ""listed_at"": ""2014-06-16T06:07:12.000Z"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""tvdb"": 30272,
                      ""tmdb"": 3572,
                      ""tvrage"": null
                    }
                  },
                  ""show"": {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""breaking-bad"",
                      ""tvdb"": 81189,
                      ""imdb"": ""tt0903747"",
                      ""tmdb"": 1396,
                      ""tvrage"": 18164
                    }
                  }
                },
                {
                  ""rank"": ""4"",
                  ""listed_at"": ""2014-06-17T06:52:03.000Z"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 0,
                    ""number"": 2,
                    ""title"": ""Wedding Day"",
                    ""ids"": {
                      ""trakt"": 2,
                      ""tvdb"": 3859791,
                      ""imdb"": null,
                      ""tmdb"": 62133,
                      ""tvrage"": null
                    }
                  },
                  ""show"": {
                    ""title"": ""Breaking Bad"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""breaking-bad"",
                      ""tvdb"": 81189,
                      ""imdb"": ""tt0903747"",
                      ""tmdb"": 1396,
                      ""tvrage"": 18164
                    }
                  }
                },
                {
                  ""rank"": ""5"",
                  ""listed_at"": ""2014-06-17T06:52:03.000Z"",
                  ""type"": ""person"",
                  ""person"": {
                    ""name"": ""Garrett Hedlund"",
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""garrett-hedlund"",
                      ""imdb"": ""nm1330560"",
                      ""tmdb"": 9828,
                      ""tvrage"": null
                    }
                  }
                }
              ]";

        private const string LIST_LIKES_JSON =
            @"[
                {
                  ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                },
                {
                  ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": true,
                    ""ids"": {
                      ""slug"": ""justin""
                    }
                  }
                }
              ]";

        private const string TRENDING_OR_POPULAR_LISTS_JSON =
            @"[
                {
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
                },
                {
                  ""like_count"": 109,
                  ""comment_count"": 20,
                  ""list"": {
                    ""name"": ""Top Chihuahua Movies"",
                    ""description"": ""So cute."",
                    ""privacy"": ""public"",
                    ""share_link"": ""https://trakt.tv/lists/1338"",
                    ""type"": ""personal"",
                    ""display_numbers"": true,
                    ""allow_comments"": true,
                    ""sort_by"": ""rank"",
                    ""sort_how"": ""asc"",
                    ""created_at"": ""2015-10-11T17:00:54.000Z"",
                    ""updated_at"": ""2015-10-11T17:00:54.000Z"",
                    ""item_count"": 50,
                    ""comment_count"": 20,
                    ""likes"": 109,
                    ""ids"": {
                      ""trakt"": 1338,
                      ""slug"": ""top-chihuahua-movies""
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
                }
              ]";

        private const string LIST_COMMENTS_JSON =
            @"[
                {
                  ""id"": 8,
                  ""parent_id"": 0,
                  ""created_at"": ""2011-03-25T22:35:17.000Z"",
                  ""updated_at"": ""2011-03-25T22:35:17.000Z"",
                  ""comment"": ""Great episode!"",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 0,
                  ""user_rating"": 8,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 9,
                  ""parent_id"": 0,
                  ""created_at"": ""2011-03-25T22:35:17.000Z"",
                  ""updated_at"": ""2011-03-25T22:35:17.000Z"",
                  ""comment"": ""Great episode!"",
                  ""spoiler"": false,
                  ""review"": false,
                  ""replies"": 1,
                  ""likes"": 0,
                  ""user_rating"": 8,
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                }
              ]";
    }
}

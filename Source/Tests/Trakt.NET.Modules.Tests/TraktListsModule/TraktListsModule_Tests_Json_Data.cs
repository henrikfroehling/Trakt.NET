namespace TraktNet.Modules.Tests.TraktListsModule
{
    using TraktNet.Enums;
    using TraktNet.Requests.Parameters;

    public partial class TraktListsModule_Tests
    {
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private const int ITEM_COUNT = 2;
        private const string LIST_ID = "55";
        private readonly TraktListItemType LIST_ITEM_TYPE = TraktListItemType.Movie;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private const int LIST_ITEM_COUNT = 5;
        private const int LIST_LIKES_COUNT = 2;

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

        private const string LISTS_JSON =
            @"[
                {
                  ""like_count"": 1004,
                  ""comment_count"": 71,
                  ""list"": {
                    ""name"": ""Best Mindfucks"",
                    ""description"": ""What’s a mindfuck? A movie that plays with your mind, confuses you, and leads you on. It’s not just a movie with a twist ending. Mindfucks are borderline-incoherent, dreamlike, and surreal."",
                    ""privacy"": ""public"",
                    ""display_numbers"": false,
                    ""allow_comments"": true,
                    ""sort_by"": ""rank"",
                    ""sort_how"": ""asc"",
                    ""created_at"": ""2012-06-30T23:29:30.000Z"",
                    ""updated_at"": ""2018-05-28T10:01:41.000Z"",
                    ""item_count"": 116,
                    ""comment_count"": 71,
                    ""likes"": 1004,
                    ""ids"": {
                      ""trakt"": 800238,
                      ""slug"": ""best-mindfucks""
                    },
                    ""user"": {
                      ""username"": ""BenFranklin"",
                      ""private"": false,
                      ""name"": ""Ben"",
                      ""vip"": true,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""benfranklin""
                      }
                    }
                  }
                },
                {
                  ""like_count"": 639,
                  ""comment_count"": 20,
                  ""list"": {
                    ""name"": ""Marvel Cinematic Universe Timeline"",
                    ""description"": ""This is the entire canon Marvel Cinematic Universe in it's chronological order. Includes:All Movies,Marvel One-Shots, andMarvel's Agents of S.H.I.E.L.D."",
                    ""privacy"": ""public"",
                    ""display_numbers"": true,
                    ""allow_comments"": true,
                    ""sort_by"": ""rank"",
                    ""sort_how"": ""asc"",
                    ""created_at"": ""2013-11-14T05:20:39.000Z"",
                    ""updated_at"": ""2018-05-28T10:01:46.000Z"",
                    ""item_count"": 42,
                    ""comment_count"": 20,
                    ""likes"": 639,
                    ""ids"": {
                      ""trakt"": 828103,
                      ""slug"": ""marvel-cinematic-universe-timeline""
                    },
                    ""user"": {
                      ""username"": ""Geekritique"",
                      ""private"": false,
                      ""name"": ""Dakota Ritique"",
                      ""vip"": false,
                      ""vip_ep"": false,
                      ""ids"": {
                        ""slug"": ""geekritique""
                      }
                    }
                  }
                }
              ]";
    }
}

namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using System;
    using System.Collections.Generic;
    using TraktNet.Enums;
    using TraktNet.Parameters;

    public partial class TraktUsersModule_Tests
    {
        private const string ENCODED_COMMA = "%2C";
        private const string USERNAME = "sean";
        private const string LIST_ID = "55";
        private readonly TraktListItemType LIST_ITEM_TYPE = TraktListItemType.Movie;
        private readonly TraktListItemType LIST_ITEM_TYPE_MOVIE = TraktListItemType.Movie;
        private readonly TraktListItemType LIST_ITEM_TYPE_SHOW = TraktListItemType.Show;
        private const uint REQUEST_ID = 3U;
        private const string LIST_NAME = "new list";
        private const string NEW_LIST_NAME = "new list name";
        private const string DESCRIPTION = "list description";
        private readonly TraktAccessScope PRIVACY = TraktAccessScope.Public;
        private const bool DISPLAY_NUMBERS = true;
        private const bool ALLOW_COMMENTS = true;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private const int COMMENTS_ITEM_COUNT = 5;
        private readonly TraktCommentType COMMENT_TYPE = TraktCommentType.Shout;
        private readonly TraktObjectType OBJECT_TYPE = TraktObjectType.Episode;
        private const uint PAGE = 2;
        private const int LIMIT = 4;
        private const uint COMMENTS_LIMIT = 6;
        private readonly TraktHiddenItemsSection HIDDEN_ITEMS_SECTION = TraktHiddenItemsSection.Calendar;
        private const int HIDDEN_ITEMS_COUNT = 3;
        private readonly TraktHiddenItemType HIDDEN_ITEM_TYPE = TraktHiddenItemType.Movie;
        private const uint HIDDEN_ITEMS_LIMIT = 4;
        private const int LIKES_ITEM_COUNT = 2;
        private readonly TraktUserLikeType LIKE_TYPE = TraktUserLikeType.Comment;
        private const uint LIKES_LIMIT = 4;
        private const int LIST_COMMENTS_ITEM_COUNT = 2;
        private readonly TraktCommentSortOrder COMMENT_SORT_ORDER = TraktCommentSortOrder.Likes;
        private const uint LIST_COMMENTS_LIMIT = 4;
        private readonly TraktRatingsItemType RATINGS_ITEM_TYPE = TraktRatingsItemType.Movie;
        private const int HISTORY_ITEM_COUNT = 4;
        private const uint HISTORY_ITEM_ID = 4U;
        private readonly DateTime START_AT = DateTime.UtcNow.AddMonths(-1);
        private readonly DateTime END_AT = DateTime.UtcNow;
        private readonly TraktSyncItemType HISTORY_ITEM_TYPE = TraktSyncItemType.Episode;
        private const uint HISTORY_LIMIT = 4;
        private const int WATCHLIST_ITEM_COUNT = 4;
        private readonly TraktSortBy SORT_BY = TraktSortBy.Rank;
        private readonly TraktSortHow SORT_HOW = TraktSortHow.Ascending;
        private readonly TraktSyncItemType WATCHLIST_ITEM_TYPE = TraktSyncItemType.Movie;
        private readonly TraktWatchlistSortOrder WATCHLIST_SORT_ORDER = TraktWatchlistSortOrder.Rank;
        private const uint WATCHLIST_LIMIT = 4;
        private const string NEW_DESCRIPTION = "new list description";
        private readonly TraktAccessScope NEW_PRIVACY = TraktAccessScope.Private;
        private const bool NEW_DISPLAY_NUMBERS = false;
        private const bool NEW_ALLOW_COMMENTS = false;
        private readonly IEnumerable<uint> REORDERED_CUSTOM_LISTS = new List<uint> { 823, 224, 88768, 356456, 245, 2, 890 };
        private readonly IEnumerable<uint> REORDERED_CUSTOM_LIST_ITEMS = new List<uint> { 923, 324, 98768, 456456, 345, 12, 990 };
        private const int RATINGS_ITEM_COUNT = 5;
        private readonly TraktRecommendationObjectType RECOMMENDATION_TYPE = TraktRecommendationObjectType.Movie;
        private readonly TraktWatchlistSortOrder RECOMMENDATION_SORT_ORDER = TraktWatchlistSortOrder.Rank;
        private const int RECOMMENDATIONS_ITEM_COUNT = 2;
        private const int RECOMMENDATIONS_LIMIT = 6;
        private const int LIST_LIKES_LIMIT = 3;
        private const int LIST_LIKES_ITEM_COUNT = 2;
        private readonly TraktFilterSection FILTER_SECTION = TraktFilterSection.Movies;
        private const int SAVED_FILTERS_COUNT = 2;
        private const int SAVED_FILTERS_LIMIT = 4;
        private const int LIST_ITEMS_COUNT = 5;

        private string BuildRatingsFilterString(int[] ratings) => string.Join(ENCODED_COMMA, ratings);

        private const string CUSTOM_LIST_ITEMS_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 1,
                  ""seasons"": 1,
                  ""episodes"": 2,
                  ""people"": 1
                },
                ""existing"": {
                  ""movies"": 0,
                  ""shows"": 0,
                  ""seasons"": 0,
                  ""episodes"": 0,
                  ""people"": 0
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [ ],
                  ""seasons"": [ ],
                  ""episodes"": [ ],
                  ""people"": [ ]
                }
              }";

        private const string CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 1,
                  ""shows"": 1,
                  ""seasons"": 1,
                  ""episodes"": 2,
                  ""people"": 1
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [ ],
                  ""seasons"": [ ],
                  ""episodes"": [ ],
                  ""people"": [ ]
                }
              }";

        private const string FOLLOWER_JSON =
            @"{
                ""followed_at"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false
                }
              }";

        private const string FOLLOW_USER_RESPONSE_JSON =
            @"{
                ""approved_at"": ""2014-11-15T09:41:34.704Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": false
                }
              }";

        private const string COLLECTION_MOVIES_JSON =
            @"[
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""collected_at"": ""2014-09-01T09:10:11.000Z"",
                  ""movie"": {
                    ""title"": ""The Dark Knight"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 6,
                      ""slug"": ""the-dark-knight-2008"",
                      ""imdb"": ""tt0468569"",
                      ""tmdb"": 155
                    }
                  }
                }
              ]";

        private const string COLLECTION_SHOWS_JSON =
            @"[
                {
                  ""last_collected_at"": ""2014-09-01T09:10:11.000Z"",
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
                  },
                  ""seasons"": [
                    {
                      ""number"": 1,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        },
                        {
                          ""number"": 2,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        }
                      ]
                    },
                    {
                      ""number"": 2,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        },
                        {
                          ""number"": 2,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        }
                      ]
                    }
                  ]
                },
                {
                  ""last_collected_at"": ""2014-09-01T09:10:11.000Z"",
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
                  },
                  ""seasons"": [
                    {
                      ""number"": 1,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        },
                        {
                          ""number"": 2,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        }
                      ]
                    },
                    {
                      ""number"": 2,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        },
                        {
                          ""number"": 2,
                          ""collected_at"": ""2014-09-01T09:10:11.000Z""
                        }
                      ]
                    }
                  ]
                }
              ]";

        private const string USER_COMMENTS_JSON =
            @"[
                {
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""Batman Begins"",
                    ""year"": 2005,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    }
                  },
                  ""comment"": {
                    ""id"": 267,
                    ""comment"": ""Great kickoff to a new Batman trilogy!"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-25T00:14:57.000Z"",
                    ""updated_at"": ""2015-04-25T00:14:57.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 10,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                },
                {
                  ""type"": ""show"",
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
                  },
                  ""comment"": {
                    ""id"": 199,
                    ""comment"": ""Skyler, I AM THE DANGER."",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-02-18T06:02:30.000Z"",
                    ""updated_at"": ""2015-02-18T06:02:30.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 10,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                },
                {
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 3958,
                      ""tvdb"": 274431,
                      ""tmdb"": 60394,
                      ""tvrage"": 38049
                    }
                  },
                  ""show"": {
                    ""title"": ""Gotham"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 869,
                      ""slug"": ""gotham"",
                      ""tvdb"": 274431,
                      ""imdb"": ""tt3749900"",
                      ""tmdb"": 60708,
                      ""tvrage"": 38049
                    }
                  },
                  ""comment"": {
                    ""id"": 220,
                    ""comment"": ""Kicking off season 1 for a new Batman show."",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-21T06:53:25.000Z"",
                    ""updated_at"": ""2015-04-21T06:53:25.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": 8,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                },
                {
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Jim Gordon"",
                    ""ids"": {
                      ""trakt"": 63958,
                      ""tvdb"": 4768720,
                      ""imdb"": ""tt3216414"",
                      ""tmdb"": 975968,
                      ""tvrage"": 1065564827
                    }
                  },
                  ""show"": {
                    ""title"": ""Gotham"",
                    ""year"": 2014,
                    ""ids"": {
                      ""trakt"": 869,
                      ""slug"": ""gotham"",
                      ""tvdb"": 274431,
                      ""imdb"": ""tt3749900"",
                      ""tmdb"": 60708,
                      ""tvrage"": 38049
                    }
                  },
                  ""comment"": {
                    ""id"": 229,
                    ""comment"": ""Is this the OC?"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2015-04-21T15:42:31.000Z"",
                    ""updated_at"": ""2015-04-21T15:42:31.000Z"",
                    ""replies"": 1,
                    ""likes"": 0,
                    ""user_rating"": 7,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                },
                {
                  ""type"": ""list"",
                  ""list"": {
                    ""name"": ""Star Wars"",
                    ""description"": ""The complete Star Wars saga!"",
                    ""privacy"": ""public"",
                    ""display_numbers"": false,
                    ""allow_comments"": true,
                    ""updated_at"": ""2015-04-22T22:01:39.000Z"",
                    ""item_count"": 8,
                    ""comment_count"": 0,
                    ""likes"": 0,
                    ""ids"": {
                      ""trakt"": 51,
                      ""slug"": ""star-wars""
                    }
                  },
                  ""comment"": {
                    ""id"": 268,
                    ""comment"": ""May the 4th be with you!"",
                    ""spoiler"": false,
                    ""review"": false,
                    ""parent_id"": 0,
                    ""created_at"": ""2014-12-08T17:34:51.000Z"",
                    ""updated_at"": ""2014-12-08T17:34:51.000Z"",
                    ""replies"": 0,
                    ""likes"": 0,
                    ""user_rating"": null,
                    ""user"": {
                      ""username"": ""justin"",
                      ""private"": false,
                      ""name"": ""Justin N."",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                }
              ]";

        private const string LIST_JSON =
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
                  ""vip_ep"": false
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

        private const string LISTS_JSON =
            @"[
                {
                  ""name"": ""Star Wars in machete order"",
                  ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                  ""privacy"": ""public"",
                  ""display_numbers"": true,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 55,
                    ""slug"": ""star-wars-in-machete-order""
                  }
                },
                {
                  ""name"": ""Vampires FTW"",
                  ""description"": ""These suck, but in a good way!"",
                  ""privacy"": ""public"",
                  ""display_numbers"": false,
                  ""allow_comments"": true,
                  ""sort_by"": ""rank"",
                  ""sort_how"": ""asc"",
                  ""created_at"": ""2014-10-11T17:00:54.000Z"",
                  ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                  ""item_count"": 5,
                  ""comment_count"": 0,
                  ""likes"": 0,
                  ""ids"": {
                    ""trakt"": 52,
                    ""slug"": ""vampires-ftw""
                  }
                }
              ]";

        private const string FOLLOWERS_JSON =
            @"[
                {
                  ""followed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                },
                {
                  ""followed_at"": ""2014-10-01T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string FOLLOW_REQUESTS_JSON =
            @"[
                {
                  ""id"": 3,
                  ""requested_at"": ""2014-09-22T04:23:48.000Z"",
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                },
                {
                  ""id"": 5,
                  ""requested_at"": ""2014-11-01T09:12:23.000Z"",
                  ""user"": {
                    ""username"": ""paul"",
                    ""private"": false,
                    ""name"": ""Paul"",
                    ""vip"": false,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string FRIENDS_JSON =
            @"[
                {
                  ""friends_at"": ""2014-10-09T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""sean"",
                    ""private"": false,
                    ""name"": ""Sean Rudford"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                },
                {
                  ""friends_at"": ""2014-11-02T09:10:11.000Z"",
                  ""user"": {
                    ""username"": ""justin"",
                    ""private"": false,
                    ""name"": ""Justin Nemeth"",
                    ""vip"": true,
                    ""vip_ep"": false
                  }
                }
              ]";

        private const string SAVED_FILTERS_JSON =
            @"[
                {
                  ""id"": 1,
                  ""section"": ""movies"",
                  ""name"": ""Movies: IMDB + TMDB ratings"",
                  ""path"": ""/movies/recommended/weekly"",
                  ""query"": ""imdb_ratings=6.9-10.0&tmdb_ratings=4.2-10.0"",
                  ""updated_at"": ""2022-06-15T11:15:06.000Z""
                },
                {
                  ""id"": 2,
                  ""section"": ""shows"",
                  ""name"": ""Shows: US + Disney+"",
                  ""path"": ""/shows/popular"",
                  ""query"": ""watchnow=disney_plus&countries=us"",
                  ""updated_at"": ""2022-06-15T12:15:06.000Z""
                }
              ]";

        private const string HIDDEN_ITEMS_JSON =
            @"[
                {
                  ""hidden_at"": ""2015-05-23T23:18:42.000Z"",
                  ""type"": ""show"",
                  ""show"": {
                    ""title"": ""Gossip Girl"",
                    ""year"": 2007,
                    ""ids"": {
                      ""trakt"": 48,
                      ""slug"": ""gossip-girl"",
                      ""tvdb"": 80547,
                      ""imdb"": ""tt0397442"",
                      ""tmdb"": 1395,
                      ""tvrage"": 15619
                    }
                  }
                },
                {
                  ""hidden_at"": ""2015-03-30T23:19:33.000Z"",
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""Star Wars: The Force Awakens"",
                    ""year"": 2015,
                    ""ids"": {
                      ""trakt"": 94024,
                      ""slug"": ""star-wars-the-force-awakens-2015"",
                      ""imdb"": ""tt2488496"",
                      ""tmdb"": 140607
                    }
                  }
                },
                {
                  ""hidden_at"": ""2015-04-02T23:19:33.000Z"",
                  ""type"": ""season"",
                  ""season"": {
                    ""title"": ""Game of Thrones"",
                    ""year"": 2011,
                    ""ids"": {
                      ""trakt"": 1390,
                      ""slug"": ""game-of-thrones"",
                      ""tvdb"": 121361,
                      ""imdb"": ""tt0944947"",
                      ""tmdb"": 1399,
                      ""tvrage"": 24493
                    }
                  }
                }
              ]";

        private const string LIKES_JSON =
            @"[
                {
                  ""liked_at"": ""2015-03-31T23:18:42.000Z"",
                  ""type"": ""list"",
                  ""list"": {
                    ""name"": ""Star Wars in NEW machete order"",
                    ""description"": ""Next time you want to introduce someone to Star Wars for the first time, watch the films with them in this order: IV, V, II, III, VI."",
                    ""privacy"": ""private"",
                    ""display_numbers"": true,
                    ""allow_comments"": false,
                    ""updated_at"": ""2014-10-11T17:00:54.000Z"",
                    ""item_count"": 5,
                    ""comment_count"": 0,
                    ""likes"": 0,
                    ""ids"": {
                      ""trakt"": 55,
                      ""slug"": ""star-wars-in-machete-order""
                    },
                    ""user"": {
                      ""username"": ""sean"",
                      ""private"": false,
                      ""name"": ""Sean Rudford"",
                      ""vip"": true,
                      ""vip_ep"": false
                    }
                  }
                },
                {
                  ""liked_at"": ""2015-03-30T23:18:42.000Z"",
                  ""type"": ""comment"",
                  ""comment"": {
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

        private const string RATINGS_JSON =
            @"[
                {
                  ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                  ""rating"": 10,
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                  ""rating"": 10,
                  ""type"": ""show"",
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
                  ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                  ""rating"": 8,
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 0,
                    ""ids"": {
                      ""tvdb"": 439371,
                      ""tmdb"": 3577,
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
                  ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                  ""rating"": 5,
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 4,
                    ""number"": 1,
                    ""title"": ""Box Cutter"",
                    ""ids"": {
                      ""trakt"": 49,
                      ""tvdb"": 2639411,
                      ""imdb"": ""tt1683084"",
                      ""tmdb"": 62118,
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
                }
              ]";

        private const string SETTINGS_JSON =
            @"{
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""San Diego, CA"",
                  ""about"": ""Co-founder of trakt."",
                  ""gender"": ""male"",
                  ""age"": 32,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://secure.gravatar.com/avatar/30c2f0dfbc39e48656f40498aa871e33?r=pg&s=256""
                    }
                  }
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": false,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042""
                },
                ""connections"": {
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": false,
                  ""medium"": false,
                  ""slack"": false
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";

        private const string STATISTICS_JSON =
            @"{
                ""movies"": {
                  ""plays"": 155,
                  ""watched"": 114,
                  ""minutes"": 15650,
                  ""collected"": 933,
                  ""ratings"": 256,
                  ""comments"": 28
                },
                ""shows"": {
                  ""watched"": 16,
                  ""collected"": 7,
                  ""ratings"": 63,
                  ""comments"": 20
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 389,
                  ""distribution"": {
                    ""1"": 18,
                    ""2"": 1,
                    ""3"": 4,
                    ""4"": 1,
                    ""5"": 10,
                    ""6"": 9,
                    ""7"": 37,
                    ""8"": 37,
                    ""9"": 57,
                    ""10"": 215
                  }
                }
              }";

        private const string PROFILE_JSON =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true
              }";

        private const string HISTORY_JSON =
            @"[
                {
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""The Dark Knight"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 4,
                      ""slug"": ""the-dark-knight-2008"",
                      ""imdb"": ""tt0468569"",
                      ""tmdb"": 155
                    }
                  }
                },
                {
                ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 2,
                    ""number"": 1,
                    ""title"": ""Pawnee Zoo"",
                    ""ids"": {
                      ""trakt"": 251,
                      ""tvdb"": 797571,
                      ""imdb"": null,
                      ""tmdb"": 397629,
                      ""tvrage"": null
                    }
                  },
                  ""show"": {
                    ""title"": ""Parks and Recreation"",
                    ""year"": 2009,
                    ""ids"": {
                      ""trakt"": 4,
                      ""slug"": ""parks-and-recreation"",
                      ""tvdb"": 84912,
                      ""imdb"": ""tt1266020"",
                      ""tmdb"": 8592,
                      ""tvrage"": 21686
                    }
                  }
                },
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
                    ""title"": ""Parks and Recreation"",
                    ""year"": 2009,
                    ""ids"": {
                      ""trakt"": 4,
                      ""slug"": ""parks-and-recreation"",
                      ""tvdb"": 84912,
                      ""imdb"": ""tt1266020"",
                      ""tmdb"": 8592,
                      ""tvrage"": 21686
                    }
                  }
                },
                {
                  ""id"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 1,
                      ""tvdb"": 439371,
                      ""tmdb"": 3577,
                      ""tvrage"": null
                    }
                  }
                }
              ]";

        private const string WATCHED_MOVIES_JSON =
            @"[
                {
                  ""plays"": 4,
                  ""last_watched_at"": ""2014-10-11T17:00:54.000Z"",
                  ""movie"": {
                    ""title"": ""Batman Begins"",
                    ""year"": 2005,
                    ""ids"": {
                      ""trakt"": 6,
                      ""slug"": ""batman-begins-2005"",
                      ""imdb"": ""tt0372784"",
                      ""tmdb"": 272
                    }
                  }
                },
                {
                  ""plays"": 2,
                  ""last_watched_at"": ""2014-10-12T17:00:54.000Z"",
                  ""movie"": {
                    ""title"": ""The Dark Knight"",
                    ""year"": 2008,
                    ""ids"": {
                      ""trakt"": 4,
                      ""slug"": ""the-dark-knight-2008"",
                      ""imdb"": ""tt0468569"",
                      ""tmdb"": 155
                    }
                  }
                }
              ]";

        private const string WATCHED_SHOWS_JSON =
            @"[
                {
                  ""plays"": 56,
                  ""last_watched_at"": ""2014-10-13T17:00:54.000Z"",
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
                  },
                  ""seasons"": [
                    {
                      ""number"": 1,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                        },
                        {
                          ""number"": 2,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-13T17:00:54.000Z""
                        }
                      ]
                    },
                    {
                      ""number"": 2,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-11T17:00:54.000Z""
                        },
                        {
                          ""number"": 2,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-12T17:00:54.000Z""
                        }
                      ]
                    }
                  ]
                },
                {
                  ""plays"": 23,
                  ""last_watched_at"": ""2014-10-14T17:00:54.000Z"",
                  ""show"": {
                    ""title"": ""Parks and Recreation"",
                    ""year"": 2009,
                    ""ids"": {
                      ""trakt"": 4,
                      ""slug"": ""parks-and-recreation"",
                      ""tvdb"": 84912,
                      ""imdb"": ""tt1266020"",
                      ""tmdb"": 8592,
                      ""tvrage"": 21686
                    }
                  },
                  ""seasons"": [
                    {
                      ""number"": 1,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-11T17:00:54.000Z""
                        },
                        {
                          ""number"": 2,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-14T17:00:54.000Z""
                        }
                      ]
                    },
                    {
                      ""number"": 2,
                      ""episodes"": [
                        {
                          ""number"": 1,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-11T17:00:54.000Z""
                        },
                        {
                          ""number"": 2,
                          ""plays"": 1,
                          ""last_watched_at"": ""2014-10-14T17:00:54.000Z""
                        }
                      ]
                    }
                  ]
                }
              ]";

        private const string WATCHING_ITEM_MOVIE_JSON =
            @"{
                ""expires_at"": ""2014-10-23T08:36:02.000Z"",
                ""started_at"": ""2014-10-23T06:44:02.000Z"",
                ""action"": ""checkin"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Super 8"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 2,
                    ""slug"": ""super-8-2011"",
                    ""imdb"": ""tt1650062"",
                    ""tmdb"": 37686
                  }
                }
              }";

        private const string WATCHLIST_JSON =
            @"[
                {
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
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
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 3,
                    ""ids"": {
                      ""tvdb"": 171641,
                      ""tmdb"": 3575,
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
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 4,
                    ""number"": 1,
                    ""title"": ""Box Cutter"",
                    ""ids"": {
                      ""trakt"": 49,
                      ""tvdb"": 2639411,
                      ""imdb"": ""tt1683084"",
                      ""tmdb"": 62118,
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
                }
              ]";

        private const string HIDDEN_ITEMS_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 2
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [],
                  ""seasons"": []
                }
              }";

        private const string HIDDEN_ITEMS_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 2
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [],
                  ""seasons"": []
                }
              }";

        private const string CUSTOM_LISTS_REORDER_POST_RESPONSE_JSON =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  2
                ]
              }";

        private const string USER_RECOMMENDATIONS_JSON =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""movie"",
                  ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                  ""movie"": {
                    ""title"": ""TRON: Legacy"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 1,
                      ""slug"": ""tron-legacy-2010"",
                      ""imdb"": ""tt1104001"",
                      ""tmdb"": 20526
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string CUSTOM_LIST_ITEMS_REORDER_POST_RESPONSE_JSON =
            @"{
                ""updated"": 6,
                ""skipped_ids"": [
                  12
                ]
              }";

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
    }
}

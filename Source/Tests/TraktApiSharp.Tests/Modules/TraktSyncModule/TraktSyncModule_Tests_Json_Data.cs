namespace TraktApiSharp.Tests.Modules.TraktSyncModule
{
    using System;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Parameters;

    public partial class TraktSyncModule_Tests
    {
        private const string ENCODED_COMMA = "%2C";
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };
        private readonly TraktSyncType PLAYBACK_PROGRESS_TYPE = TraktSyncType.Episode;
        private const uint PLAYBACK_PROGRESS_LIMIT = 4;
        private readonly TraktRatingsItemType RATINGS_ITEM_TYPE = TraktRatingsItemType.Movie;
        private const int ITEM_COUNT = 4;
        private const uint PAGE = 2;
        private const uint LIMIT = 4;
        private readonly TraktSyncItemType HISTORY_ITEM_TYPE = TraktSyncItemType.Movie;
        private readonly DateTime START_AT = DateTime.UtcNow.AddMonths(-1);
        private readonly DateTime END_AT = DateTime.UtcNow;
        private const uint HISTORY_ITEM_ID = 123U;
        private const string WATCHLIST_SORT_BY = "rank";
        private const string WATCHLIST_SORT_HOW = "asc";
        private readonly TraktSyncItemType WATCHLIST_ITEM_TYPE = TraktSyncItemType.Episode;
        private const uint PLAYBACK_ID = 13U;

        private string BuildRatingsFilterString(int[] ratings) => string.Join(ENCODED_COMMA, ratings);

        private const string COLLECTION_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""episodes"": 12
                },
                ""updated"": {
                  ""movies"": 3,
                  ""episodes"": 1
                },
                ""existing"": {
                  ""movies"": 2,
                  ""episodes"": 0
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
                  ""episodes"": [ ]
                }
              }";

        private const string RATINGS_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4
                },
                ""not_found"": {
                  ""movies"": [
                    {
                      ""rating"": 10,
                      ""ids"": {
                        ""imdb"": ""tt0000111""
                      }
                    }
                  ],
                  ""shows"": [ ],
                  ""seasons"": [ ],
                  ""episodes"": [ ]
                }
              }";

        private const string HISTORY_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 2,
                  ""episodes"": 72
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
                  ""episodes"": [ ]
                }
              }";

        private const string WATCHLIST_POST_RESPONSE_JSON =
            @"{
                ""added"": {
                  ""movies"": 1,
                  ""shows"": 1,
                  ""seasons"": 1,
                  ""episodes"": 2
                },
                ""existing"": {
                  ""movies"": 0,
                  ""shows"": 1,
                  ""seasons"": 0,
                  ""episodes"": 0
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
                  ""episodes"": [ ]
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

        private const string LAST_ACTIVITIES_JSON =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string PLAYBACK_PROGRESS_JSON =
            @"[
                {
                  ""progress"": 10,
                  ""paused_at"": ""2015-01-25T22:01:32.000Z"",
                  ""id"": 13,
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
                  }
                },
                {
                  ""progress"": 65.5,
                  ""paused_at"": ""2015-01-25T22:01:32.000Z"",
                  ""id"": 37,
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 0,
                    ""number"": 1,
                    ""title"": ""Good Cop Bad Cop"",
                    ""ids"": {
                      ""trakt"": 1,
                      ""tvdb"": 3859781,
                      ""imdb"": """",
                      ""tmdb"": 62131,
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

        private const string WATCHED_HISTORY_JSON =
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

        private const string COLLECTION_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 1,
                  ""episodes"": 12
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
                  ""episodes"": [ ]
                }
              }";

        private const string RATINGS_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 1,
                  ""shows"": 2,
                  ""seasons"": 3,
                  ""episodes"": 4
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
                  ""episodes"": [ ]
                }
              }";

        private const string HISTORY_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 2,
                  ""episodes"": 72
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
                  ""ids"": [
                    23,
                    42
                  ]
                }
              }";

        private const string WATCHLIST_REMOVE_POST_RESPONSE_JSON =
            @"{
                ""deleted"": {
                  ""movies"": 1,
                  ""shows"": 1,
                  ""seasons"": 1,
                  ""episodes"": 2
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
                  ""episodes"": [ ]
                }
              }";
    }
}

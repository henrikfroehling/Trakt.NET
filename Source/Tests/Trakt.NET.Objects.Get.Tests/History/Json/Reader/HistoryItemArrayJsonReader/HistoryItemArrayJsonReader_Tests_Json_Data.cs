namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    public partial class HistoryItemArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        // ===================================================================================

        private const string TYPE_MOVIE_JSON_COMPLETE =
            @"[
                {
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        private const string TYPE_MOVIE_JSON_INCOMPLETE_2 =
            @"[
                {
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        private const string TYPE_MOVIE_JSON_NOT_VALID_1 =
            @"[
                {
                  ""i"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        private const string TYPE_MOVIE_JSON_NOT_VALID_2 =
            @"[
                {
                  ""id"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""i"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        private const string TYPE_MOVIE_JSON_NOT_VALID_3 =
            @"[
                {
                  ""i"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                  ""i"": 1982346,
                  ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                  ""action"": ""scrobble"",
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
                }
              ]";

        // ===================================================================================

        private const string TYPE_SHOW_JSON_COMPLETE =
            @"[
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        private const string TYPE_SHOW_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        private const string TYPE_SHOW_JSON_INCOMPLETE_2 =
            @"[
                {
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        private const string TYPE_SHOW_JSON_NOT_VALID_1 =
            @"[
                {
                  ""i"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        private const string TYPE_SHOW_JSON_NOT_VALID_2 =
            @"[
                {
                  ""id"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""i"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        private const string TYPE_SHOW_JSON_NOT_VALID_3 =
            @"[
                {
                  ""i"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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
                },
                {
                  ""i"": 1982348,
                  ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""show"",
                  ""show"": {
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

        // ===================================================================================

        private const string TYPE_SEASON_JSON_COMPLETE =
            @"[
                {
                  ""id"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string TYPE_SEASON_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""id"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                },
                {
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string TYPE_SEASON_JSON_INCOMPLETE_2 =
            @"[
                {
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string TYPE_SEASON_JSON_NOT_VALID_1 =
            @"[
                {
                  ""i"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
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
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string TYPE_SEASON_JSON_NOT_VALID_2 =
            @"[
                {
                  ""id"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                },
                {
                  ""i"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        private const string TYPE_SEASON_JSON_NOT_VALID_3 =
            @"[
                {
                  ""i"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                },
                {
                  ""i"": 1982344,
                  ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                  ""action"": ""watch"",
                  ""type"": ""season"",
                  ""season"": {
                    ""number"": 1,
                    ""ids"": {
                      ""trakt"": 61430,
                      ""tvdb"": 279121,
                      ""tmdb"": 60523,
                      ""tvrage"": 36939
                    }
                  }
                }
              ]";

        // ===================================================================================

        private const string TYPE_EPISODE_JSON_COMPLETE =
            @"[
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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

        private const string TYPE_EPISODE_JSON_INCOMPLETE_1 =
            @"[
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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

        private const string TYPE_EPISODE_JSON_INCOMPLETE_2 =
            @"[
                {
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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

        private const string TYPE_EPISODE_JSON_NOT_VALID_1 =
            @"[
                {
                  ""i"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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

        private const string TYPE_EPISODE_JSON_NOT_VALID_2 =
            @"[
                {
                  ""id"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""i"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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

        private const string TYPE_EPISODE_JSON_NOT_VALID_3 =
            @"[
                {
                  ""i"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
                },
                {
                  ""i"": 1982347,
                  ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                  ""action"": ""checkin"",
                  ""type"": ""episode"",
                  ""episode"": {
                    ""season"": 1,
                    ""number"": 1,
                    ""title"": ""Winter Is Coming"",
                    ""ids"": {
                      ""trakt"": 73640,
                      ""tvdb"": 3254641,
                      ""imdb"": ""tt1480055"",
                      ""tmdb"": 63056,
                      ""tvrage"": 1065008299
                    }
                  },
                  ""show"": {
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
    }
}
